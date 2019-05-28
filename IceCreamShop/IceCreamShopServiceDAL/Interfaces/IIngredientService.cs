﻿using IceCreamShopServiceDAL.Attributies;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с ингредиентами")]
    public interface IIngredientService
    {
        [CustomMethod("Метод получения списка ингредиентов")]
        List<IngredientViewModel> GetList();

        [CustomMethod("Метод получения ингредиента по id")]
        IngredientViewModel GetElement(int id);

        [CustomMethod("Метод добавления ингредиента")]
        void AddElement(IngredientBindingModel model);

        [CustomMethod("Метод изменения данных по ингредиенту")]
        void UpdElement(IngredientBindingModel model);

        [CustomMethod("Метод удаления ингредиента")]
        void DelElement(int id);
    }
}
