using DAW.DAL.Configurations;
using DAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAW.API
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Client> Clients { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(EmployeeConfig).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
