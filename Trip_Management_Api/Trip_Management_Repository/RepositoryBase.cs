using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Contracts;
using Trip_Management_Entities;

namespace Trip_Management_Repository
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        private TripContext _tripContext;

        public RepositoryBase(TripContext tripContext)
        {
            _tripContext = tripContext;
        }

        public void Create(T entity) => _tripContext.Set<T>().Add(entity);

        public void Delete(T entity) => _tripContext.Set<T>().Remove(entity);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression
           , bool trackChanges)
        {
            return !trackChanges ? _tripContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
                _tripContext.Set<T>().Where(expression);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _tripContext.Set<T>().AsNoTracking() :
              _tripContext.Set<T>();
        }


        public void Update(T entity) => _tripContext.Set<T>().Update(entity);
    }
}
