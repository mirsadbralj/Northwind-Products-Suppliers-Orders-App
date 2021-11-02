using AutoMapper;
using Northwind.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Service
{
    public class BaseService<TModel, Tsearch, TDatabase> : IService<TModel, Tsearch> where TDatabase : class
    {
        public readonly NORTHWNDContext _context;
        public readonly IMapper _mapper;

        public BaseService(NORTHWNDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual List<TModel> Get(Tsearch search)
        {
            var list = _context.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(list);
        }
        public virtual TModel GetById(int Id)
        {
            var entity = _context.Set<TDatabase>().Find(Id);

            return _mapper.Map<TModel>(entity);
        }
    }
}
