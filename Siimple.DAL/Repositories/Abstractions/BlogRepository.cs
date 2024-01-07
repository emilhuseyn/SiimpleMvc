using Siimple.CORE.Models;
using Siimple.DAL.DB;
using Siimple.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.DAL.Repositories.Abstractions
{
    public class BlogRepository:Repository<Blog>,IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
