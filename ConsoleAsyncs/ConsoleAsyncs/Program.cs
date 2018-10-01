using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAsyncs
{
    class Program
    {
        static void Main1(string[] args)
        {
            List<string> sites = new List<string>();
            sites.Add("http://www.microsoft.com");
            sites.Add("http://www.stackoverflow.com");
            sites.Add("http://www.codeproject.com");
            sites.Add("http://www.mindtree.com");
            sites.Add("http://www.google.com");
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            foreach (var item in sites)
            {

                GetSite(item);
            }
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ReadLine();
        }

        private static string GetSite(string url)
        {
            WebClient client = new WebClient();
            var message = client.DownloadData(url).ToString();
            
            return message;
        }

        static async Task Main(string[] args)
        {
            List<string> sites = new List<string>();
            sites.Add("http://www.microsoft.com");
            sites.Add("http://www.stackoverflow.com");
            sites.Add("http://www.codeproject.com");
            sites.Add("http://www.mindtree.com");
            sites.Add("http://www.google.com");
            Task[] tasks = new Task[5];
            int i = 0;
            foreach (var item in sites)
            {

                tasks[i++] = GetSiteAsync(item);
            }
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            await Task.WhenAll(tasks);
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ReadLine();
        }

        private static async Task<string> GetSiteAsync(string url)
        {
            HttpClient client = new HttpClient();
            var message = await client.GetAsync(url);
            var content = await message.Content.ReadAsStringAsync();
            return content;
        }

    }
}

