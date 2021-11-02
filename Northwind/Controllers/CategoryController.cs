using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Service;
using NorthwindModel;
using NorthwindModel.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseCRUDController<NorthwindModel.Category, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryController(ICRUDService<Category, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest> service) : base(service)
        {
        }
    }
}
