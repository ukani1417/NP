
using Microsoft.EntityFrameworkCore;
using NP.Models;

namespace NP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }    
        public DbSet<Class> Classes { get; set; }   

        public DbSet<Subject> Subjects { get; set;}

        public DbSet<Test> Tests { get; set; }
    }
}