using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudgeDigital.Domain.Entities;
using NudgeDigital.Persistence.Abstract;

namespace NudgeDigital.Persistence.Configurations
{
    public class ConfigurationConfig : BaseConfiguration<Domain.Entities.Configuration>
    {
        public override string TableName => "Configurations";

        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Configuration> entityBuilder)
        {
            entityBuilder.Property(x => x.ComponentType)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
