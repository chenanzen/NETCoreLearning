using ImageLibrary.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddImageLibrary(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IThumbnailProcessor, ThumbnailProcessor>();

            var imageConfig = configuration.GetSection(nameof(ImageConfig));
            services.Configure<ImageConfig>(imageConfig);

            services.AddOptions<ImageConfig>()
                .Configure(imageConfig =>
                {
                    imageConfig.CompressionLevel = 0.99M;
                })
                .Bind(imageConfig);


            services.AddOptions<ImageSizeConfig>(ImageSizeConfig.Thumbnail)
                .Configure(imageSizeConfig =>
                {
                    imageSizeConfig.FilePrefix = "thumb-";
                })
                .Bind(imageConfig.GetSection(ImageSizeConfig.Thumbnail));

            services.Configure<ImageSizeConfig>(ImageSizeConfig.Medium, imageConfig.GetSection(ImageSizeConfig.Medium));
            services.Configure<ImageSizeConfig>(ImageSizeConfig.Large, imageConfig.GetSection(ImageSizeConfig.Large));

            return services;
        }
    }
}
