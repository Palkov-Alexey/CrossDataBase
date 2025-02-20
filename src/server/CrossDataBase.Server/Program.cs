using CrossDataBase.Server;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Infrastructure.DependencyInjection;
using ElectronNET.API;
using Newtonsoft.Json;

var logger = LoggerFactory
    .Create(configure => configure.AddConsole())
    .CreateLogger<Program>();

try
{
    MigrateBuilder.Migration();

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();
    //builder.Services.AddSwaggerGen(options =>
    //{
    //    options.SwaggerDoc("v1", new OpenApiInfo
    //    {
    //        Version = "v1",

    //    })
    //});

    // builder.Services.RegisterByDIAttribute("CrossDataBase.Server.*");

    // Electron.NET
    builder.WebHost.UseElectron(args);
    builder.Services.AddElectron();

    var app = builder.Build();

    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Configure the HTTP request pipeline.
    // app.UseSwagger();
    // app.UseSwaggerUI();

    app.UseAuthorization();

    app.MapControllers();

    app.MapFallbackToFile("/index.html");

    // app.Services.GetService<IProcessHistoryDbWriter>();

    //app.Run();
    await app.StartAsync();
    await Electron.WindowManager.CreateWindowAsync();

    app.WaitForShutdown();
}
catch (Exception ex)
{
    logger.LogError(JsonConvert.SerializeObject(ex));
}
finally
{
    Environment.Exit(0);
}

