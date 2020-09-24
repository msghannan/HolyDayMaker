using HolyDayMaker.Models;
using HolyDayMaker.Services;
using HolyDayMaker.ViewModels;
using HolyDayMaker.Views;
using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HolyDayMaker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        double TotDivPrice { get { return _totDivPrice; } set { _totDivPrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotDivPrice")); } }
        private double _totDivPrice;
        double MultiplicatePrice { get { return _multiplicatePrice; } set { _multiplicatePrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MultiplicatePrice")); } }
        private double _multiplicatePrice;
        public event PropertyChangedEventHandler PropertyChanged;
        private ApiServices apiServices;
        public MainPageViewModel vm { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            vm = new MainPageViewModel();
            apiServices = new ApiServices();
            GetAllRooms();
            GetAllExtras();

        }
        public async void GetAllRooms()
        {
            RoomsGridGrid.ItemsSource = await apiServices.GetAllRoomsAsync();
        }
        public async void GetAllExtras()
        {
            ExtraGridGrid.ItemsSource = await apiServices.GetAllExtrasAsync();
        }

        private void CitySearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.searchPlace = CitySearchTextBox.Text;
            RoomsGridGrid.ItemsSource = vm.FiltredRoomsList;
        }
        private void PriceSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(RoomsGridGrid != null)
            {
                RoomsGridGrid.ItemsSource = vm.FiltredRoomsPriceList;
            }
        }
        private void RoomsGridGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            vm.ChoisedRoomList.Add((Room)e.ClickedItem);
            AddPrice(((Room)e.ClickedItem).Price);
            TotalPrice();
        }
        private void ExtraGridGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            vm.ExtraChoisedList.Add((Extra)e.ClickedItem);
            AddPrice(((Extra)e.ClickedItem).Price);
            TotalPrice();
        }
        private void DeleteRoomButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var selectedItem = ChoisedRoomGidView.SelectedItems;

            foreach(Room room in selectedItem)
            {
                vm.ChoisedRoomList.Remove(room);
                DivisionOfPrice(room.Price);
                DivisionOfTotalPrice();
            }
        }
        private void DeleteExtraButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var selectedItem = ExtraGidView.SelectedItems;

            foreach (Extra extra in selectedItem)
            {
                vm.ExtraChoisedList.Remove(extra);
                DivisionOfPrice(extra.Price);
                DivisionOfTotalPrice();
            }
        }
        private void AddPrice(double sum)
        {
            TotDivPrice += sum;
        }
        private void DivisionOfPrice(double sum)
        {
            TotDivPrice -= sum;
        }
        private void DivisionOfTotalPrice()
        {
            double days = double.Parse(TotalDaysTextBlock.Text);
            double price = double.Parse(PricePerNight.Text);

            MultiplicatePrice = days * price;
        }
        private void TotalPrice()
        {
            if (TotalDaysTextBlock.Text == String.Empty)
            {
                TotPricetextBlock.Text = PricePerNight.Text;
            }
            else
            {
                double pricePerNight = double.Parse(PricePerNight.Text);
                int numberOfDays = int.Parse(TotalDaysTextBlock.Text);

                MultiplicatePrice = pricePerNight * numberOfDays;
            }
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
        private void MyBookingsButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyBookingPage));
        }
        private void LogOutButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
