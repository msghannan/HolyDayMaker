using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    public class Extra
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        public Extra (int id, string name, double price, string imageURL)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.ImageURL = imageURL;
        }

        public string Summary
        {
            get
            {
                return Name + "\n" + "Pris: " + Price + " / natt";
            }
        }

    }
}
