using DAW.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAW.DAL.Configurations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(e => e.EndDate)
                .HasColumnType("date");

            builder
                .Property(e => e.StartDate)
                .HasColumnType("date");

            builder
                .Property(e => e.SignedDate)
                .HasColumnType("date");
        }
    }
}
