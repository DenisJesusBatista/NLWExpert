using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Configurations;

public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        builder.ToTable("Auction");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
        builder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
        builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(p => p.Starts).HasColumnType("timestamp");
        builder.Property(p => p.Ends).HasColumnType("timestamp(11)");
    }
}
