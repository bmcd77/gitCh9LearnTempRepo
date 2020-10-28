using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{

    class Program
    {
        private static string gitUser = "bmcd77";
        private static string gitRepo = "gitCh9LearnTempRepo";
        private static string gitRepos = "repos";

        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                var i = 0;
                foreach (var a in args)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("arg" + (++i).ToString() + " " + a);
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("    H e l l o   W o r l d!   "); Console.WriteLine();
            Console.ResetColor();

            Uri projectUri = new Uri($"https://api.github.com/repos/{gitUser}/{gitRepo}");
            Uri allRepos = new Uri($"https://api.github.com/users/{gitUser}/{gitRepos}");

            Console.WriteLine($"This is a test of Github SCM from a Rob Green channel 9 video for {projectUri}");

            var task = await getHttpRequest(projectUri);

            task = await getHttpRequest(allRepos);

        }

        /// <summary>
        /// https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        /// </summary>
        /// <returns></returns>
        private static async Task<String/*HttpResponseMessage*/> getHttpRequest(Uri uri)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request"); //Set the User Agent to "request" as per GitHub

            HttpResponseMessage response;
            string responseBody;
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), uri))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Sending Async Get Request to {uri}");
                response = client.GetAsync(uri).Result;  // Get the actual response (not just std headers coming back)
                //response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync(); // Get the actual Response

                //// Try parse the JSON with newtonsoft
                //var data = JObject.Parse(responseBody);
                
                //foreach (var pair in data)
                //{
                //    if(pair.Key == "name")
                //        Console.WriteLine(pair.Value);
                //}

                //var test = data["name"];
                ////IList<JToken> results = data.Children().ToList().Where(jt =>jt["name] == "name");
                
                //ReadAsAsync<List<String>>().Result;

                Console.WriteLine(responseBody);
                Console.WriteLine();
                Console.ResetColor();
            }

            //return response;
            return responseBody;
        }


    }
}
