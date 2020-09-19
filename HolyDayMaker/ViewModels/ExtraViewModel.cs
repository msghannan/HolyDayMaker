using HolyDayMaker.Models;
using HolyDayMaker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.ViewModels
{
    public class ExtraViewModel
    {
        ApiServices apiServices;
        public ObservableCollection<Extra> _extraListFromDatabase { get; set; }

        public ObservableCollection<Extra> ExtraListFromDatabase
        {
            get
            {
                _extraListFromDatabase = Task.Run(async () => await apiServices.GetAllExtrasAsync()).GetAwaiter().GetResult();
                return _extraListFromDatabase;
            }

            set
            {

            }
        }

        public ObservableCollection<Extra> ExtraChoisedList { get; set; }

        public ExtraViewModel()
        {
            apiServices = new ApiServices();
            ExtraChoisedList = new ObservableCollection<Extra>();
            _extraListFromDatabase = new ObservableCollection<Extra>();
        }

        public void ExtraChoised(Extra ext)
        {
            ExtraChoisedList.Add(ext);
        }
    }
}
