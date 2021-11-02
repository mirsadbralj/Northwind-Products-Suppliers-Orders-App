using AutoMapper;
using Northwind.Database;
using NorthwindModel.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Service.Category
{
    public class CategoryService : BaseCRUDService<NorthwindModel.Category, CategorySearchRequest, Database.Category, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryService(NORTHWNDContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
