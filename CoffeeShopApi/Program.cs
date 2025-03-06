using CoffeeShopDataLayer;
using CoffeeShopBusinessLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<CoffeeShopDbContext>(options =>
    options.UseSqlite("Data Source=coffeeshops.db"));
builder.Services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();


// Register Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Perform Database Migration and Seeding
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CoffeeShopDbContext>();
    await dbContext.Database.MigrateAsync();

    var seeder = new DatabaseSeeder(dbContext);
    await seeder.SeedDatabaseAsync();
}

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
