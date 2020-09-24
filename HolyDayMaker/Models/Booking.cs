using HolyDayMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public Room Room { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }
        public MainPageViewModel Mpv { get; set; }

        public Booking()
        {
            this.Mpv = new MainPageViewModel();
        }
        public string Summury
        {
            get
            {
                return " ID: " + ID + ", Datum Från : " + Mpv.StartDate + ", Datum Till: " + Mpv.EndDate + ", UserID: " + UserID + ", RoomID: " + RoomID;
            }
        }
    }
}