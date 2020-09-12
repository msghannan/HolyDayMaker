﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyDayMaker.Models
{
    public class Extra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Extra (int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

    }
}
