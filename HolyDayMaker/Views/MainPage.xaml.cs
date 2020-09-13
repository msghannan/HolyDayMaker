using HolyDayMaker.Models;
using HolyDayMaker.ViewModel;
using HolyDayMaker.Views;
using HolyDayMaker.Views;
using HolyDayMaker.ViewsModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
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
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        double TotPrice { get { return _totPrice; } set { _totPrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotPrice")); } }
        private double _totPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        private RoomViewModel roomViewModel;
        private ExtraViewModel extraViewModel;


        public MainPage()
        {
            this.InitializeComponent();

            roomViewModel = new RoomViewModel();
            extraViewModel = new ExtraViewModel();
        }


        private void CitySearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            roomViewModel.searchPlace = CitySearchTextBox.Text;
            RoomsGridGrid.ItemsSource = roomViewModel.FiltredRoomsList;
        }

        private void PriceSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //roomViewModel.priceSearch = 250;
            //RoomsGridGrid.ItemsSource = roomViewModel.FiltredRoomsPriceList;
        }

        private void RoomsGridGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            roomViewModel.ChoisedRoomList.Add((Room)e.ClickedItem);
            AddPrice(((Room)e.ClickedItem).Price);
        }

        private void ExtraGridGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            extraViewModel.ExtraChoisedList.Add((Extra)e.ClickedItem);
            AddPrice(((Extra)e.ClickedItem).Price);
        }


        private void AddPrice(double sum)
        {
            TotPrice += sum;
            TotPricetextBlock.Text = TotPrice.ToString();
        }


        private void CheckoutDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            CalculateDays();
        }

        private void CheckinDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            CheckoutDate.IsEnabled = true;
        }

        private void CalculateDays()
        {
            DateTime checkIn = DateTime.Parse(CheckinDate.Date.ToString());
            DateTime checkOut = DateTime.Parse(CheckoutDate.Date.ToString());

            int days = (checkOut - checkIn).Days;

            if (days > 14)
            {
                MaximumDayWarning();
                TotalDaysTextBlock.Text = String.Empty;
            }

            else
            {
                TotalDaysTextBlock.Text = days.ToString();
            }


        }

        private void MaximumDayWarning()
        {
            MaximumDayWarningContentDialog a = new MaximumDayWarningContentDialog();
            _ = a.ShowAsync();
        }
    }
}
