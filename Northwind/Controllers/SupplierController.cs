using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Service;
using NorthwindModel;
using NorthwindModel.Requests.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseCRUDController<NorthwindModel.Supplier, SupplierSearchRequest, SupplierUpsertRequest, SupplierUpsertRequest>
    {
        public SupplierController(ICRUDService<Supplier, SupplierSearchRequest, SupplierUpsertRequest, SupplierUpsertRequest> service) : base(service)
        {
        }
    }
}
