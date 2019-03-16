using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopServiceImplementDataBase.Implementations
{
    public class IceCreamServiceDB : IIceCreamService
    {
        private IceCreamDbContext context;
        public IceCreamServiceDB(IceCreamDbContext context)
        {
            this.context = context;
        }
        public List<IceCreamViewModel> GetList()
        {
            List<IceCreamViewModel> result = context.IceCreams.Select(rec => new
            IceCreamViewModel
            {
                Id = rec.Id,
                IceCreamName = rec.IceCreamName,
                Price = rec.Price,
                IceCreamIngredients = context.IceCreamIngredients
                    .Where(recPC => recPC.IceCreamId == rec.Id)
                    .Select(recPC => new IceCreamIngredientViewModel
                    {
                        Id = recPC.Id,
                        IceCreamId = recPC.IceCreamId,
                        IngredientId = recPC.IngredientId,
                        IngredientName = recPC.Ingredient.IngredientName,
                        Count = recPC.Count
                    })
                    .ToList()
            })
            .ToList();
            return result;
        }
        public IceCreamViewModel GetElement(int id)
        {
            IceCream element = context.IceCreams.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new IceCreamViewModel
                {
                    Id = element.Id,
                    IceCreamName = element.IceCreamName,
                    Price = element.Price,
                    IceCreamIngredients = context.IceCreamIngredients
                        .Where(recPC => recPC.IceCreamId == element.Id)
                        .Select(recPC => new IceCreamIngredientViewModel
                        {
                            Id = recPC.Id,
                            IceCreamId = recPC.IceCreamId,
                            IngredientId = recPC.IngredientId,
                            IngredientName = recPC.Ingredient.IngredientName,
                            Count = recPC.Count
                        })
                        .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(IceCreamBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    IceCream element = context.IceCreams.FirstOrDefault(rec =>
                    rec.IceCreamName == model.IceCreamName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть мороженое с таким названием");
                    }
                    element = new IceCream
                    {
                        IceCreamName = model.IceCreamName,
                        Price = model.Price
                    };
                    context.IceCreams.Add(element);
                    context.SaveChanges();
                    // убираем дубли по ингредиентам
                    var groupIngredients = model.IceCreamIngredients
                                                .GroupBy(rec => rec.IngredientId)
                                                .Select(rec => new
                                                {
                                                    IngredientId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    // добавляем ингредиенты
                    foreach (var groupIngredient in groupIngredients)
                    {
                        context.IceCreamIngredients.Add(new IceCreamIngredient
                        {
                            IceCreamId = element.Id,
                            IngredientId = groupIngredient.IngredientId,
                            Count = groupIngredient.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(IceCreamBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    IceCream element = context.IceCreams.FirstOrDefault(rec =>
                    rec.IceCreamName == model.IceCreamName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть мороженое с таким названием");
                    }
                    element = context.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.IceCreamName = model.IceCreamName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие ингредиенты
                    var compIds = model.IceCreamIngredients.Select(rec =>
                    rec.IngredientId).Distinct();
                    var updateIngredients = context.IceCreamIngredients.Where(rec =>
                    rec.IceCreamId == model.Id && compIds.Contains(rec.IngredientId));
                    foreach (var updateIngredient in updateIngredients)
                    {
                        updateIngredient.Count =
                        model.IceCreamIngredients.FirstOrDefault(rec => rec.Id == updateIngredient.Id).Count;
                    }
                    context.SaveChanges();
                    context.IceCreamIngredients.RemoveRange(context.IceCreamIngredients.Where(rec =>
                    rec.IceCreamId == model.Id && !compIds.Contains(rec.IngredientId)));
                    context.SaveChanges();
                    // новые записи
                    var groupIngredients = model.IceCreamIngredients
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.IngredientId)
                                                .Select(rec => new
                                                {
                                                    IngredientId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupIngredient in groupIngredients)
                    {
                        IceCreamIngredient elementPC =
                        context.IceCreamIngredients.FirstOrDefault(rec => rec.IceCreamId == model.Id &&
                        rec.IngredientId == groupIngredient.IngredientId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupIngredient.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.IceCreamIngredients.Add(new IceCreamIngredient
                            {
                                IceCreamId = model.Id,
                                IngredientId = groupIngredient.IngredientId,
                                Count = groupIngredient.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    IceCream element = context.IceCreams.FirstOrDefault(rec => rec.Id ==
                    id);
                    if (element != null)
                    {
                        // удаяем записи по ингредиентам при удалении изделия
                        context.IceCreamIngredients.RemoveRange(context.IceCreamIngredients.Where(rec =>
                        rec.IceCreamId == id));
                        context.IceCreams.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}