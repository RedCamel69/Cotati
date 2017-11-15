using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cotati.Models;
using System.Net;
using System.IO;

namespace Cotati.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Search")]
    public class SearchController : Controller
    {
        // GET: api/Search
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Search/5
        //[HttpGet("{term}", Name = "Get")]
        //public IActionResult Get(string term)
        //{
        //    return Ok("grrr");
        //}


        // Used to return search results including relevant headers
        struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }



        // GET: api/Search/5
        //[ProducesResponseType(typeof(SearchResponse))]
        [HttpGet("{searchTerm}", Name = "Get")]
        public IActionResult Get(string searchTerm)
        {


            // Replace the accessKey string value with your valid access key.
            //const string accessKey = "a6672d48b53f4ad9a37fd7b332a88818";
            const string accessKey = "509b0bba9b624d8083f078826958b2a9";
            

            // Verify the endpoint URI.  At this writing, only one endpoint is used for Bing
            // search APIs.  In the future, regional endpoints may be available.  If you
            // encounter unexpected authorization errors, double-check this value against
            // the endpoint for your Bing Web search instance in your Azure dashboard.
            const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";

            //searchTerm = "mindfulness in fovant";

            // Construct the URI of the search request
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchTerm) + "&mkt=en-gb";

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // Create result object for return
            var searchResult = new SearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };

            // Extract Bing HTTP headers
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    searchResult.relevantHeaders[header] = response.Headers[header];
            }


            var res2 = searchResult.jsonResult;

            string res = @"{
          '_type': 'SearchResponse',
          'webPages': {
            'webSearchUrl': 'https://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=GnLCoN3BDIPgRA-3rxe8LmUVIV3jNg8VNdI3OvjoHrs&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bfovant&p=DevEx,5276.1',
            'totalEstimatedMatches': 4880,
            'value': [
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.0',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-23T10:39:00',
                'about': null,
                'name': 'MyBreathingSpace.net',
                'url': 'http://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=GIHR1Na55ZAz3WdwVgLv865H1KLUhu6qUTvsNWeImyg&v=1&r=http%3a%2f%2fmybreathingspace.net%2f&p=DevEx,5063.1',
                'displayUrl': 'mybreathingspace.net',
                'snippet': 'Description of <b>Mindfulness</b> practice and training in <b>Fovant</b> on the Wiltshire / Dorset border.'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.1',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-07T09:25:00',
                'about': null,
                'name': '<b>Yoga</b> Classes and <b>Yoga</b> Teachers in <b>Fovant</b> - <b>Yoga</b> Hub',
                'url': 'https://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=Pr-hSkClfLLrXia-P2ZyrXVu_XI9REOY9j1k-t0dnv4&v=1&r=https%3a%2f%2fwww.yogahub.co.uk%2flocation%2funited-kingdom%2fwiltshire%2ffovant%2fpage%2f2%2f&p=DevEx,5076.1',
                'displayUrl': 'https://www.<b>yoga</b>hub.co.uk/location/united-kingdom/wiltshire/<b>fovant</b>/...',
                'snippet': '<b>Fovant</b>; <b>Yoga - Fovant</b> ... Or are you exploring <b>yoga</b> for yourself? I teach Hatha <b>yoga</b> and <b>mindfulness</b>. I am registered with the Independent <b>Yoga</b> . Rating:'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.2',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-16T22:48:00',
                'about': null,
                'name': 'Find an NLP practitioner <b>in Fovant | NaturalTherapyForAll</b>',
                'url': 'http://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=bgazu3M3fOgptI8GvqCQIWAyohuNefFjeBDGmjhZDbY&v=1&r=http%3a%2f%2fwww.naturaltherapyforall.com%2fFind-a%2fNLP%2fin%2ffovant&p=DevEx,5088.1',
                'displayUrl': 'www.naturaltherapyforall.com/Find-a/NLP/in/<b>fovant</b>',
                'snippet': 'Find an affordable qualified NLP (Neuro Linguistic Programming) practitioner in <b>Fovant</b>, Search local NLP practitioners by postcode or fill out an enquiry form to get ...'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.3',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-18T12:51:00',
                'about': null,
                'name': '<b>Fovant Badges | Swindon Link</b>',
                'url': 'https://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=oeN1Zp1UYNXvK6tHB4Lwd-rVJIzoUaZl-KNnVNxuH68&v=1&r=https%3a%2f%2fswindonlink.com%2ftag%2ffovant-badges%2f&p=DevEx,5104.1',
                'displayUrl': 'https://swindonlink.com/tag/<b>fovant</b>-badges',
                'snippet': 'Swindon Link is part of Positive Media Group Ltd – an Excalibur Group company. Established in 1978, we are Swindon’s largest free news publication, in print and ...'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.4',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-16T01:28:00',
                'about': null,
                'name': '<b>Yoga</b> Classes and <b>Yoga</b> Teachers in <b>Fovant</b> - <b>Yoga</b> Hub',
                'url': 'https://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=DAM_c6rxnlXM84pWNg5rUQT6FQ-SB7ZDrtW68Zv6-d8&v=1&r=https%3a%2f%2fwww.yogahub.co.uk%2flocation%2funited-kingdom%2fwiltshire%2ffovant%2fpage%2f4%2f&p=DevEx,5117.1',
                'displayUrl': 'https://www.<b>yoga</b>hub.co.uk/location/united-kingdom/wiltshire/<b>fovant</b>/...',
                'snippet': '<b>Fovant</b>; <b>Yoga - Fovant Fovant</b> is a medium-sized village and civil parish in southwest Wiltshire, England. It is located between Salisbury and Shaftesbury on the A30 ...'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.5',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-17T18:56:00',
                'about': null,
                'name': '<b>Loft Conversion Specialists in Fovant, Salisbury</b> - Find ...',
                'url': 'https://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=8LJoZDb7KvWgOtBiu0ESaQzpe1AcAudaly2MwdJOF7g&v=1&r=https%3a%2f%2fwww.mybuilder.com%2floft-conversion-specialists%2fsalisbury%2ffovant&p=DevEx,5131.1',
                'displayUrl': 'https://www.mybuilder.com/loft-conversion-specialists/salisbury/<b>fovant</b>',
                'snippet': 'Find <b>Loft Conversion Specialists in Fovant, Salisbury</b> MyBuilder has thousands of quality, reliable Loft Conversion Specialists. We screen our trade members and every ...'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.6',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-20T03:26:00',
                'about': null,
                'name': '<b>Pages from Our History by the People</b> of <b>Fovant</b> | Waterstones',
                'url': 'https://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=VzGznJKpuC3Q2O4swOyAhMxeoL7gdG7w_0W1cQIWBYw&v=1&r=https%3a%2f%2fwww.waterstones.com%2fbook%2fpages-from-our-history-by-the-people-of-fovant%2f9780946418398&p=DevEx,5144.1',
                'displayUrl': 'https://www.waterstones.com/book/<b>pages-from-our-history-by</b>-the...',
                'snippet': 'Buy <b>Pages from Our History by the People</b> of <b>Fovant</b> from Waterstones today! Click and Collect from your local Waterstones or get FREE UK delivery on orders over £20.'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.7',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-19T01:05:00',
                'about': null,
                'name': 'Welcome To Inspired <b>Pilates</b>',
                'url': 'http://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=uBKZt4Jd-0bvBrhi_p-NMoaIHqpUDnUrzmVWnPjCsRc&v=1&r=http%3a%2f%2fwww.inspiredpilates.co.uk%2f&p=DevEx,5158.1',
                'displayUrl': 'www.inspired<b>pilates</b>.co.uk',
                'snippet': 'Lisa Rich is a fully qualified <b>Pilates</b> Foundation Teacher, running classes around the <b>Fovant</b> area. Lisa&#39;s Vision-'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.8',
                'deepLinks': null,
                'dateLastCrawled': '2017-07-05T00:05:00',
                'about': null,
                'name': 'Relaxation Therapy <b>Fovant</b> | NaturalTherapyForAll',
                'url': 'http://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=BLHgtbwgnoe8v023Rlheb4BSir02FzcklzOGZ_jesv0&v=1&r=http%3a%2f%2fwww.naturaltherapyforall.com%2fFind-a%2fRelaxation-Therapy%2fin%2ffovant&p=DevEx,5170.1',
                'displayUrl': 'www.naturaltherapyforall.com/Find-a/Relaxation-Therapy/in/<b>fovant</b>',
                'snippet': 'Find an affordable qualified Relaxation Therapist in <b>Fovant</b>, Search local Relaxation Therapists by postcode or fill out an enquiry form to get a FREE pre-session.'
              },
              {
                'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.9',
                'deepLinks': null,
                'dateLastCrawled': '2017-06-30T12:47:00',
                'about': null,
                'name': '<b>A Quiet Time - Mindfulness | Harpenden</b> Town Council',
                'url': 'http://www.bing.com/cr?IG=C176D65B20BC4609B5CC6FA54D542817&CID=33D020FEF75C6E4C14082A37F6FA6FE4&rd=1&h=LGa3dxZFV1Ds01a9MTyLnp_H8OozPtB-q7jzAj3-ghM&v=1&r=http%3a%2f%2fwww.harpenden.gov.uk%2fevent%2f1143-a-quiet-time-mindfulness&p=DevEx,5183.1',
                'displayUrl': 'www.harpenden.gov.uk/event/1143-a-quiet-time-<b>mindfulness</b>',
                'snippet': 'Add your name and email address below to be added to our reactive, quick and easy on-line survey initiative.'
              }
            ]
          },
          'images': null,
          'news': null,
          'relatedSearches': null,
          'videos': null,
          'rankingResponse': {
            'mainline': {
              'items': [
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.0'
                  },
                  'resultIndex': 0
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.1'
                  },
                  'resultIndex': 1
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.2'
                  },
                  'resultIndex': 2
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.3'
                  },
                  'resultIndex': 3
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.4'
                  },
                  'resultIndex': 4
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.5'
                  },
                  'resultIndex': 5
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.6'
                  },
                  'resultIndex': 6
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.7'
                  },
                  'resultIndex': 7
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.8'
                  },
                  'resultIndex': 8
                },
                {
                  'answerType': 'WebPages',
                  'value': {
                    'id': 'https://api.cognitive.microsoft.com/api/v5/#WebPages.9'
                  },
                  'resultIndex': 9
                }
              ]
            },
            'sidebar': null
          }
        }";

            SearchResponse myres = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResponse>(res2);

            myres.SearchRequest = searchTerm;

            return Ok(myres);

        }


        // POST: api/Search
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}