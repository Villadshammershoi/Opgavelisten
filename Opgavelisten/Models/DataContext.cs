using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Opgavelisten.Models
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext() : base("DefaultConnection") 
        {
        }
            public DbSet<Task> Tasks {get; set;}
            public DbSet<Category> Categories {get; set;}
        
    }
}