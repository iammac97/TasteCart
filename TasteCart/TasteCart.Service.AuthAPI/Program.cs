using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasteCart.Services.AuthAPI.Models;
using TasteCart.Services.AuthAPI.Data;
using TasteCart.Service.AuthAPI.Models;
using TasteCart.Service.AuthAPI.Service.IService;
using TasteCart.Service.AuthAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//config the db 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//configure JWT token authentication

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
//configure to use identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddScoped<IAuthService, AuthService>(); 
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
//It's always used before the Authorization
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
ApplyMigration();

app.Run();

//Creating a method to trigger the update db if any pending migration
//it will auto trigger if the application restarted
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}