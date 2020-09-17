using HolyDayMaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.ViewModel
{
    public class RoomViewModel
    {
        public ObservableCollection<Room> RoomsList { get; set; }


        public ObservableCollection<Room> RoomsListFromDatabase { get; set; }


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
                    return RoomsList;
                }
                else
                {
                    var rooms = RoomsList.Where(r => r.Place == searchPlace);
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
                    var rooms = RoomsList.Where(r => r.Price <= PriceSearch);
                    tempRoomsForPrice = new ObservableCollection<Room>(rooms);
                    return tempRoomsForPrice;
            }
            set { }
        }


        public RoomViewModel()
        {
            RoomsList = new ObservableCollection<Room>();
            ChoisedRoomList = new ObservableCollection<Room>();
            RoomsListFromDatabase = new ObservableCollection<Room>();
        }

        public void ChoisedRoom(Room room)
        {
            ChoisedRoomList.Add(room);
        }
    }
}
