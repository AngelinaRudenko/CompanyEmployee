using ConsoleApp14.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class ContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            
        }
    }
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new ContextInitializer());
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }*/
    }
}
