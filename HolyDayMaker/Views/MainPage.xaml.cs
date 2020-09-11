﻿using HolyDayMaker.Models;
using HolyDayMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HolyDayMaker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private RoomViewModel roomViewModel;


        public MainPage()
        {
            this.InitializeComponent();

            roomViewModel = new RoomViewModel();
        }


        private void CitySearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            roomViewModel.searchPlace = CitySearchTextBox.Text;
            RoomsGridGrid.ItemsSource = roomViewModel.FiltredRoomsList;
        }
    }
}
