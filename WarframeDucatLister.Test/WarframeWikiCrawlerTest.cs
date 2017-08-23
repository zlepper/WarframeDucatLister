using System;
using NUnit.Framework;

namespace WarframeDucatLister.Test
{
    [TestFixture]
    public class WarframeWikiCrawlerTest
    {
        [Test]
        public void GetDucatPrices()
        {
            var warframeDucatLister = new WarframeWikiCrawler();
            var ducatPrices = warframeDucatLister.GetDucatPrices();
            foreach (var primeDucatItem in ducatPrices)
            {
                Console.WriteLine(primeDucatItem);
            }
        }
    }
}