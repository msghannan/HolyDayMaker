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

        public ObservableCollection<Room> ChoisedRoomList { get; set; }

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

        //public ObservableCollection<Room> FiltredRoomsPriceList
        //{
        //    get
        //    {
        //        if (double.IsNegativeInfinity(priceSearch))
        //        {
        //            return RoomsList;
        //        }
        //        else
        //        {
        //            var rooms = RoomsList.Where(r => r.Price == priceSearch);
        //            tempRoomsForPrice = new ObservableCollection<Room>(rooms);
        //            return tempRoomsForPrice;
        //        }
        //    }
        //    set { }
        //}

        public string searchPlace { get; set; }

        public double priceSearch { get; set; }

        ObservableCollection<Room> tempRooms;

        ObservableCollection<Room> tempRoomsForPrice;

        public RoomViewModel()
        {
            RoomsList = new ObservableCollection<Room>();
            ChoisedRoomList = new ObservableCollection<Room>();

            RoomsList.Add(new Room(1, "Sommarstuga", "Malmö", 2, 255));
            RoomsList.Add(new Room(2, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(3, "Lägenhet", "Malmö", 2, 255));
            RoomsList.Add(new Room(4, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(5, "Sommarstuga", "Malmö", 2, 255));
            RoomsList.Add(new Room(6, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(7, "Lägenhet", "Malmö", 2, 255));
            RoomsList.Add(new Room(8, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(9, "Sommarstuga", "Malmö", 2, 255));
            RoomsList.Add(new Room(10, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(11, "Lägenhet", "Malmö", 2, 255));
            RoomsList.Add(new Room(12, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(13, "Sommarstuga", "Malmö", 2, 255));
            RoomsList.Add(new Room(14, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(15, "Lägenhet", "Malmö", 2, 255));
            RoomsList.Add(new Room(15, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(16, "Sommarstuga", "Malmö", 2, 255));
            RoomsList.Add(new Room(17, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(18, "Lägenhet", "Malmö", 2, 255));
            RoomsList.Add(new Room(19, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(20, "Sommarstuga", "Malmö", 2, 255));
            RoomsList.Add(new Room(21, "Hus", "Ystad", 2, 599));
            RoomsList.Add(new Room(22, "Lägenhet", "Malmö", 2, 255));
            RoomsList.Add(new Room(23, "Hus", "Ystad", 2, 599));
        }

        public void ChoisedRoom(Room room)
        {
            ChoisedRoomList.Add(room);
        }
    }
}
