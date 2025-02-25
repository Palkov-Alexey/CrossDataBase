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
    var isElectron = args.Any(a => a.Contains("ELECTRON", StringComparison.CurrentCultureIgnoreCase));
    MigrateBuilder.Migration();

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();

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
        builder.Services.AddSwaggerGen();
        // builder.Services.AddSwaggerGen(options =>
        // {
        //     options.SwaggerDoc("v1", new OpenApiInfo
        //     {
        //         Version = "v1",

        //     })

        // });
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

    // app.Services.GetService<IProcessHistoryDbWriter>();

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
}
catch (Exception ex)
{
    logger.LogError(JsonConvert.SerializeObject(ex));
    Environment.Exit(0);
}
