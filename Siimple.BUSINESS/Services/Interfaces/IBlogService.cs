using Siimple.BUSINESS.ViewModels.Blog;
using Siimple.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.BUSINESS.Services.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> FindByIdAsync(int id);
        Task<IQueryable<Blog>> GetAllAsync();
        void DeleteByIdAsync(int id);
        void CreateAsync(CreateBlog createBlog, string path);
        void UpdateAsync(UpdateBlog updateBlog, string path,Blog blog);

    }
}
