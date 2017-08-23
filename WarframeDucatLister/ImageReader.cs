using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace WarframeDucatLister
{
    class ImageReader : IDisposable
    {
        private TesseractEngine _engine;

        public ImageReader()
        {
            try
            {
                _engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetText(Bitmap image)
        {
            using (var page = _engine.Process(image))
            {
                return page.GetText();
            }
        }


        public void Dispose()
        {
            if (this._engine != null && !this._engine.IsDisposed)
            {
                this._engine.Dispose();
            }
        }
    }
}
