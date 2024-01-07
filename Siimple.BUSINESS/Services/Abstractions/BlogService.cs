using Siimple.BUSINESS.Services.Interfaces;
using Siimple.BUSINESS.ViewModels.Blog;
using Siimple.CORE.Models;
using Siimple.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.BUSINESS.Services.Abstractions
{
    public class BlogService : IBlogService
    {
        
        private readonly IBlogRepository _repository;
        
        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public void CreateAsync(CreateBlog createBlog,string path)
        {
            Blog blog = new Blog();
            blog.Name = createBlog.Name;
            blog.Descritpion=createBlog.Descritpion;
            blog.ImageUrl = path;
              _repository.CreateAsync(blog);
        } 

        public void DeleteByIdAsync(int id)
        {
            _repository.DeleteByIdAsync(id);
        }

        public Task<Blog> FindByIdAsync(int id)
        {

        
            return _repository.FindByIdAsync(id);
        }

        public Task<IQueryable<Blog>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }        


        public async void UpdateAsync(UpdateBlog updateBlog,string path,Blog blog)
        {
            
            blog.Name = updateBlog.Name;
            blog.Descritpion = updateBlog.Descritpion;
            blog.ImageUrl = path;
            _repository.UpdateAsync(blog);
        }
    }
}
