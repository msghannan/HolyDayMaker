using HolyDayMaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.ViewsModel
{
    public class ExtraViewModel
    {
        public ObservableCollection<Extra> ExtraList { get; set; }

        public ObservableCollection<Extra> ExtraChoisedList { get; set; }

        public ExtraViewModel()
        {
            ExtraList = new ObservableCollection<Extra>();
            ExtraChoisedList = new ObservableCollection<Extra>();

            ExtraList.Add(new Extra(1, "Frukost", 399));
            ExtraList.Add(new Extra(2, "Fri drycka", 99));
            ExtraList.Add(new Extra(3, "Fri internet", 39));
        }

        public void ExtraChoised(Extra ext)
        {
            ExtraChoisedList.Add(ext);
        }
    }
}
