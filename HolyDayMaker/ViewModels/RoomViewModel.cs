using HolyDayMaker.Models;
using HolyDayMaker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.ViewModels
{
    public class RoomViewModel
    {
        ApiServices apiServices = new ApiServices();

        public ObservableCollection<Room> _roomsListFromDatabase { get; set; }

        public ObservableCollection<Room> RoomsListFromDatabase 
        {
            get
            {
                _roomsListFromDatabase = Task.Run(async () => await apiServices.GetAllRoomsAsync()).GetAwaiter().GetResult();
                return _roomsListFromDatabase;
            }

            set
            {

            }
        }

        public ObservableCollection<Room> ChoisedRoomList { get; set; }
        public string searchPlace { get; set; }
        public int _priceSearch { get; set; }
        public int PriceSearch { get => _priceSearch; set => _priceSearch = value; }

        ObservableCollection<Room> tempRoomsForPrice;
        ObservableCollection<Room> tempRooms;


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
            set { }
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


        public RoomViewModel()
        {
            apiServices = new ApiServices();
            ChoisedRoomList = new ObservableCollection<Room>();
            _roomsListFromDatabase = new ObservableCollection<Room>();
        }

        public void ChoisedRoom(Room room)
        {
            ChoisedRoomList.Add(room);
        }

    }
}
