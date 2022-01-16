using Microsoft.EntityFrameworkCore;
using MVCWizard.Data.Models;

namespace MVCWizard.Api.Data
{
    public class EmployeeDBContext : DbContext
    {

        private readonly string _connectionString;

        
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {   
            
           IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json")
          .Build();

            _connectionString =configuration.GetConnectionString("DefaultConnection");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);

        }



        public DbSet<Employee> Employees { get; set; }




    }
}
