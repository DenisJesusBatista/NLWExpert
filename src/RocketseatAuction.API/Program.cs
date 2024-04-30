using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Repositories.DataAccess;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Items.CreateItems;
using RocketseatAuction.API.UseCases.Items.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
               Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<ILoggedUser, LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<CreateItemsUseCase>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();

builder.Services.AddScoped<GetCurrentItemUseCase>();
builder.Services.AddScoped<IItemsRepository, ItemRepository>();

builder.Services.AddScoped<IOfferRepository, OfferRepository>(); /* - Inje��o de depend�ncia para IOfferRepository para implementacao do OfferRepository*/
builder.Services.AddScoped<IUseRepository, UseRepository>();

builder.Services.AddDbContext<RocketseatAuctionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("RocketseatConnection"));
    options.UseLazyLoadingProxies();

});


//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Configurando AutoMapper na inje��o de depend�ncia
builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguracao());
}).CreateMapper());

builder.Services.AddFluentMigratorCore().ConfigureRunner(c =>
        c.AddPostgres());

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
