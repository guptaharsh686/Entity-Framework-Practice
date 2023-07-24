using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Repository
{
    public interface IGenericRepository<TClass> where TClass : class
    {
        TClass GetById(int id);

        IEnumerable<TClass> GetAll();

        IEnumerable<TClass> Find(Expression<Func<TClass, bool>> predicate);

        void Add(TClass entity);

        void AddRange(IEnumerable<TClass> entities);

        void Remove(TClass entity);
        void RemoveRange(IEnumerable<TClass> entities);
    }
}
