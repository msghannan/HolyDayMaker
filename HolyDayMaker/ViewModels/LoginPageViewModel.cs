
﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using HolyDayMaker.Services;

﻿using GalaSoft.MvvmLight.Command;
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

        #region privates
        public string _username { get; set; }
        public string _password { get; set; }


        #endregion
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public ICommand LoginBtn { get; set; }
        public ApiServices _services;

        #region Methods
        public LoginPageViewModel()
        {
            LoginBtn = new RelayCommand(LoginAsync);
            _services = new ApiServices();
        }

        private async void LoginAsync()
        {
            if(!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                var user = await _services.GetUser(Username, Password);
                if(user != null)
                {
                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(App.MainPage);
                }
                else
                {

                }
            }
        }
        #endregion


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
