using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    public RocketseatAuctionDbContext(DbContextOptions options) : base(options)
    {
        IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

        _connectionString = configuration.GetConnectionString("RocketseatConnection");
    } /*Construtor para classe RocketseatAuctionDbContext*/

    public DbSet<Auction> Auction { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; } /*Teste*/

    public DbSet<Item>? items { get; set; }

    private readonly string _connectionString;



    //public RocketseatAuctionDbContext()
    //{
    //    IConfiguration configuration = new ConfigurationBuilder()
    //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //        .AddJsonFile("appsettings.json")
    //        .Build();

    //    _connectionString = configuration.GetConnectionString("RocketseatConnection");

    //}

    //public RocketseatAuctionDbContext(string _connectionString)
    //{
    //    _connectionString = _connectionString ?? throw new ArgumentNullException();

    //}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /*Responsavel em fazer a configuraçoes necessaria para fazer a 
      * conexão da variavel com as tabelas*/
        builder.ApplyConfigurationsFromAssembly(typeof(RocketseatAuctionDbContext).Assembly);     



    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }


}
