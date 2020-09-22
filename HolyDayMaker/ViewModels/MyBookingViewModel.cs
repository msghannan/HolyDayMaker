using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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
    public class MyBookingViewModel
    {
        ApiServices apiServices;

        public ObservableCollection<Booking> _mybookings { get; set; }
        public ObservableCollection<Booking> MyBookings { get { return _mybookings; } set { MyBookings = value; } }
        public ICommand NavigateBtn { get; set; }
        public ICommand LogoutBtn { get; set; }
        public MyBookingViewModel()
        {
            NavigateBtn = new RelayCommand<string>(NavigateToMainPage);
            LogoutBtn = new RelayCommand<string>(NavigateToMainPage);
            this.apiServices = new ApiServices();
            _mybookings = Task.Run(() => apiServices.GetMyBookings()).Result;
        }

        public void NavigateToMainPage(string page)
        {
            if (page == "MainPageBtn")
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(App.MainPage);
            }
            else if (page == "LogoutBtn")
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(App.LoginPage);
            }
            
        }
    }
}
