using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementation
{
    public class GenericRepository<TClass> : IGenericRepository<TClass> where TClass : class
    {
        private readonly MovieManagementDbContext _context;

        public GenericRepository(MovieManagementDbContext context)
        {
            this._context = context;
        }
        public void Add(TClass entity)
        {
            _context.Set<TClass>().Add(entity);
        }

        public void AddRange(IEnumerable<TClass> entities)
        {
            _context.Set<TClass>().AddRange(entities);
        }

        public IEnumerable<TClass> Find(System.Linq.Expressions.Expression<Func<TClass, bool>> predicate)
        {
            return _context.Set<TClass>().Where(predicate);
        }

        public IEnumerable<TClass> GetAll()
        {
            return _context.Set<TClass>().ToList();
        }

        public TClass GetById(int id)
        {
            return _context.Set<TClass>().Find(id);
        }

        public void Remove(TClass entity)
        {
            _context.Set<TClass>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TClass> entities)
        {
            _context.Set<TClass>().RemoveRange(entities);
        }
    }
}
