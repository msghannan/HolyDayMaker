using HolyDayMaker.Models;
using HolyDayMaker.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using HolyDayMaker.ViewsModel;
using HolyDayMaker.ViewModel;

namespace HolyDayMaker.Services
{
    public class ApiServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string GetAllRoomsUrl = "https://localhost:44357/api/Rooms";
        private static string GetAllExtrasUrl = "https://localhost:44357/api/Extras";
        private static string GetAccountUrl = "https://localhost:44357/api/Accounts";

        public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        {
            RoomViewModel roomViewModel = new RoomViewModel();
            var jsonPizzor = await httpClient.GetStringAsync(GetAllRoomsUrl);
            roomViewModel.RoomsListFromDatabase = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonPizzor);
            return roomViewModel.RoomsListFromDatabase;
        }
        public async Task<ObservableCollection<Extra>> GetAllExtrasAsync()
        {
            ExtraViewModel extraViewModel = new ExtraViewModel();
            var jsonPizzor = await httpClient.GetStringAsync(GetAllExtrasUrl);
            extraViewModel.ExtrasListFromDatabase = JsonConvert.DeserializeObject<ObservableCollection<Extra>>(jsonPizzor);
            return extraViewModel.ExtrasListFromDatabase;
        }

        public async Task<User> GetUser(string username, string password)
        {
            var user = new User();
            var account = new Account() {Username = username, Password = password };
            var json = JsonConvert.SerializeObject(account);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var data = await httpClient.PostAsync(new Uri(GetAccountUrl), content);
            var result = data.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<User>(result);
        }


    }
}
