using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Entities;

namespace UniversityManagement.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Get();
        IEnumerable<TEntity> List(ISpecification<TEntity> spec);
        void Update(TEntity entity);
        void Remove(int id);
        int SaveChanges();
    }
}