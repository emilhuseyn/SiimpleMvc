using Microsoft.EntityFrameworkCore;
using Siimple.CORE.Models.BaseEntity;
using Siimple.DAL.DB;
using Siimple.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.DAL.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseEntityId, new()
    {
        private readonly AppDbContext _dbContext;

        private readonly DbSet<T> _table;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();

        }

        public void CreateAsync(T entity)
        {
            _table.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteByIdAsync(int id)
        {
            var entity= _table.Find(id);
            _table.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }



        public async Task<IQueryable<T>> GetAllAsync()
        {
            IQueryable<T> values = _table;
            return values;
        }


        public async void UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _dbContext.SaveChangesAsync();
            _dbContext.SaveChanges();
        }

        
    }
}
