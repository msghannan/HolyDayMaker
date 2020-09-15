using HolyDayMaker.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    class ApiServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string GetAllRoomsUrl = "https://localhost:44357/api/Rooms";
        private static string GetAllExtrasUrl = "https://localhost:44357/api/Extras";

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






    }
}
