using Microsoft.AspNetCore.Http;
using Siimple.CORE.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.CORE.Models
{
    public class Blog:BaseEntityId
    {
        public string Name { get; set; }
        public string Descritpion { get; set; }
        
        public string? ImageUrl { get; set; }
    }
}
