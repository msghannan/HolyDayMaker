using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    class ApiServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string GetAllRoomsAsync = "https://localhost:44363/api/StudentsResults";

        //public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        //{

        //}

        //public async void PostPostBookingAsync(Booking booking)
        //{

        //}




    }
}
