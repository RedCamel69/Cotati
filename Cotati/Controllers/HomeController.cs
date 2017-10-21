using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cotati.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web;

namespace Cotati.Controllers
{
    public class HomeController : Controller
    {
        //static HttpClient client = new HttpClient();

        HttpClient client;
        string url = "api/search/"; // mindfulness%20in%20fovant";
        string url2 = "http://localhost:56684/api/autocomplete/fred";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public HomeController()
        {
            client = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Search(string query)
        {
           
            client.BaseAddress = new Uri(Request.Scheme + "://" + Request.Host + "/" + url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // return View(new Car() { Age=78, Name="GM" });

            HttpResponseMessage responseMessage = await client.GetAsync(client.BaseAddress + "/" +  HttpUtility.UrlEncode(query).Replace("+", "%20")); //TODO Sort this shit out
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                //var Employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(responseData);
                SearchResponse resp = JsonConvert.DeserializeObject<SearchResponse>(responseData);

                return View(resp);
            }
            return View("Error");

        }

        //public async Task<ActionResult> AutoComplete()
        //{
        //    client.BaseAddress = new Uri(url2);

        //    HttpResponseMessage responseMessage = await client.GetAsync(url2);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        //        //var Employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(responseData);
        //        Suggestions resp = JsonConvert.DeserializeObject<Suggestions>(responseData);

        //        return View(resp);
        //    }
        //    return View("Error");
        //}

        public ActionResult AutoComplete()
        {
            return View();
        }


        public ActionResult News()
        {
            #region res

            string res = @"{
  '_type': 'News',
  'readLink': 'https://api.cognitive.microsoft.com/api/v5/news/search?q=financial+markets',
  'totalEstimatedMatches': 171000,
  'value': [
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/144f6bf1-56c0-9564-fa3d-a169607dc2e6',
          'name': 'PBS NewsHour'
        },
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/0013f08a-0ecc-dfb9-b8ea-847e36a678c2',
          'name': 'Stock market'
        },
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/1fed0e76-8502-b92b-c0eb-be89568314be',
          'name': 'Rally'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'PBS'
        }
      ],
      'datePublished': '2017-08-08T10:14:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': {
        'name': 'Column: How can the stock market rally possibly continue?',
        'thumbnailUrl': 'https://www.bing.com/th?id=ON.F91C1030F2F168A24F483A113460597C&pid=News',
        'allowHttpsEmbed': false,
        'thumbnail': {
          'contentUrl': null,
          'width': 480,
          'height': 320
        }
      },
      'category': null,
      'name': 'Column: How can the stock <b>market</b> rally possibly continue?',
      'url': 'http://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=X8uqvmfRVqwz2EMtv6MPn9WE8DUXbecKlqBCva8Hv80&v=1&r=http%3a%2f%2fwww.pbs.org%2fnewshour%2fmaking-sense%2fcolumn-can-stock-market-rally-possibly-continue%2f&p=DevEx,5015.1',
      'description': 'And that was just in the past two weeks! Despite these facts, <b>financial markets</b> have marched forward. Meanwhile, there are early warning signs that the world’s largest economies may be slowing. GM reported a 15 percent drop in U.S. auto sales (with Ford ...',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.3190A7C13A1EB5F76D3BFE4678F3DC7C&pid=News',
          'width': 700,
          'height': 336
        }
      }
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/0013f08a-0ecc-dfb9-b8ea-847e36a678c2',
          'name': 'Stock market'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'CBS News'
        }
      ],
      'datePublished': '2017-08-08T09:30:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': {
        'name': 'This record-setting stock market sure is boring',
        'thumbnailUrl': 'https://www.bing.com/th?id=ON.9950AD2F25CB31216C567A2447A33C31&pid=News',
        'allowHttpsEmbed': false,
        'thumbnail': {
          'contentUrl': null,
          'width': 480,
          'height': 252
        }
      },
      'category': 'Business',
      'name': 'This record-setting stock <b>market</b> sure is boring',
      'url': 'http://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=6O2vnd3ELub9GXK9j-g5UombHd8IfZ_YoGsm_a61tuo&v=1&r=http%3a%2f%2fwww.cbsnews.com%2fnews%2fthis-record-setting-stock-market-sure-is-boring%2f&p=DevEx,5017.1',
      'description': 'I think investors still think central banks will step in if there&#39;s any stress in the <b>financial markets</b>.&quot; The Federal Reserve and other central banks around the world have slashed interest rates and thrown trillions of dollars of stimulus at the global ...',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.E8466F31536CDA7D13302160811A7FFD&pid=News',
          'width': 380,
          'height': 240
        }
      }
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/7dc81eff-3666-ff78-d874-390151738609',
          'name': 'FinancialContent'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'Financial Content'
        }
      ],
      'datePublished': '2017-08-08T10:13:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': 'Business',
      'name': 'Veru Inc. Reports Fiscal Third Quarter <b>Financial</b> Results',
      'url': 'http://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=aE4y6XAEZyDk-qYKUbWz4-p06qTFOmzFgF37UqhDd_M&v=1&r=http%3a%2f%2fmarkets.financialcontent.com%2fstocks%2fnews%2fread%3fGUID%3d34720860&p=DevEx,5019.1',
      'description': 'Summary of FQ3 <b>Financial</b> Results For the three months ended June 30 ... which is focused on the global public health sector FC2 business. This division <b>markets</b> the company’s Female Condom (FC2) to entities, including ministries of health, government ...',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.506A6D8496BEAFDB6BD954637A476CA4&pid=News',
          'width': 150,
          'height': 105
        }
      }
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/216726d1-8987-06d3-5eff-823da05c3d3c',
          'name': 'Washington, D.C.'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'Bloomberg'
        }
      ],
      'datePublished': '2017-08-08T09:00:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': null,
      'name': 'What Happens in Washington Matters to <b>Markets</b>',
      'url': 'https://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=tXHx2qt8WmW8PScZns1lrI9p3xQcXwZ92mUw6DM74mg&v=1&r=https%3a%2f%2fwww.bloomberg.com%2fview%2farticles%2f2017-08-07%2fwhat-happens-in-washington-matters-to-markets&p=DevEx,5021.1',
      'description': 'Specifically, emphasis on health care as the top priority would lead to disappointment for equity investors. <b>Financial</b> <b>market</b> participants were hoping to benefit from dismantling onerous regulations, cutting corporate taxes and introducing plans for ...',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.F115B1B1595C9DD04FD46A95C2AB25D2&pid=News',
          'width': 150,
          'height': 96
        }
      }
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/62f7f4ef-776f-509d-ddde-cd8d463b250d',
          'name': 'Douglas'
        },
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/a3b81431-46c4-c41b-eb74-55d698d4090b',
          'name': 'Antonov An-8'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': '4 Traders'
        }
      ],
      'datePublished': '2017-08-08T10:12:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': 'Business',
      'name': 'DOUGLAS DYNAMICS,INC. (NYSE:PLOW) Files An 8-K Results of Operations and <b>Financial</b> Condition',
      'url': 'http://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=7e5oOkBPaJcXHX3w1PWUeMourLR71Sfx9llR1LQw4FQ&v=1&r=http%3a%2f%2fwww.4-traders.com%2fDOUGLAS-DYNAMICS-INC-6174074%2fnews%2fDOUGLAS-DYNAMICS-INC-NYSE-PLOW-Files-An-8-K-Results-of-Operations-and-Financial-Condition-24905576%2f&p=DevEx,5023.1',
      'description': '(c) Not applicable. The post DOUGLAS DYNAMICS,INC. (NYSE:PLOW) Files An 8-K Results of Operations and <b>Financial</b> Condition appeared first on <b>Market</b> Exclusive. 12:05p DOUGLAS DYNAMICS, INC: Results of Operations and <b>Financial</b> Condition, <b>Financial</b>..',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.83D345A97831BB5EBCDE07C358A8FDCF&pid=News',
          'width': 336,
          'height': 360
        }
      }
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/7142adde-7f1a-1130-af1a-3683e215b165',
          'name': 'Condition'
        },
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/0c3b7b2c-f40e-cba8-3bb6-29450420b38e',
          'name': 'NASDAQ'
        },
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/a3b81431-46c4-c41b-eb74-55d698d4090b',
          'name': 'Antonov An-8'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'marketexclusive.com'
        }
      ],
      'datePublished': '2017-08-08T10:10:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': 'Business',
      'name': 'FIRST GUARANTY BANCSHARES, INC. (NASDAQ:FGBI) Files An 8-K Results of Operations and <b>Financial</b> Condition',
      'url': 'https://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=pJL66Cq6xtbjAn9i06mUu99RFr_pQnnfNju2tEVkbOk&v=1&r=https%3a%2f%2fmarketexclusive.com%2ffirst-guaranty-bancshares-inc-nasdaqfgbi-files-an-8-k-results-of-operations-and-financial-condition-4%2f2017%2f08%2f&p=DevEx,5025.1',
      'description': 'Its principal business consists of attracting deposits from the general public and local municipalities in its <b>market</b> areas and investing those ... including shared national credits, with other <b>financial</b> institutions.',
      'image': null
    },
    {
      'about': null,
      'provider': [
        {
          '_type': 'Organization',
          'name': 'CNBC'
        }
      ],
      'datePublished': '2017-08-08T09:52:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': 'Business',
      'name': 'UPDATE 2-Brighthouse <b>Financial</b> shares slip in <b>market</b> debut',
      'url': 'https://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=-VeAqQI3Wo9rudJp2MMySdzwdhKXQkWJLH2ODOjtLRY&v=1&r=https%3a%2f%2fwww.cnbc.com%2f2017%2f08%2f07%2freuters-america-update-2-brighthouse-financial-shares-slip-in-market-debut.html&p=DevEx,5027.1',
      'description': 'Aug 7 (Reuters) - Shares of Brighthouse <b>Financial</b> Inc fell as much as 6 percent in its <b>market</b> debut on Monday, as the U.S. retail insurer spun off from MetLife Inc goes solo in an industry that has been hurt by low interest rates. The stock touched a low ...',
      'image': null
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/8cc1b475-f474-22a5-189f-7d66c4457602',
          'name': 'Management'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'econmatters.com'
        }
      ],
      'datePublished': '2017-08-08T09:14:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': null,
      'name': 'Bankroll Management in <b>Financial Markets</b> (Video)',
      'url': 'http://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=Ky7VuLvAWI-biC2vZHAc88q0IwW-5e6q128j_Na94qE&v=1&r=http%3a%2f%2fwww.econmatters.com%2f2017%2f08%2fbankroll-management-in-financial.html&p=DevEx,5029.1',
      'description': 'We discuss the Law of Small Numbers in this <b>market</b> video in regards to account size, margin requirements, natural <b>market</b> variance and brokerage fees in trading an undercapitalized account. Bankroll Management issues are the main reason new traders blow out ...',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.CEDA595447A3100CE0A166E41245B2D9&pid=News',
          'width': 400,
          'height': 225
        }
      }
    },
    {
      'about': null,
      'provider': [
        {
          '_type': 'Organization',
          'name': 'Market Watch'
        }
      ],
      'datePublished': '2017-08-08T10:00:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': 'Business',
      'name': 'Pattern Energy Reports Second Quarter 2017 <b>Financial</b> Results',
      'url': 'http://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=s7E-09gc33yFmNBE5ZfVOzfGOph1xa7q2f5PE41zpVY&v=1&r=http%3a%2f%2fwww.marketwatch.com%2fstory%2fpattern-energy-reports-second-quarter-2017-financial-results-2017-08-08&p=DevEx,5031.1',
      'description': '<b>Financial</b> and Operating Results Pattern Energy sold 2,111,627 ... (5) From time to time, we conduct strategic reviews of our <b>markets</b>. We have been conducting a strategic review of the <b>market</b>, growth, and opportunities in Chile. In the event we believe ...',
      'image': null
    },
    {
      'about': [
        {
          'readLink': 'https://api.cognitive.microsoft.com/api/v5/entities/2a78f381-51ca-3faf-4b3a-f6cff0355d13',
          'name': 'Research'
        }
      ],
      'provider': [
        {
          '_type': 'Organization',
          'name': 'Whatech'
        }
      ],
      'datePublished': '2017-08-08T09:24:00',
      'clusteredArticles': null,
      'mentions': null,
      'video': null,
      'category': 'ScienceAndTechnology',
      'name': 'Research delivers insight into the global mobile phone insurance ecosystem system <b>market</b>',
      'url': 'https://www.bing.com/cr?IG=6A96F0400F58441493A87D9336814EF6&CID=3F40AA5F874C6EDC0AF4A08786EA6FC4&rd=1&h=WHk48rvwjfYl8z3BFHkEZ9PnNvhP3gjdmodXwIA4cR0&v=1&r=https%3a%2f%2fwww.whatech.com%2fmarket-research%2ffinancial-services%2f354836-research-delivers-insight-into-the-global-mobile-phone-insurance-ecosystem-system-market&p=DevEx,5033.1',
      'description': 'Global Mobile Phone Insurance Ecosystem System <b>Market</b> Research Report from 2017 to 2022: This study is helpful for <b>market</b> players to determine competitive landscape and growth prospects. An extensive analysis of the global industry is provided for the fore ...',
      'image': {
        'contentUrl': null,
        'thumbnail': {
          'contentUrl': 'https://www.bing.com/th?id=ON.5088D57CEDD352B56C7BA42D1E632F38&pid=News',
          'width': 700,
          'height': 400
        }
      }
    }
  ]
}";

            #endregion res

            News myres = Newtonsoft.Json.JsonConvert.DeserializeObject<News>(res);


            return View(myres);

        }





    }
}