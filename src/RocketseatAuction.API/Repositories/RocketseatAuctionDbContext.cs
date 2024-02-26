using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext: DbContext
{
    public RocketseatAuctionDbContext(DbContextOptions options): base(options) { } /*Construtor para classe RocketseatAuctionDbContext*/
    public DbSet<Auction>? Auctions { get; set; }   
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; } /*Teste*/

    public DbSet<Item>? items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();
    }


}
