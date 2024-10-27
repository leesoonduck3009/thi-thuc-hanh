using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Entities;

namespace TestWebApplication.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
        }
    }
}
