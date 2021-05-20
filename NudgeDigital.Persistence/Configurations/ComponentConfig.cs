using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudgeDigital.Domain.Entities;
using NudgeDigital.Persistence.Abstract;

namespace NudgeDigital.Persistence.Configurations
{
    public class ComponentConfig : BaseConfiguration<Component>
    {
        public override string TableName => "Components";

        public override void ConfigureEntity(EntityTypeBuilder<Component> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            
        }
    }
}
