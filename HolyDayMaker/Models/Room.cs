using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int NumberOfBeds { get; set; }
        public double Price { get; set; }

        public Room(int id, string name, string place, int numberOfBeds, double price)
        {
            this.ID = id;
            this.Name = name;
            this.Place = place;
            this.NumberOfBeds = numberOfBeds;
            this.Price = price;
        }

    }
}
