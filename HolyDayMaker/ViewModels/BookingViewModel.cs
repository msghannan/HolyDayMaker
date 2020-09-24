using HolyDayMaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.ViewModels
{
    class BookingViewModel
    {
        public ObservableCollection<Booking> BookingListFromDatabase { get; set; }
        public BookingViewModel()
        {
            BookingListFromDatabase = new ObservableCollection<Booking>();
        }
        internal void RemoveBooking(Booking booking)
        {
            BookingListFromDatabase.Remove(booking);
        }
    }
}
