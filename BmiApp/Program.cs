using BmiApp.Models;
using Microsoft.EntityFrameworkCore;
using BmiApp.DataAccess;
using BmiApp.Services;
using BmiApp.Utilities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiUserRepository, BmiUserRepository>();
builder.Services.AddScoped<IBmiUserHealthRepository, BmiUserHealthRepository>();
builder.Services.AddScoped<IBmiService, BmiService>();
builder.Services.AddScoped<IBmiUserService, BmiUserService>();
builder.Services.AddScoped<IBmiUserHealthService, BmiUserHealthService>();
builder.Services.AddScoped<BmiBlobUtility>();
builder.Services.AddDbContext<BmiDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAD"));
//var keyVaultEndpoint = new Uri(builder.Configuration["VaultKey"]);
//var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());
//KeyVaultSecret kvs = secretClient.GetSecret("SqlServer");
//builder.Services.AddDbContext<BmiDbContext>(o => o.UseSqlServer(kvs.Value));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection(); 

app.UseAuthorization();
//app.UseAuthentication();
app.MapControllers();

 app.Run();
