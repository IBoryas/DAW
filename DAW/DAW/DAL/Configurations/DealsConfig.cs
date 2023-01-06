using DAW.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAW.DAL.Configurations
{
    public class DealsConfig : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder
                .Property(e => e.ProspectedStartDate)
                .HasColumnType("date");

        }
    }
}
