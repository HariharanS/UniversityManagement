using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Domain.Entities;
using UniversityManagement.Domain.Interfaces;

namespace UniversityManagement.Infrastructure.Database
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity 
    {
        private readonly UniversityManagementContext _dbContext;
        public EFRepository(UniversityManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            
        }

        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
			_dbContext.SaveChanges();

			return entity;
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
			_dbContext.Entry(entity).State = EntityState.Modified;
			_dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
			_dbContext.SaveChanges();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}