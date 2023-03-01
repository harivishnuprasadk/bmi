using BmiApp.Models;
using Microsoft.EntityFrameworkCore;
using BmiApp.DataAccess;
using BmiApp.Services;
using BmiApp.Utilities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

//key vault
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//      .AddMicrosoftIdentityWebApi((IConfiguration)secretClient.GetSecret("AzureAd").Value);

builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
{
    var existingOnTokenValidatedHandler = options.Events.OnTokenValidated;
    options.Events.OnTokenValidated = async context =>
    {
        await existingOnTokenValidatedHandler(context);
        options.TokenValidationParameters.ValidIssuers = new[] { "https://login.microsoftonline.com/409a4641-afe8-4ee6-8394-bd437c7af6d6" };
        options.TokenValidationParameters.ValidAudiences = new[] { "api://74c117fd-a8b2-45a9-ad5d-ec7a556b3768" };
    };
});
IdentityModelEventSource.ShowPII = true;

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Bmi Api", Version = "v1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            AuthorizationCode = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri(builder.Configuration["AuthorizationUrl"]),
                TokenUrl = new Uri(builder.Configuration["TokenUrl"]),
                Scopes = new Dictionary<string, string> {
                        {
                            builder.Configuration["ApiScope"],
                            "Access the Api"
                        }
                    }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                },
        },
        new [] {builder.Configuration["ApiScope"] }
    }
});
});



builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiUserRepository, BmiUserRepository>();
builder.Services.AddScoped<IBmiUserHealthRepository, BmiUserHealthRepository>();
builder.Services.AddScoped<IBmiService, BmiService>();
builder.Services.AddScoped<IBmiUserService, BmiUserService>();
builder.Services.AddScoped<IBmiUserHealthService, BmiUserHealthService>();
builder.Services.AddScoped<BmiBlobUtility>();
//builder.Services.AddDbContext<BmiDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var keyVaultEndpoint = new Uri(builder.Configuration["VaultKey"]);
var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());

KeyVaultSecret kvs = secretClient.GetSecret("sqlServerConnStr");
builder.Services.AddDbContext<BmiDbContext>(o => o.UseSqlServer(kvs.Value));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bmi Api v1");

    c.OAuthClientId(builder.Configuration["AzureAd:ClientId"]);

    c.OAuthUsePkce();
    c.OAuthScopeSeparator(" ");
});
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
