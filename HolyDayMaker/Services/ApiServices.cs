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

namespace HolyDayMaker.Services
{
    public class ApiServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string GetAllRoomsUrl = "https://localhost:44357/api/Rooms";
        private static string GetAllExtrasUrl = "https://localhost:44357/api/Extras";
        private static string GetAccountUrl = "https://localhost:44357/api/Accounts";
        private static string BookedRoomsUrl = "https://localhost:44357/api/Bookings";
        private static string GetBookingUrl = "https://localhost:44357/api/Bookings";
        private static string DeleteBookingUrl = "https://localhost:44357/api/Bookings/";


        public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        {
            
            string ourRooms = await httpClient.GetStringAsync(GetAllRoomsUrl);
            var rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(ourRooms);
            return rooms;
        }
        //public async Task<ObservableCollection<Booking>> GetAllBookingAsync()
        //{

        //    string ourBookignss = await httpClient.GetStringAsync(GetBookingUrl);
        //    var bookings = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(ourBookignss);
        //    return bookings;
        //}

        public async Task<ObservableCollection<Extra>> GetAllExtrasAsync()
        {
            var ourExtras = await httpClient.GetStringAsync(GetAllExtrasUrl);
            var extras = JsonConvert.DeserializeObject<ObservableCollection<Extra>>(ourExtras);
            return extras;
        }

        public async Task<ObservableCollection<Booking>> GetMyBookings()
        {
            var getData = await httpClient.GetStringAsync(BookedRoomsUrl + "/" + App.LoggedInUser.ID);
            var bookings = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(getData);
            return bookings;
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

        public async Task<int> PostRooms(List<UserBooking> rooms)
        {
            var json = JsonConvert.SerializeObject(rooms);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var data = await httpClient.PostAsync(new Uri(BookedRoomsUrl), content);

            return 1;

        }
        public async Task DeleteBookingAsync(Booking booking)
        {

            var httpClient = new System.Net.Http.HttpClient();

            await httpClient.DeleteAsync(DeleteBookingUrl + booking.ID);

        }

        public async Task<ObservableCollection<Booking>> GetAllBookingsAsync()
        {

            BookingViewModel bookingViewModel = new BookingViewModel();
            var jasonOrder = await httpClient.GetStringAsync(GetBookingUrl);
            bookingViewModel.BookingListFromDatabase = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(jasonOrder);
            return bookingViewModel.BookingListFromDatabase;
        }


    }
}
