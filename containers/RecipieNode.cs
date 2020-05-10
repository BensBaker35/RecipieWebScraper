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
    }
}