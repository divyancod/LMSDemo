using KAMLMSBackend.Authentication;
using KAMLMSRepository;
using KAMLMSRepository.Interfaces;
using KAMLMSRepository.Repositories;
using KAMLMSService.Interfaces;
using KAMLMSService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KAMLMSDbString")));
builder.Services.AddScoped<ILeadsRepository, LeadsRepository>();
builder.Services.AddScoped<ILeadsService, LeadsService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IContanctRepository, ContactRepository>();
builder.Services.AddScoped<IContactsManagementService, ContactsManagementService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<JWTTokenHandler, JWTTokenHandler>();
builder.Services.AddScoped<IDataControlService, DataControlService>();


builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localhost",
            ValidAudience = "localhost",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Gj8PoW8SyfxTn3K7gICaexvToVse/eyqs9zbt8jzcJA="))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7076", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetPreflightMaxAge(TimeSpan.FromMinutes(5));
        });
});


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
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetPreflightMaxAge(TimeSpan.FromMinutes(5));
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
