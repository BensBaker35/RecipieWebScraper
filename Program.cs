using System;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace RecipieWebScraper
{
    class Program
    {

        static void Main(string[] args)
        {
            //var url = "https://www.delish.com/cooking/recipe-ideas/a25137966/pan-fried-tilapia-recipe/";
            var url = "https://www.bonappetit.com/recipe/ricotta-gnocchi";
            var recipeScraper = new RecipieScrapper();
            
            recipeScraper.ScrapeRecipie(url);

            
        }

    }
}
