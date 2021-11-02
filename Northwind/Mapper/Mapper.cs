using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindModel.Requests.Category;
using NorthwindModel.Requests.Order;
using NorthwindModel.Requests.OrderDetails;
using NorthwindModel.Requests.Product;
using NorthwindModel.Requests.Supplier;

namespace Northwind.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Database.Product, NorthwindModel.Product>();
            CreateMap<Database.Product, ProductUpsertRequest>().ReverseMap();
            CreateMap<NorthwindModel.Product, ProductUpsertRequest>().ReverseMap();

            CreateMap<Database.Supplier, NorthwindModel.Supplier>();
            CreateMap<Database.Supplier, SupplierUpsertRequest>().ReverseMap();
            CreateMap<NorthwindModel.Supplier, SupplierUpsertRequest>().ReverseMap();

            CreateMap<Database.Order, NorthwindModel.Order>();
            CreateMap<Database.Order, OrderUpsertRequest>().ReverseMap();
            CreateMap<NorthwindModel.Order, OrderUpsertRequest>().ReverseMap();

            CreateMap<Database.OrderDetail, NorthwindModel.OrderDetail>();
            CreateMap<Database.OrderDetail, OrderDetailUpsertRequest>().ReverseMap();
            CreateMap<NorthwindModel.OrderDetail, OrderDetailUpsertRequest>().ReverseMap();

            CreateMap<Database.Category, NorthwindModel.Category>();
            CreateMap<Database.Category, CategoryUpsertRequest>().ReverseMap();
            CreateMap<NorthwindModel.Category, CategoryUpsertRequest>().ReverseMap();
        }

    }
}
