﻿using System;
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
        public string ImageURL { get; set; }

        public Room(int id, string name, string place, int numberOfBeds, double price, string imageURL)
        {
            this.ID = id;
            this.Name = name;
            this.Place = place;
            this.NumberOfBeds = numberOfBeds;
            this.Price = price;
            this.ImageURL = imageURL;
        }
        public string Summary
        {
            get
            {
                return Name + "\n" + "Stad: " + Place + "\n" + "Antal sängar: " + NumberOfBeds + "\n" + "Pris: " + Price + " / natt";
            }
        }

    }
}
