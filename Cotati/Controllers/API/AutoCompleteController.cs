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
    [Route("api/AutoComplete")]
    public class AutoCompleteController : Controller
    {

        static string host = "https://api.cognitive.microsoft.com";
        static string path = "/bing/v7.0/Suggestions";

        // For a list of available markets, go to:
        // https://docs.microsoft.com/rest/api/cognitiveservices/bing-autosuggest-api-v7-reference#market-codes
        static string market = "en-UK";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "a6672d48b53f4ad9a37fd7b332a88818";

        // GET: api/AutoComplete

        //public IEnumerable<string> Get()
        [HttpGet("{searchTerm}", Name = "GetAutoComplete")]
        public IActionResult Get(string searchTerm)
        {
            

            // Construct the URI of the search request
            var uriQuery = host + path  + "?q=" + Uri.EscapeDataString(searchTerm);

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = key;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //// Create result object for return
            //var searchResult = new Suggestions()
            //{
            //    jsonResult = json,
            //    relevantHeaders = new Dictionary<String, String>()
            //};

            Suggestions myres = Newtonsoft.Json.JsonConvert.DeserializeObject<Suggestions>(json);

            //Suggestions myres = new Suggestions();
            return Ok(myres);

         /*
            //return new string[] { "value1", "value2" };
            string res = @"{
  '_type': 'Suggestions',
  'instrumentation': null,
  'queryContext': {
                'originalQuery': 'mindfulness in fo'
  },
  'suggestionGroups': [
    {
      'name': 'Web',
      'searchSuggestions': [
        {
          'url': 'https://www.bing.com/cr?IG=0C3288EF65C54D53A3BE30E3862B0DB4&CID=18851C1E30DA6CF40DBD16CC317C6DE6&rd=1&h=IdugWcKSvnr650-ScbdXSfRDQvSoqdKh5lB3-bGYQQk&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bin%2bfootball%26FORM%3dUSBAPI&p=DevEx,5003.1',
          'urlPingSuffix': null,
          'displayText': 'mindfulness in football',
          'query': 'mindfulness in football',
          'searchKind': 'WebSearch'
        },
        {
          'url': 'https://www.bing.com/cr?IG=0C3288EF65C54D53A3BE30E3862B0DB4&CID=18851C1E30DA6CF40DBD16CC317C6DE6&rd=1&h=5FuL_mxlNLY-wQaCh7yOqCj7kBtt1ePcLvlIKTub4l0&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bin%2bfolkestone%26FORM%3dUSBAPI&p=DevEx,5004.1',
          'urlPingSuffix': null,
          'displayText': 'mindfulness in folkestone',
          'query': 'mindfulness in folkestone',
          'searchKind': 'WebSearch'
        },
        {
          'url': 'https://www.bing.com/cr?IG=0C3288EF65C54D53A3BE30E3862B0DB4&CID=18851C1E30DA6CF40DBD16CC317C6DE6&rd=1&h=ARlSHhiSx6A1GRSCO8ASMnDm8jvbt9i2y5NgNQQhGJQ&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bin%2bfordingbridge%26FORM%3dUSBAPI&p=DevEx,5005.1',
          'urlPingSuffix': null,
          'displayText': 'mindfulness in fordingbridge',
          'query': 'mindfulness in fordingbridge',
          'searchKind': 'WebSearch'
        },
        {
          'url': 'https://www.bing.com/cr?IG=0C3288EF65C54D53A3BE30E3862B0DB4&CID=18851C1E30DA6CF40DBD16CC317C6DE6&rd=1&h=hGaZzEqyMnaKV5zBRa7qVhlQ_oftp5SgzfVrdyUZUeg&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bin%2bfoster%2bcarers%26FORM%3dUSBAPI&p=DevEx,5006.1',
          'urlPingSuffix': null,
          'displayText': 'mindfulness in foster carers',
          'query': 'mindfulness in foster carers',
          'searchKind': 'WebSearch'
        },
        {
          'url': 'https://www.bing.com/cr?IG=0C3288EF65C54D53A3BE30E3862B0DB4&CID=18851C1E30DA6CF40DBD16CC317C6DE6&rd=1&h=5Rs_5uRHwyol_toOdWl3XEvgGm4uOYWIy4sslc3L1rE&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bin%2bforensic%2bsettings%26FORM%3dUSBAPI&p=DevEx,5007.1',
          'urlPingSuffix': null,
          'displayText': 'mindfulness in forensic settings',
          'query': 'mindfulness in forensic settings',
          'searchKind': 'WebSearch'
        },
        {
          'url': 'https://www.bing.com/cr?IG=0C3288EF65C54D53A3BE30E3862B0DB4&CID=18851C1E30DA6CF40DBD16CC317C6DE6&rd=1&h=d3vGsvJf8ONRCQEv0f89PVCB53avaQg5GNAMRuRJpTU&v=1&r=https%3a%2f%2fwww.bing.com%2fsearch%3fq%3dmindfulness%2bin%2bfovant%26FORM%3dUSBAPI&p=DevEx,5008.1',
          'urlPingSuffix': null,
          'displayText': 'mindfulness in fovant',
          'query': 'mindfulness in fovant',
          'searchKind': 'WebSearch'
        }
      ]
    }
  ]
}";



            Suggestions myres = Newtonsoft.Json.JsonConvert.DeserializeObject<Suggestions>(res);


            return Ok(myres);
            */
        }

        // GET: api/AutoComplete/5
        //[HttpGet("{id}", Name = "GetSpecificAutoComplete")]
        //public string Get(int id)
        //{
        //    return "value 99";
        //}

        // POST: api/AutoComplete
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AutoComplete/5
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