using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    public RocketseatAuctionDbContext(DbContextOptions options) : base(options) { } /*Construtor para classe RocketseatAuctionDbContext*/
    public DbSet<Auction> Auction { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; } /*Teste*/

    public DbSet<Item>? items { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /*Responsavel em fazer a configuraçoes necessaria para fazer a 
      * conexão da variavel com as tabelas*/
        builder.ApplyConfigurationsFromAssembly(typeof(RocketseatAuctionDbContext).Assembly);

        //builder.Entity<Item>(e =>
        ////{
        ////    e.HasKey(i => i.Id);

        ////    e.Property(i => i.BasePrice)
        ////    .HasColumnType("decimal(18,4)");

        //    //e.HasMany(i => i.Id)
        //    //.WithOne()
        //    //.HasForeignKey(i => i.AuctionId)
        //    //.OnDelete(DeleteBehavior.Restrict);
        //});



    }


}
