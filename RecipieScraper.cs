using System.Threading.Tasks;
using HtmlAgilityPack;
using RecipieWebScraper.containers;
using RecipieWebScraper.collectors;
using System;

namespace RecipieWebScraper
{
    class RecipieScrapper
    {
        HtmlWeb web;
        
        public RecipieScrapper()
        {
            web = new HtmlWeb();
        }


        public void ScrapeRecipie(string url)
        {
            var collector = new Collector( new string[]{"bonappetit.com/recipe/"}, "//div[@class='ingredients__text']", "//li[@class='step']");
            if( collector.AllowedURL(url))
            {
                var recipie = collector.GetRecipieFromWebsite(url);
                Console.WriteLine(recipie.name);
                Console.WriteLine(recipie.ingredients[0].fullText);
            }

        }
    }
}