using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudgeDigital.Domain.Entities;
using NudgeDigital.Persistence.Abstract;

namespace NudgeDigital.Persistence.Configurations
{
    public class BrandConfig : BaseConfiguration<Brand>
    {
        public override string TableName => "Brands";

        public override void ConfigureEntity(EntityTypeBuilder<Brand> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

           
        }
    }
}
