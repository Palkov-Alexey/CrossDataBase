using CrossDataBase.Server;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.DependencyInjection;
using ElectronNET.API;

var isElectron = args.Any(a => a.Contains("ELECTRON", StringComparison.CurrentCultureIgnoreCase));

MigrateBuilder.Migration();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });

builder.Services.RegisterByDIAttribute("CrossDataBase.Server.*");

// Electron.NET
if (isElectron)
{
    builder.WebHost.UseElectron(args);
    builder.Services.AddElectron();
}
else
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        var basePath = AppContext.BaseDirectory;
        var xmlPath = Path.Combine(basePath, "CrossDataBase.Server.xml");
        
        options.IncludeXmlComments(xmlPath);
        options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
    });
}

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!isElectron)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

// Создание подключения к БД в памяти
var memory = app.Services.GetService<IMemoryExecutor>();
memory.OpenConnection();

if (HybridSupport.IsElectronActive)
{
    await app.StartAsync();
    await Electron.WindowManager.CreateWindowAsync();

    app.WaitForShutdown();
}
else
{
    app.Run();
    app.Start();
}