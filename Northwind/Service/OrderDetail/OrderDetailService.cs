using AutoMapper;
using Northwind.Database;
using NorthwindModel.Requests.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Service.OrderDetail
{
    public class OrderDetailService : BaseCRUDService<NorthwindModel.OrderDetail, OrderDetailSearchRequest, Database.OrderDetail, OrderDetailUpsertRequest, OrderDetailUpsertRequest>
    {
        public OrderDetailService(NORTHWNDContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
