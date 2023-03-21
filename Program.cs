using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

class ClsHttpPost
{
    static void Main(string [] args )
    {
        PostRequest("https://httpdump.app/dumps/2947bdc2-ae23-432a-ac63-39ba15ccb5cb");
       // PostJSONRequst();
        Console.WriteLine("Hello, World!");
        Console.Read();
    }

    async static void PostRequest(string url)
    {
        IEnumerable<KeyValuePair<string,string>> queries = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Query1","SRISAILAM"),
            new KeyValuePair<string, string>("Query2","547199")

        };
        HttpContent q = new FormUrlEncodedContent(queries);
        using (HttpClient Client = new HttpClient())
        {
            using (HttpResponseMessage response = await Client.PostAsync(url,q))
            {

                using (HttpContent content = response.Content)
                {
                    string mycontent = await content.ReadAsStringAsync();
                    HttpContentHeaders headers = content.Headers;
                    Console.WriteLine(mycontent);
                }

            }
        }
    }
   
    static void PostJSONRequst()
    {
        using (var client = new HttpClient())
        {
           // var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
            var endpoint = new Uri("https://my-json-server.typicode.com/user/repo/posts"); 
            var newPost = new HTTPPOST.Post()
            {
                Title = "JSON POST",
                Body = "ASF to UJET",
                UserId =1234
            };
            var newPostJson = JsonConvert.SerializeObject(newPost);
            var payload = new StringContent(newPostJson, System.Text.Encoding.UTF8, "application/json");
            var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
         }
    }

}

