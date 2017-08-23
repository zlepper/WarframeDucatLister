using System;
using System.Collections.Generic;
using System.Drawing;
using ImageProcessor;

namespace WarframeDucatLister
{
    public class WarframeDucatLister : IDisposable
    {
        private const int TextWidth = 415;
        private const int TextHeight = 35;
        private const int TextTop = 455;

        private readonly Rectangle[] _rects =
        {
            new Rectangle(105, TextTop, TextWidth, TextHeight),
            new Rectangle(540, TextTop, TextWidth, TextHeight),
            new Rectangle(970, TextTop, TextWidth, TextHeight),
            new Rectangle(1400, TextTop, TextWidth, TextHeight),
        };

        private readonly ImageReader _imageReader;

        public WarframeDucatLister()
        {
            _imageReader = new ImageReader();
        }

        public List<string> GetOptions(Image image)
        {
            var options = new List<string>();
            for (var i = 0; i < 4; i++)
            {
                var rect = _rects[i];
                using (var imageFactory = new ImageFactory())
                {
                    var treated = imageFactory.Load(image)
                        .Crop(rect)
                        .ReplaceColor(Color.FromArgb(147,104,55), Color.White, 50)
                        .Contrast(70)
                        .Image;

                    var text = _imageReader.GetText(new Bitmap(treated)).Replace("\n", "");
                    options.Add(text);
                }
            }
            return options;
        }

        public Image GetScreenshot()
        {
            return ScreenCapturer.CaptureWarframe();
        }

        public void Dispose()
        {
            _imageReader.Dispose();
        }
    }
}