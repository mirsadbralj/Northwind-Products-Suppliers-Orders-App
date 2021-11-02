using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Service;
using NorthwindModel;
using NorthwindModel.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseCRUDController<NorthwindModel.Order, OrderSearchRequest, OrderUpsertRequest, OrderUpsertRequest>
    {
        public OrderController(ICRUDService<Order, OrderSearchRequest, OrderUpsertRequest, OrderUpsertRequest> service) : base(service)
        {
        }
    }
}
