using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotati.Models
{
    public class News
    {
        public string _type { get; set; }
        public int totalEstimatedMatches { get; set; }

        public Value[] value { get; set; }
    }

    public class Value
    {
        public DateTime datePublished { get; set; }
        public string category { get; set; }

        public string name { get; set; }

        public string url { get; set; }

        public string description { get; set; }

        public About[] about { get; set; }

        public Provider[] provider { get; set; }

        public Image image { get; set; }

        public Video video { get; set; }
    }


    public class About
    {
        public string readLink { get; set; }
        public string name { get; set; }
    }

    public class Provider
    {
        public string _type { get; set; }
        public string name { get; set; }
    }

    public class Video
    {
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public string allowHttpsEmbed { get; set; }

        public ThumbNail thumbnail { get; set; }

    }

    public class Image
    {
        public string contentURl { get; set; }

        public ThumbNail thumbnail { get; set; }
    }

    public class ThumbNail
    {
        public string contentUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}