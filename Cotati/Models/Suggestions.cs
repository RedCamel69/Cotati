using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotati.Models
{
    public class Suggestions
    {
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }
        //public string OriginalQuery { get; set; }
        public suggestionGroups[] SuggestionGroups { get; set; }
    }

    public class QueryContext
    {
        public string originalQuery { get; set; }
    }
    public class suggestionGroups
    {
        public string name { get; set; }
        public searchSuggestion[] SearchSuggestions { get; set; }
    }

    public class searchSuggestion
    {
        public string url { get; set; }
        public string displayText { get; set; }
        public string query { get; set; }

    }
}