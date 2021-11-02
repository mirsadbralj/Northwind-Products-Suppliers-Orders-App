using AutoMapper;
using Northwind.Database;
using NorthwindModel.Requests.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Service.Supplier
{
    public class SupplierService : BaseCRUDService<NorthwindModel.Supplier, SupplierSearchRequest, Database.Supplier, SupplierUpsertRequest, SupplierUpsertRequest>
    {
        public SupplierService(NORTHWNDContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override NorthwindModel.Supplier Delete(int Id)
        {
            var entity = _context.Suppliers.Find(Id);
            var products = _context.Products.Where(x => x.SupplierId == entity.SupplierId).ToList();
            foreach (var product in products) {
                product.SupplierId = null;
                _context.Products.Update(product);
            }
            _context.Suppliers.Remove(entity);

            _context.SaveChanges();
            return _mapper.Map<NorthwindModel.Supplier>(entity);
        }
    }
}
