using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConsoleApp
{
    internal class ImageConfig
    {
        public ImageSizeConfig Thumbnail { get; set; }
        public ImageSizeConfig Medium { get; set; }
        public ImageSizeConfig Large { get; set; }
        public decimal CompressionLevel { get; set; }
    }

    internal class ImageSizeConfig
    {
        public int Width { get; set; }
        public string FilePrefix { get; set; } = string.Empty;
        public string WatermarkText { get; set; } = string.Empty;
    }
}
