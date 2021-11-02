using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Service;
using NorthwindModel;
using NorthwindModel.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseCRUDController<NorthwindModel.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest>
    {
        public ProductController(ICRUDService<NorthwindModel.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest> service) : base(service)
        {
        }
    }
}
