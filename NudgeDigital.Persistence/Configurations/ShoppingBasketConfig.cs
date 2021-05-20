using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudgeDigital.Domain.Entities;
using NudgeDigital.Persistence.Abstract;

namespace NudgeDigital.Persistence.Configurations
{
    public class ShoppingBasketConfig : BaseConfiguration<ShoppingBasket>
    {
        public override string TableName => "Carts";

        public override void ConfigureEntity(EntityTypeBuilder<ShoppingBasket> entityBuilder)
        {
            
            entityBuilder.Property(x => x.Currency)
                .IsRequired()
                .HasDefaultValue("GBP")
                .HasMaxLength(10);

            entityBuilder.Property(x => x.SessionId)
                .IsRequired()
                .HasMaxLength(50);


        }
    }
}
