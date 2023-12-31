using FluentValidation;
using FluentValidation.AspNetCore;
using MeuCampeonato.API.Filters;
using MeuCampeonato.Application.Commands.Time.CriarTime;
using MeuCampeonato.Application.Services;
using MeuCampeonato.Application.Validators.User;
using MeuCampeonato.Core.Entities;
using MeuCampeonato.Core.Interface.Repositories;
using MeuCampeonato.Infra;
using MeuCampeonato.Infra.Auth;
using MeuCampeonato.Infra.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//FluentValidator
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<UserCommandValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// conexao com a base
var connectionString = builder.Configuration.GetConnectionString("TradeCs");
builder.Services.AddDbContext<MeuCampeonatoDbContext>(options => options.UseSqlServer(connectionString));

//Repository
builder.Services.AddScoped<IRepository<Campeonato>, CampeonatoRepository>();
builder.Services.AddScoped<IRepository<Time>, TimeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


//MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CriarTimeCommand).Assembly));

//Service
builder.Services.AddScoped<IAuthService, AuthService>();

//Configuracao do Authorize
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeuCampeonato.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}
                     }
                 });
});

// configuracao do jwt 
builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,

          ValidIssuer = builder.Configuration["Jwt:Issuer"],
          ValidAudience = builder.Configuration["Jwt:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
      };
  });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
