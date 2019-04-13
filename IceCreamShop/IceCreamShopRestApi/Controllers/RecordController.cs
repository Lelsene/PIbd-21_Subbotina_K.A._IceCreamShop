using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace IceCreamShopRestApi.Controllers
{
    public class RecordController : ApiController
    {
        private readonly IRecordService _service;

        public RecordController(IRecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetStoragesLoad()
        {
            var list = _service.GetStoragesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetCustomerBookings(RecordBindingModel model)
        {
            var list = _service.GetCustomerBookings(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveIceCreamPrice(RecordBindingModel model)
        {
            _service.SaveIceCreamPrice(model);
        }

        [HttpPost]
        public void SaveStoragesLoad(RecordBindingModel model)
        {
            _service.SaveStoragesLoad(model);
        }

        [HttpPost]
        public void SaveCustomerBookings(RecordBindingModel model)
        {
            _service.SaveCustomerBookings(model);
        }
    }
}
