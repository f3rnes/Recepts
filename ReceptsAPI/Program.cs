using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.IdentityModel.Tokens;
using ReceptsAPI;
using Microsoft.EntityFrameworkCore;
using ReceptsAPI.Entity;
using ReceptsAPI.AUTH;
using ReceptsAPI.Repository.Repositories;
using ReceptsAPI.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("Stroka");

builder.Services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer(connection));

// Add services to the container.
IConfigurationSection authConfiguration = builder.Configuration.GetSection("AuthOptions");
AuthOptions authOptions = new AuthOptions(
    authConfiguration["ISSUER"] ?? throw new Exception("ISSUER is null!"),
    authConfiguration["AUDIENCE"] ?? throw new Exception("AUDIENCE is null!"),
    authConfiguration["KEY"]) ?? throw new Exception("KEY is null!");
builder.Services.AddSingleton(authOptions);
builder.Services.AddTransient<JwtCreator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authOptions.Issuer,
        ValidateAudience = true,
        ValidAudience = authOptions.Audience,
        ValidateLifetime = true,
        IssuerSigningKey = authOptions.GetSymmetricKey,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IReceptRepository, ReceptRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IStageRepository, StageRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();