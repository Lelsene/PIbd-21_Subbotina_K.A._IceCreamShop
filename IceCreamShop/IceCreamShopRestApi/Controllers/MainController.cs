using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace IceCreamShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;

        public MainController(IMainService service)
        {
            _service = service;
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
        public void TakeBookingInWork(BookingBindingModel model)
        {
            _service.TakeBookingInWork(model);
        }

        [HttpPost]
        public void FinishBooking(BookingBindingModel model)
        {
            _service.FinishBooking(model);
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
    }
}
