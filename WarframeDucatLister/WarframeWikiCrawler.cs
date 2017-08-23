using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Controls;
using System.Windows.Documents;
using HtmlAgilityPack;
using static System.Text.RegularExpressions.Regex;

namespace WarframeDucatLister
{
    public class WarframeWikiCrawler
    {
        private const string DucatPriceListUrl = "http://warframe.wikia.com/wiki/Ducats/Prices";

        public List<PrimeDucatItem> GetDucatPrices()
        {
            var request = HttpWebRequest.Create(DucatPriceListUrl);
            request.Method = WebRequestMethods.Http.Get;

            var doc = new HtmlDocument();
            doc.Load(request.GetResponse().GetResponseStream());
            if (doc.ParseErrors != null && doc.ParseErrors.Any())
            {
                foreach (var htmlParseError in doc.ParseErrors)
                {
                    Debug.WriteLine(htmlParseError);
                }
            }

            var tableRows =
                doc.DocumentNode.SelectNodes("//div[@id='mw-customcollapsible-ducatsprices']/table/tr").Skip(1);

            return tableRows.Select(row =>
            {
                string name = row.SelectSingleNode("td/a[2]").InnerText;
                string amount = row.SelectSingleNode("td[3]").InnerText.Trim();
                amount = Match(amount, "\\d*").Value;
                int value = int.Parse(amount);
                return new PrimeDucatItem()
                {
                    name = name,
                    value = value
                };
            }).ToList();
        }
    }

    public class PrimeDucatItem
    {
        public string name { get; set; }
        public int value { get; set; }

        public override string ToString()
        {
            return $"{nameof(name)}: {name}, {nameof(value)}: {value}";
        }

        public bool HasName(string n)
        {
            n = n.ToLower().Replace("blueprint", "").Trim();
            return name.ToLower().Replace("blueprint", "").Trim().Equals(n, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}