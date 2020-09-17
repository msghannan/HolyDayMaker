using HolyDayMaker.Models;
using HolyDayMaker.ViewModels;
using Intuit.Ipp.Core.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HolyDayMaker.Service
{
    public class APIservice
    {
        static HttpClient httpClient = new HttpClient();
        private static string Accounts = "/Accounts";

        public async Task<Account> LoginAsync(string username, string password)
        {
            Account acc = new Account();
            acc.Username = username;
            acc.Password = password;
            Account p = new Account();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(acc);

                    HttpContent content = new StringContent(json);

                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var abc = await client.PostAsync(new Uri(BaseUrl + Accounts), content);
                    var result = abc.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<Account>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return p;
        }
    }
}
