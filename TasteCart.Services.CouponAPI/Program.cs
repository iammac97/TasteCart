using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasteCart.Services.CouponAPI;
using TasteCart.Services.CouponAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//config the db 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//add servive for mapper configuration
IMapper mapper =MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

//now adding te pipeline to trigger the migration method
ApplyMigration();

app.Run();


//Creating a method to trigger the update db if any pending migration
//it will auto trigger if the application restarted
void ApplyMigration()
{
    using(var scope=app.Services.CreateScope())
    {
        var _db=scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if(_db .Database.GetPendingMigrations().Count()>0)
        {
            _db.Database.Migrate();
        }
    }
}