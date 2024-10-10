using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Core.Migrations;
using CrossDataBase.Server.Infrastructure.DependencyInjection;

MigrateBuilder.Migration();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",

//    })
//});

builder.Services.RegisterByDIAttribute("CrossDataBase.Server.*");

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Services.GetService<IDbWriter>();

app.Run();
