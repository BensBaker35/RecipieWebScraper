using System;
using HtmlAgilityPack;
using RecipieWebScraper.containers;

namespace RecipieWebScraper
{
    /// <summary>
    /// The main entry point for the console version of recipie web scraper
    /// </summary>
    class Program
    {

        /// <summary>
        /// The main function
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            //var url = "https://www.delish.com/cooking/recipe-ideas/a25137966/pan-fried-tilapia-recipe/";
            //var url = "https://www.bonappetit.com/recipe/ricotta-gnocchi";
            Console.Write("Enter URL of Recipie: ");
            var url = Console.ReadLine();
            
            var recipeScraper = new RecipieScrapper();
            
            recipeScraper.InitializeScraper();
            var recipieData = recipeScraper.ScrapeRecipie(url);

            if(recipieData == null)
            {
                Console.WriteLine("Please try a URL from one of the valid websites");
                return;
            }

            Console.WriteLine("========================================");
            Console.WriteLine($"{recipieData.name}");
            Console.WriteLine("========================================");
            PrintIngredientList(recipieData);
            PrintInstructionLIst(recipieData);
        }

        /// <summary>
        /// Prints recipie ingredients to stdout
        /// </summary>
        /// <param name="recipieNode">The information container for given recipie</param>
        static void PrintIngredientList(RecipieNode recipieNode)
        {
            Console.WriteLine("Ingredient List");
            Console.WriteLine("---------------------------");

            var ingredientList = recipieNode.ingredients;
            foreach (var ingredient in ingredientList)
            {
                Console.WriteLine(ingredient.fullText);
            }

            Console.WriteLine("---------------------------");
        }

        /// <summary>
        /// Prints recipie instructions to stdout
        /// </summary>
        /// <param name="recipieNode">The information container for given recipie</param>
        static void PrintInstructionLIst(RecipieNode recipieNode)
        {
            Console.WriteLine("Instruction List");
            Console.WriteLine("---------------------------");

            var instructionList = recipieNode.directions;
            foreach( var instruction in instructionList )
            {
                Console.WriteLine(instruction.directions);
            }

            Console.WriteLine("---------------------------");
        }

    }
}
