using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace WarframeDucatLister.Test
{
    [TestFixture]
    public class ocr_test
    {
        private WarframeDucatLister _warframeDucatLister;

        [SetUp]
        public void setup()
        {
            _warframeDucatLister = new WarframeDucatLister();
        }

        [Test]
        public void TwoLineOcrTest()
        {
            var image = Image.FromFile("C:\\Users\\hanse\\Documents\\Visual Studio 2015\\Projects\\WarframeDucatLister\\WarframeDucatLister\\bin\\Debug\\b6287094-7a8a-40c7-ac79-1f1bbe98bac6.png");
            var options = _warframeDucatLister.GetOptions(image);

            Assert.Contains("fang prime handle", options);
            Assert.Contains("forma blueprint", options);
            Assert.Contains("valkyr prime neuroptics blueprint", options);
            Assert.Contains("bronco prime blueprint", options);
        }

        [Test]
        public void OneLineOcrTest()
        {
            var image = Image.FromFile(
                "C:\\Users\\hanse\\Documents\\Visual Studio 2015\\Projects\\WarframeDucatLister\\WarframeDucatLister\\bin\\Debug\\941a5c85-7603-4826-8b86-85412b9637f8.png");
            var options = _warframeDucatLister.GetOptions(image);

            Assert.Contains("galatine prime blade", options);
            Assert.Contains("forma blueprint", options);
            Assert.Contains("saryn prime systems blueprint", options);
            Assert.Contains("paris prime grip", options);
        }
    }
}