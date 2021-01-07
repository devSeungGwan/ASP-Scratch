using ASPnetNote.MVC6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetNote.MVC6.DataContext
{
    public class ASPnetNoteDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AspnetNoteDb;User Id=mayman;Password=root1234!@;");
        }
    }
}
