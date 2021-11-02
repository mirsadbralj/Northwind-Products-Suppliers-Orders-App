using AutoMapper;
using Northwind.Database;
using NorthwindModel.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Service.Product
{
    public class ProductService : BaseCRUDService<NorthwindModel.Product, ProductSearchRequest, Database.Product, ProductUpsertRequest, ProductUpsertRequest>
    {
        public ProductService(NORTHWNDContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<NorthwindModel.Product> Get(ProductSearchRequest search)
        {
            var list = _context.Products.AsQueryable();
            var listSupp = _context.Suppliers.AsQueryable();

            List<NorthwindModel.Product> listProduct = new List<NorthwindModel.Product>();

            listProduct = _mapper.Map<List<NorthwindModel.Product>>(list);

            foreach(NorthwindModel.Product item in listProduct)
            {
                if (listSupp.Where(x => x.SupplierId == item.SupplierId).Select(y => y.CompanyName).FirstOrDefault() != null)
                {
                    item.CompanyName = listSupp.Where(x => x.SupplierId == item.SupplierId).Select(y => y.CompanyName).First();
                    item.ContactName = listSupp.Where(x => x.SupplierId == item.SupplierId).Select(y => y.ContactName).First();
                    item.Address = listSupp.Where(x => x.SupplierId == item.SupplierId).Select(y => y.Address).First();
                }
            }
            return listProduct;
        }
        public override NorthwindModel.Product Insert(ProductUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Product>(request);

            _context.Products.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<NorthwindModel.Product>(entity);
        }
        public override NorthwindModel.Product Delete(int Id)
        {
            var entity = _context.Products.Find(Id);
            var listOrderDetails = _context.OrderDetails.Where(x => x.ProductId == entity.ProductId).ToList();

            foreach(var item in listOrderDetails)
            {
                _context.OrderDetails.Remove(item);
            }            
            _context.Products.Remove(entity);

            _context.SaveChanges();
            return _mapper.Map<NorthwindModel.Product>(entity);
        }
    }
}
