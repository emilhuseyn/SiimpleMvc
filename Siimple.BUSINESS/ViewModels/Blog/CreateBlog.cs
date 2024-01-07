using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.BUSINESS.ViewModels.Blog
{
    public class CreateBlog
    {
        public string Name { get; set; }
        public string Descritpion { get; set; }
        
        public IFormFile? Image { get; set; }
    }
}
