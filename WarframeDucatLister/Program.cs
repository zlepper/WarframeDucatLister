using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ImageProcessor;
using ImageProcessor.Imaging;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace WarframeDucatLister
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(() =>
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
            });
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
            t.Join();
//            var warframeDucatLister = new WarframeDucatLister();
//            var rewards = new Bitmap("./rewards.png");
//            var options = warframeDucatLister.GetOptions(rewards);

//            var image = ScreenCapturer.CaptureWarframe();
//            image.Save("./capture.png", ImageFormat.Png);


        }
    }
}
