using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    public class UserBooking
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Price { get; set; }
    }
}
