using System.Collections.Generic;
using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace RecipieWebScraper.containers
{
    class RecipieNode
    {
        public List<IngredientNode> ingredients { get; set; }
        public List<DirectionNode> directions { get; set; }
        public string url { get; }
        public string name { get; set; }   

        public RecipieNode( string url )
        {
            ingredients = new List<IngredientNode>();
            directions = new List<DirectionNode>();
            this.url = url;
        }      

        public void CreateIngredientList(HtmlNodeCollection nodes)
        {
            Console.WriteLine(nodes.Count);
            foreach (HtmlNode node in nodes)
            {
                var cleanText = StripWhiteSpaceAndTags(node.InnerText);
                Console.WriteLine($"Text: {cleanText}\n");
                var ingredientNode = new IngredientNode();
                ingredientNode.fullText = cleanText;
                /*
                var tokens = node.InnerText.Split(" ");
                foreach(string str in tokens)
                {
                     
                }
                */
            }
        }


        private string StripWhiteSpaceAndTags(string text)
        {
            var charsToRemove = @"[\n\t\r\v]";
            var cleanText = Regex.Replace(text, charsToRemove, "");
            return cleanText;
        }
    }
}