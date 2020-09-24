using GalaSoft.MvvmLight.Command;
using HolyDayMaker.Models;
using HolyDayMaker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolyDayMaker.ViewModels
{
    public class MainPageViewModel
    {
        ApiServices apiServices;
        public ObservableCollection<Room> _roomsListFromDatabase { get; set; }
        public ObservableCollection<Extra> _extraListFromDatabase { get; set; }
        public ObservableCollection<Room> RoomsListFromDatabase
        {
            get
            {
                _roomsListFromDatabase = Task.Run(async () => await apiServices.GetAllRoomsAsync()).GetAwaiter().GetResult();
                return _roomsListFromDatabase;
            }
        }
        public ObservableCollection<Extra> ExtraListFromDatabase
        {
            get
            {
                _extraListFromDatabase = Task.Run(async () => await apiServices.GetAllExtrasAsync()).GetAwaiter().GetResult();
                return _extraListFromDatabase;
            }
        }
        ObservableCollection<Room> tempRoomsForPrice;
        ObservableCollection<Room> tempRooms;
        public ICommand PostBookingBtn { get; set; }
        public ObservableCollection<Room> FiltredRoomsList
        {
            get
            {
                if (string.IsNullOrEmpty(searchPlace))
                {
                    return RoomsListFromDatabase;
                }
                else
                {
                    var rooms = RoomsListFromDatabase.Where(r => r.Place == searchPlace);
                    tempRooms = new ObservableCollection<Room>(rooms);
                    return tempRooms;
                }
            }
        }
        public ObservableCollection<Room> FiltredRoomsPriceList
        {
            get
            {
                var rooms = RoomsListFromDatabase.Where(r => r.Price <= PriceSearch);
                tempRoomsForPrice = new ObservableCollection<Room>(rooms);
                return tempRoomsForPrice;
            }
            set { }
        }

        public ObservableCollection<Room> ChoisedRoomList { get; set; }
        public string searchPlace { get; set; }
        public int _priceSearch { get; set; }
        public int PriceSearch { get => _priceSearch; set => _priceSearch = value; }
        public double Totalprice { get; set; }


        public DateTimeOffset _startDate { get; set; }
        public DateTimeOffset StartDate { get => _startDate.ToString("yyyy-MM-dd") == "0001-01-01" ? DateTime.Now : _startDate; set => _startDate = value; }
        public DateTimeOffset _endDate { get; set; }
        public DateTimeOffset EndDate
        {
            get =>
                _endDate.ToString("yyyy-MM-dd") == "0001-01-01" ? DateTime.Now.AddDays(3) : _endDate; //{1/1/0001

            set => _endDate = value;
        }

        public User user { get; set; }
        public ObservableCollection<Extra> ExtraChoisedList { get; set; }

        public MainPageViewModel()
        {
            apiServices = new ApiServices();
            ExtraChoisedList = new ObservableCollection<Extra>();
            _extraListFromDatabase = new ObservableCollection<Extra>();
            ChoisedRoomList = new ObservableCollection<Room>();
            _roomsListFromDatabase = new ObservableCollection<Room>();
            user = App.LoggedInUser;
            PostBookingBtn = new RelayCommand(PostBookingAsync);
        }
        private async void PostBookingAsync()
        {
            if (ChoisedRoomList.Count > 0)
            {
                var listOfRooms = new List<UserBooking>();
                foreach (var room in ChoisedRoomList)
                {
                    listOfRooms.Add(new UserBooking()
                    {
                        ID = 0,
                        StartDate = StartDate.ToString("yyyy-MM-dd"),
                        EndDate = EndDate.ToString("yyyy-MM-dd"),
                        RoomID = room.ID,
                        UserID = App.LoggedInUser.ID,
                        Price = Totalprice
                    });
                }

                var result = await apiServices.PostRooms(listOfRooms);

                var abc = result;
            }
        }
    }
}
