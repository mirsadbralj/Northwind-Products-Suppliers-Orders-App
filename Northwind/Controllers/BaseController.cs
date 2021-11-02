using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, Tsearch> : ControllerBase
    {
        private readonly IService<T, Tsearch> _service;

        public BaseController(IService<T, Tsearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<T> Get([FromQuery] Tsearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{Id}")]
        public T GetById(int Id)
        {
            return _service.GetById(Id);
        }
    }
}
