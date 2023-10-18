using Api.Produit.Data.Context.Contract;
//using Api.ProduitStore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Api.Produit.Data.Repository;
using Api.Produit.Business.Service;
using Api.Produit.Data.Entity;
using Api.Produit.Data.Repository.Contract;
using Api.Produit.Business.Service.Contract;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Connexion à la base de données
string connectionString = configuration.GetConnectionString("BddConnection");
builder.Services.AddDbContext<IProduitDbContext, PrdoduitDBContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

//IOC des repositories
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();

//IOC des services
builder.Services.AddScoped<IProduitService, ProduitService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
