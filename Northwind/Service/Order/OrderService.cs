using AutoMapper;
using Northwind.Database;
using NorthwindModel.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Service.Order
{
    public class OrderService : BaseCRUDService<NorthwindModel.Order, OrderSearchRequest, Database.Order, OrderUpsertRequest, OrderUpsertRequest>
    {
        public OrderService(NORTHWNDContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<NorthwindModel.Order> Get(OrderSearchRequest search)
        {
            List<NorthwindModel.Order> list = new List<NorthwindModel.Order>();

            var orders = from o in _context.Orders join
                              od in _context.OrderDetails on o.OrderId equals od.OrderId join
                              p in _context.Products on od.ProductId equals p.ProductId join
                              c in _context.Categories on p.CategoryId equals c.CategoryId join
                              s in _context.Suppliers on p.SupplierId equals s.SupplierId
                         select new NorthwindModel.Order {OrderId = o.OrderId,
                                    CustomerId =  o.CustomerId,
                                    EmployeeId = o.EmployeeId,
                                    OrderDate = o.OrderDate,
                                    RequiredDate = o.RequiredDate,
                                    ShippedDate= o.ShippedDate,
                                    ShipVia= o.ShipVia,
                                    Freight= o.Freight,
                                    ShipName= o.ShipName,
                                    ShipAddress= o.ShipAddress,
                                    ShipCity= o.ShipCity,
                                    ShipRegion= o.ShipRegion,
                                    ShipPostalCode= o.ShipPostalCode,
                                    ShipCountry= o.ShipCountry,
                                    ProductName=p.ProductName,
                                    CompanyName= s.CompanyName,
                                    ContactName= s.ContactName,
                                    CategoryName= c.CategoryName 
                         };

            list = _mapper.Map<List<NorthwindModel.Order>>(orders);

            return list;
        }
    }
}
