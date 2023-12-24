using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using MyFirstCrudApplication.Models;

namespace MyFirstCrudApplication.Data
{
    public class ApplicationContext:DbContext
    {
       public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options) { }
        public DbSet<Employee>EmployeeData{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Employee_Id);

            // Other configurations if needed

            base.OnModelCreating(modelBuilder);
        }

    }
}
