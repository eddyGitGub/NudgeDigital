using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudgeDigital.Domain.Common;


namespace NudgeDigital.Persistence.Abstract
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity
    {
        //public virtual string SchemaName { get; } = "dbo";

        public abstract string TableName { get; }
        public virtual string Key { get; } = "Id";

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

        public virtual void Configure(EntityTypeBuilder<TEntity> entityBuilder)
        {
            entityBuilder.HasKey(Key);

            entityBuilder.Property(x => x.Id)
                .HasMaxLength(128)
                .IsRequired();

            ConfigureEntity(entityBuilder);

            entityBuilder.Property(x => x.CreatedDate)
                .IsRequired(); // Use this to append created date to the end of other properties

            entityBuilder.Property(x => x.LastModifiedDate); // Use this to append UpdatedDate to after created date

            entityBuilder.ToTable(TableName);
        }
    }
}
