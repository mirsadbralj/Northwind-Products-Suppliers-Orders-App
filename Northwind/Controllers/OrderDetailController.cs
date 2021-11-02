using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Service;
using NorthwindModel;
using NorthwindModel.Requests.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : BaseCRUDController<NorthwindModel.OrderDetail, OrderDetailSearchRequest, OrderDetailUpsertRequest, OrderDetailUpsertRequest>
    {
        public OrderDetailController(ICRUDService<OrderDetail, OrderDetailSearchRequest, OrderDetailUpsertRequest, OrderDetailUpsertRequest> service) : base(service)
        {
        }
    }
}
