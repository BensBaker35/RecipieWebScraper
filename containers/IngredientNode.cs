namespace RecipieWebScraper.containers
{
    public enum MeasurmentTypes
    {
       CUPS, TBSPOON, TEASPOON, GRAMS, OTHER
    }

    class IngredientNode
    {
        public MeasurmentTypes measurmentTypes { get; }
        public double measuremntAmount { get; }
        public string ingredientName { get; }
        public string fullText { get; set;}
        
    }
}