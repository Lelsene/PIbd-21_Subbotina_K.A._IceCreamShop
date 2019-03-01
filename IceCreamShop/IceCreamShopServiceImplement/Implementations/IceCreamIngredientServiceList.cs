using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

namespace IceCreamShopServiceImplement.Implementations
{
    class IceCreamIngredientServiceList : IIceCreamIngredientService
    {
        private DataListSingleton source;

        public IceCreamIngredientServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<IceCreamIngredientViewModel> GetList()
        {
            List<IceCreamIngredientViewModel> result = new List<IceCreamIngredientViewModel>();
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                result.Add(new IceCreamIngredientViewModel
                {
                    Id = source.IceCreamIngredients[i].Id,
                    IceCreamId = source.IceCreamIngredients[i].IceCreamId,
                    IngredientId = source.IceCreamIngredients[i].IngredientId,
                    Count = source.IceCreamIngredients[i].Count,
                    IngredientName = source.IceCreamIngredients[i].IngredientName
                });
            }
            return result;
        }

        public IceCreamIngredientViewModel GetElement(int id)
        {
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id == id)
                {
                    return new IceCreamIngredientViewModel
                    {
                        Id = source.IceCreamIngredients[i].Id,
                        IngredientName = source.IceCreamIngredients[i].IngredientName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(IceCreamIngredientBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id > maxId)
                {
                    maxId = source.IceCreamIngredients[i].Id;
                }
                if (source.IceCreamIngredients[i].IngredientName == model.IngredientName)
                {
                    throw new Exception("Уже есть ингредиент с таким именем");
                }
            }
            source.IceCreamIngredients.Add(new IceCreamIngredient
            {
                Id = maxId + 1,
                IceCreamId = model.IceCreamId,
                IngredientId = model.IngredientId,
                Count = model.Count,
                IngredientName = model.IngredientName
            });
        }

        public void UpdElement(IceCreamIngredientBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.IceCreamIngredients[i].IngredientName == model.IngredientName &&
                source.IceCreamIngredients[i].Id != model.Id)
                {
                    throw new Exception("Уже есть ингредиент с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.IceCreamIngredients[index].IngredientName = model.IngredientName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id == id)
                {
                    source.IceCreamIngredients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
