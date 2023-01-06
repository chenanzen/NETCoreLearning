using ImageConsoleApp;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

Dictionary<string, string> switchMapping = new Dictionary<string, string>()
{
    { "--thumbnailWidth", "thumbnail:Width"},
    { "--cl", "compressionLevel"}
};

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .AddCommandLine(args, switchMapping)
    .Build();

Console.WriteLine("****** Processing Image *****");
Console.WriteLine($"Processing: {args[0]}");

ImageConfig imageConfig = new ImageConfig()
{
    CompressionLevel = 0.99M
};
config.GetSection(nameof(imageConfig)).Bind(imageConfig);

processImage("thumbnail", imageConfig.Thumbnail, imageConfig.CompressionLevel);
processImage("medium", imageConfig.Medium, imageConfig.CompressionLevel);
processImage("large", imageConfig.Large, imageConfig.CompressionLevel);

Console.WriteLine($"Watermark Text: {config["watermarkText"]}");
Console.WriteLine($"Compression Level: {config["compressionLevel"]}");

static void processImage(string imageSize, ImageSizeConfig config, decimal compressionLevel)
{
    Console.WriteLine($"{imageSize} Width: {config.Width}");
    Console.WriteLine($"{imageSize} File Prefix: {config.FilePrefix}");
    Console.WriteLine($"{imageSize} Watermark: {config.WatermarkText}");
    Console.WriteLine($"{imageSize} Compression: {compressionLevel}");
}