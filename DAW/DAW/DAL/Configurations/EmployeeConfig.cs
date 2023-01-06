using DAW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAW.DAL.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(e => e.EndDate)
                .HasColumnType("date");

            builder
                .Property(e => e.StartDate)
                .HasColumnType("date");

            builder
                .HasOne(e => e.Project)
                .WithMany(e => e.Employees)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
