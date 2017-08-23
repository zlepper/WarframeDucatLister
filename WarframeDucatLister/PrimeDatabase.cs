using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarframeDucatLister
{
    class PrimeDatabase
    {
        private readonly List<PrimeDucatItem> _ducatPrices;

        public PrimeDatabase()
        {
            _ducatPrices = new WarframeWikiCrawler().GetDucatPrices();
        }

        public List<PrimeItem> GetPrimeItems(List<string> names)
        {
            return names.Select(GetPrimeItem).ToList();
        }

        public PrimeItem GetPrimeItem(string name)
        {
            name = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            var ducatItem = _ducatPrices.FirstOrDefault(item => item.HasName(name));
            if (ducatItem != null)
            {
                return new PrimeItem()
                {
                    name = name,
                    ducatPrice = ducatItem.value
                };
            }
            return new PrimeItem() {name = name, ducatPrice = 0};
        }
    }
}
