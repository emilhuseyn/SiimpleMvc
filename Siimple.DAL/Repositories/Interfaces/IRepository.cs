using Siimple.CORE.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntityId, new()
    {
        Task<T> FindByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        void DeleteByIdAsync(int id);
        void CreateAsync(T entity);
        void UpdateAsync(T entity);
        
    }
}
