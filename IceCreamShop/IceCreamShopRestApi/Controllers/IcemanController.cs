using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace IceCreamShopRestApi.Controllers
{
    public class IcemanController : ApiController
    {
        private readonly IIcemanService _service;

        public IcemanController(IIcemanService service)
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

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(IcemanBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(IcemanBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(IcemanBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
