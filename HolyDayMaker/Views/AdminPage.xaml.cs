using HolyDayMaker.Models;
using HolyDayMaker.Services;
using HolyDayMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolyDayMaker.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        private BookingViewModel bookingViewModel;
        private ApiServices apiServices;
        public AdminPage()
        {
            this.InitializeComponent();
            apiServices = new ApiServices();
            bookingViewModel = new BookingViewModel();

            GetAllBookings();

        }
        public async void GetAllBookings()
        {
            MyBookingsGridGrid.ItemsSource = await apiServices.GetAllBookingsAsync();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private async void DeleteBookingButton_Click(object sender, RoutedEventArgs e)
        {
            var select = MyBookingsGridGrid.SelectedItems;
            foreach (Booking booking in select)
            {


                bookingViewModel.RemoveBooking(booking);
                await apiServices.DeleteBookingAsync(booking);

            }

        }
    }
}
