using System.Linq;
using UniversityManagement.Domain.Interfaces;

namespace UniversityManagement.Infrastructure.Database
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Add(TEntity obj)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}