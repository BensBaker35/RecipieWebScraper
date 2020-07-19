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
    /// <summary>
    /// A class that holds necessary functions to gather information from websites
    /// </summary>
    /// <remarks>
    /// Could possibly become a singleton class
    /// </remarks>
    class RecipieScrapper
    {
        
        HtmlWeb web;
        string domainsFP;
        List<Collector> collectors;
        
        /// <summary>
        /// RecipieScraper Constructor
        /// </summary>
        public RecipieScrapper()
        {
            web = new HtmlWeb();
            domainsFP = @"./domains.json";
        }

        /// <summary>
        /// Initalizes the scraper and creates necessary collectors
        /// </summary>
        public void InitializeScraper()
        {
            collectors = CreateCollectors(domainsFP);
        }

        /// <summary>
        /// Creates collectors with specified settings from domains.json
        /// </summary>
        /// <param name="domainFilePath">the location of domains.json</param>
        /// <returns>The list of available collectors for the scraper to use</returns>
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
        
        /// <summary>
        /// Attempts to scrape the recipie from a url
        /// </summary>
        /// <param name="url">The url given through input</param>
        /// <returns>The recipie node containing all pertanent information, null if url is not correct</returns>
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