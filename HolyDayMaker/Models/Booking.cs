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


        public string Summury
        {
            get
            {
                return " ID: " + ID + ", Check in Date: " + CheckinDate + ", Check out Date: " + CheckoutDate + ", UserID: " + UserID + ", RoomID: " + RoomID;
            }  
        }
    }
}