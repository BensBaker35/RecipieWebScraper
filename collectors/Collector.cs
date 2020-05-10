using System.Collections.Generic;
using System.Threading.Tasks;
using RecipieWebScraper.containers;
using HtmlAgilityPack;
namespace RecipieWebScraper.collectors
{
    class Collector
    {
        string[] allowedDomains;
        string ingredientPath;
        string directionPath;

        
        public Collector(string[] allowedDomains, string ingredientPath, string directionPath)
        {
            this.allowedDomains = allowedDomains;
            this.ingredientPath = ingredientPath;
            this.directionPath = directionPath;
        }

        public bool AllowedURL( string inputDomain)
        {
            foreach(string str in allowedDomains)
            {
                if(str.Equals(inputDomain))
                {
                    return true;
                }
            }
            return false;
        }

        List<IngredientNode> GetIngredients(HtmlNode documentNode)
        {
            var nodes = documentNode.SelectNodes(ingredientPath);
            var ingredients = new List<IngredientNode>();
            foreach(var node in nodes)
            {
                var ingredient = new IngredientNode();
                ingredient.fullText = node.InnerText;
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
        List<DirectionNode> GetDirections(HtmlNode documentNode)
        {
            return null;
        }

        public RecipieNode GetRecipieFromWebsite(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var recipie = new RecipieNode(url);
            recipie.ingredients = GetIngredients( doc.DocumentNode);
            recipie.directions = GetDirections(doc.DocumentNode);
            recipie.name = doc.DocumentNode.SelectSingleNode("//html/head/title").InnerText;

            return recipie;
        }
    }
}