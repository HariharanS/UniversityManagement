using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityManagement.Application.Interfaces
{
    public interface IBaseService<TModel> where TModel : class
    {
        Task<TModel> GetById(int id);
		Task<IEnumerable<TModel>> GetAll();
		Task<TModel> Create(TModel student);
    }
}
