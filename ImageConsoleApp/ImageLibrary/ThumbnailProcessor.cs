using ImageLibrary.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary
{
    public interface IThumbnailProcessor
    {
        void processImage(string imagePath);
    }
    public class ThumbnailProcessor : IThumbnailProcessor
    {
        private readonly ILogger<ThumbnailProcessor> _logger;
        private readonly ImageConfig _imageConfig;
        private ImageSizeConfig _thumbnailImageSizeConfig;

        public ThumbnailProcessor(ILogger<ThumbnailProcessor> logger, IOptions<ImageConfig> imageConfigOptions,
            IOptionsMonitor<ImageSizeConfig> imageSizeConfigOptions)
        {
            _logger = logger;
            _imageConfig = imageConfigOptions.Value;
            _thumbnailImageSizeConfig = imageSizeConfigOptions.Get(ImageSizeConfig.Thumbnail);


            imageSizeConfigOptions.OnChange((thumbnailSizeConfig, name) =>
            {
                if (name == nameof(ImageSizeConfig.Thumbnail))
                {
                    _thumbnailImageSizeConfig  = thumbnailSizeConfig;
                }
            });
        }

        public void processImage(string imagePath)
        {
            _logger.LogInformation($"**** processing image: {imagePath} *****");
            _logger.LogInformation($"Compression Level: {_imageConfig.CompressionLevel}");
            _logger.LogInformation($"Output Path: {_imageConfig.OutputPath}");
            _logger.LogInformation($"thumbnail Image Size: {_thumbnailImageSizeConfig.Width}");
            _logger.LogInformation($"thumbnail File Prefix: {_thumbnailImageSizeConfig.FilePrefix}");
            _logger.LogInformation($"thumbnail Watermark Text: {_thumbnailImageSizeConfig.WatermarkText}");
        }
    }
}
