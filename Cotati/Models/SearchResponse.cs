using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotati.Models
{
    public class SearchResponse
    {
        public string SearchRequest { get; set; }

        public string type { get; set; }

        public WebPages webpages { get; set; }

    }

    public class WebPages
    {
        public string WebsearchUrl { get; set; }
        public int TotalEstimates { get; set; }

        public WebPage[] Value { get; set; }
    }

    public class WebPage
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DisplayUrl { get; set; }

        public string Snippet { get; set; }

        public string Url { get; set; }
    }
}