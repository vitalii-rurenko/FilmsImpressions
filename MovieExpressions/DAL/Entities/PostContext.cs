using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Entities
{
    public class PostContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
