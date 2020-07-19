using System.Collections.Generic;


namespace RecipieWebScraper.jsonContainers
{
    //[JsonConverter(typeof(DomainSetConverter))]
    class DomainSet
    {
        public List<CollectorSetting> domain_sets { get; set; }
    }
}