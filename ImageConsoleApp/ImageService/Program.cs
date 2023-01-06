using ImageService;
using ImageLibrary.Configuration;
using ImageLibrary;
using ImageLibrary.DependencyInjection;

IHostBuilder builder = Host.CreateDefaultBuilder(args);

builder.ConfigureHostConfiguration(host =>
{

});

builder.ConfigureAppConfiguration((hostContext, appConfig) =>
{
    appConfig.AddEnvironmentVariables(prefix: "ImageService_");
});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<ImageFileWatcher>();
    services.AddImageLibrary(hostContext.Configuration);
});

IHost host = builder.Build();

host.Run();
