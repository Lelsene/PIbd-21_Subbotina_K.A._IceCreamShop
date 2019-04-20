using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopServiceImplementDataBase.Implementations
{
    public class IcemanServiceDB : IIcemanService
    {
        private IceCreamDbContext context;

        public IcemanServiceDB(IceCreamDbContext context)
        {
            this.context = context;
        }
        public List<IcemanViewModel> GetList()
        {
            List<IcemanViewModel> result = context.Icemans
            .Select(rec => new IcemanViewModel
            {
                Id = rec.Id,
                IcemanFIO = rec.IcemanFIO
            })
            .ToList();
            return result;
        }
        public IcemanViewModel GetElement(int id)
        {
            Iceman element = context.Icemans.FirstOrDefault(rec => rec.Id ==
            id);
            if (element != null)
            {
                return new IcemanViewModel
                {
                    Id = element.Id,
                    IcemanFIO = element.IcemanFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(IcemanBindingModel model)
        {
            Iceman element = context.Icemans.FirstOrDefault(rec =>
            rec.IcemanFIO == model.IcemanFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Icemans.Add(new Iceman
            {
                IcemanFIO = model.IcemanFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(IcemanBindingModel model)
        {
            Iceman element = context.Icemans.FirstOrDefault(rec =>
            rec.IcemanFIO == model.IcemanFIO &&
            rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Icemans.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.IcemanFIO = model.IcemanFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Iceman element = context.Icemans.FirstOrDefault(rec => rec.Id ==
            id);
            if (element != null)
            {
                context.Icemans.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public IcemanViewModel GetFreeIceman()
        {
            var ordersWorker = context.Icemans
                .Select(x => new
                {
                    ImplId = x.Id,
                    Count = context.Bookings.Where(o => o.Status == BookingStatus.Готовится && o.IcemanId == x.Id).Count()
                })
                .OrderBy(x => x.Count)
                .FirstOrDefault();
            if (ordersWorker != null)
            {
                return GetElement(ordersWorker.ImplId);
            }
            return null;
        }
    }
}