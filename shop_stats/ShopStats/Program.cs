using Mapster;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using ShopStats;
using ShopStats.Contexts;
using ShopStats.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Default"),
        new MySqlServerVersion(new Version(8, 0, 42))));

builder.Services.AddMapster();

builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IShopService, ShopService>();

//MappingConfig.RegisterMappings();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHttpMetrics();
app.UseMetricServer();

app.UseAuthorization();
app.MapControllers();

app.Run();

