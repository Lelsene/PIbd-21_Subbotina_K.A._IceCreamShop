using IceCreamShopRestApi.Services;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace IceCreamShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;

        private readonly IIcemanService _serviceIceman;

        public MainController(IMainService service, IIcemanService serviceIceman)
        {
            _service = service;
            _serviceIceman = serviceIceman;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void CreateBooking(BookingBindingModel model)
        {
            _service.CreateBooking(model);
        }

        [HttpPost]
        public void PayBooking(BookingBindingModel model)
        {
            _service.PayBooking(model);
        }

        [HttpPost]
        public void PutIngredientOnStorage(StorageIngredientBindingModel model)
        {
            _service.PutIngredientOnStorage(model);
        }

        [HttpPost]
        public void StartWork()
        {
            List<BookingViewModel> bookings = _service.GetFreeBookings();
            foreach (var booking in bookings)
            {
                IcemanViewModel impl = _serviceIceman.GetFreeIceman();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkIceman(_service, _serviceIceman, impl.Id, booking.Id);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}
