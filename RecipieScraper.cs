using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using RecipieWebScraper.containers;
using RecipieWebScraper.collectors;
using RecipieWebScraper.jsonContainers;
using Newtonsoft.Json;

namespace RecipieWebScraper
{
    class RecipieScrapper
    {
        HtmlWeb web;
        string domainsFP;
        List<Collector> collectors;
        
        public RecipieScrapper()
        {
            web = new HtmlWeb();
            domainsFP = @"./domains.json";
        }

        public void InitializeScraper()
        {
            collectors = CreateCollectors(domainsFP);
        }

        List<Collector> CreateCollectors( string domainFilePath)
        {
            var collectors = new List<Collector>();
            using(StreamReader file = File.OpenText(domainFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                var domainset = (DomainSet)serializer.Deserialize(file, typeof(DomainSet));
                foreach(var s in domainset.domain_sets)
                {
                    var collector = new Collector(s.allowed_domains, 
                        s.ingredient_path, s.direction_path);
                    collectors.Add(collector);
                }
            }
            return collectors;
        }
        
        public RecipieNode ScrapeRecipie(string url)
        {
            
            foreach(var collector in collectors)
            {
                if( collector.AllowedURL(url))
                {
                    var recipie = collector.GetRecipieFromWebsite(url);
                    //Console.WriteLine(recipie.name);
                    //Console.WriteLine(recipie.ingredients[0].fullText);
                    return recipie;
                }  
            }
            Console.Error.WriteLine("Not a valid domain");
            return null;

        }
    }
}