using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopServiceImplement.Implementations
{
    public class IceCreamServiceList : IIceCreamService
    {
        private DataListSingleton source;

        public IceCreamServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<IceCreamViewModel> GetList()
        {
            List<IceCreamViewModel> result = source.IceCreams.Select(rec => new IceCreamViewModel
            {
                Id = rec.Id,
                IceCreamName = rec.IceCreamName,
                Price = rec.Price,
                IceCreamIngredients = source.IceCreamIngredients
                       .Where(recPC => recPC.IceCreamId == rec.Id)
                       .Select(recPC => new IceCreamIngredientViewModel
                       {
                           Id = recPC.Id,
                           IceCreamId = recPC.IceCreamId,
                           IngredientId = recPC.IngredientId,
                           IngredientName = source.Ingredients.FirstOrDefault(recC =>
                           recC.Id == recPC.IngredientId)?.IngredientName,
                           Count = recPC.Count
                       })
                       .ToList()
            })
            .ToList();
            return result;
        }

        public IceCreamViewModel GetElement(int id)
        {
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new IceCreamViewModel
                {
                    Id = element.Id,
                    IceCreamName = element.IceCreamName,
                    Price = element.Price,
                    IceCreamIngredients = source.IceCreamIngredients
                        .Where(recPC => recPC.IceCreamId == element.Id)
                        .Select(recPC => new IceCreamIngredientViewModel
                        {
                            Id = recPC.Id,
                            IceCreamId = recPC.IceCreamId,
                            IngredientId = recPC.IngredientId,
                            IngredientName = source.Ingredients.FirstOrDefault(recC => recC.Id == recPC.IngredientId)?.IngredientName,
                            Count = recPC.Count
                        })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(IceCreamBindingModel model)
        {
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.IceCreamName == model.IceCreamName);
            if (element != null)
            {
                throw new Exception("Уже есть мороженое с таким названием");
            }
            int maxId = source.IceCreams.Count > 0 ? source.IceCreams.Max(rec => rec.Id) : 0;
            source.IceCreams.Add(new IceCream
            {
                Id = maxId + 1,
                IceCreamName = model.IceCreamName,
                Price = model.Price
            });

            // ингредиенты для мороженого
            int maxPCId = source.IceCreamIngredients.Count > 0 ? source.IceCreamIngredients.Max(rec => rec.Id) : 0;

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
                source.IceCreamIngredients.Add(new IceCreamIngredient
                {
                    Id = ++maxPCId,
                    IceCreamId = maxId + 1,
                    IngredientId = groupIngredient.IngredientId,
                    Count = groupIngredient.Count
                });
            }
        }

        public void UpdElement(IceCreamBindingModel model)
        {
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.IceCreamName == model.IceCreamName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть мороженое с таким названием");
            }
            element = source.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.IceCreamName = model.IceCreamName;
            element.Price = model.Price;
            int maxPCId = source.IceCreamIngredients.Count > 0 ?
            source.IceCreamIngredients.Max(rec => rec.Id) : 0;

            // обновляем существуюущие ингредиенты
            var compIds = model.IceCreamIngredients.Select(rec =>
            rec.IngredientId).Distinct();
            var updateIngredients = source.IceCreamIngredients.Where(rec => rec.IceCreamId ==
            model.Id && compIds.Contains(rec.IngredientId));
            foreach (var updateIngredient in updateIngredients)
            {
                updateIngredient.Count = model.IceCreamIngredients.FirstOrDefault(rec => rec.Id == updateIngredient.Id).Count;
            }
            source.IceCreamIngredients.RemoveAll(rec => rec.IceCreamId == model.Id && !compIds.Contains(rec.IngredientId));

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
                IceCreamIngredient elementPC = source.IceCreamIngredients.FirstOrDefault(rec => rec.IceCreamId == model.Id && rec.IngredientId == groupIngredient.IngredientId);
                if (elementPC != null)
                {
                    elementPC.Count += groupIngredient.Count;
                }
                else
                {
                    source.IceCreamIngredients.Add(new IceCreamIngredient
                    {
                        Id = ++maxPCId,
                        IceCreamId = model.Id,
                        IngredientId = groupIngredient.IngredientId,
                        Count = groupIngredient.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по ингредиентам при удалении мороженого
                source.IceCreamIngredients.RemoveAll(rec => rec.IceCreamId == id);
                source.IceCreams.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
