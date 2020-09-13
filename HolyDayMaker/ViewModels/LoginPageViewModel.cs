using GalaSoft.MvvmLight.Command;
using HolyDayMaker.Models;
using HolyDayMaker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolyDayMaker.ViewModels
{
    public class LoginPageViewModel
    {
        public string PasswordTxt { get; set; }
        public string UsernameTxt { get; set; }

        public ICommand btnLogin { get; set; }

        public LoginPageViewModel()
        {
            btnLogin = new RelayCommand(LoginAsync);
        }
        private async void LoginAsync()
        {
            ApiServices _apiService = new APIServices();
            var p = await _apiService.LoginAsync(UsernameTxt, PasswordTxt);
            App.LoggedInUser = p;

        }
    }
}
