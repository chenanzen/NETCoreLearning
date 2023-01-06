using ImageLibrary;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageService
{
    internal class ImageFileWatcher : IHostedService, IDisposable
    {
        private readonly ILogger<ImageFileWatcher> _logger;
        private readonly IConfiguration _configuration;
        private readonly IThumbnailProcessor _thumbnailProcessor;
        private FileSystemWatcher _watcher;

        public ImageFileWatcher(ILogger<ImageFileWatcher> logger, IConfiguration configuration, 
            IThumbnailProcessor thumbnailProcessor)
        {
            _logger = logger;
            _configuration = configuration;
            _thumbnailProcessor = thumbnailProcessor;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Image File Watcher started: {_configuration["watchPath"]}");
            _watcher = new FileSystemWatcher(_configuration["watchPath"]);
            _watcher.Created += OnNewImage;
            _watcher.EnableRaisingEvents = true;

            return Task.CompletedTask;
        }

        private void OnNewImage(object sender, FileSystemEventArgs e)
        {
            _thumbnailProcessor.processImage(e.FullPath);
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Image File Watcher Stopped.");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Image File Watcher disposing");
            _watcher.Dispose();
        }
    }
}
