using Microsoft.EntityFrameworkCore;
using MVCWizard.Data.Models;

namespace MVCWizard.Api.Data
{
    public class EmployeeDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
            
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }




    }
}
