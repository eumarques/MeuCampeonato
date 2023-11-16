using MeuCampeonato.Application.Commands.Time.CriarTime;
using MeuCampeonato.Core.Entities;
using MeuCampeonato.Core.Repositories;
using MeuCampeonato.Infra;
using MeuCampeonato.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// conexao com a base
var connectionString = builder.Configuration.GetConnectionString("TradeCs");
builder.Services.AddDbContext<MeuCampeonatoDbContext>(options => options.UseSqlServer(connectionString));

//Repository
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Campeonato>, CampeonatoRepository>();
builder.Services.AddScoped<IRepository<Time>, TimeRepository>();

//MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CriarTimeCommand).Assembly));

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
