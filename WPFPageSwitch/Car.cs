using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPageSwitch
{
    public class Car
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public Int64 year { get; set; }
        public double price { get; set; }
        public double margin { get; set; }
        public int mileage { get; set; }
        public double displ { get; set; }
        public string fuelType { get; set; }
        public double power { get; set; }
        public string trany { get; set; }
        public string desc { get; set; }
        public string photo { get; set; }
        public int parking { get; set; }

        public Car()
        {

        }

        public Car(int id, string make, string model, Int64 year, double price, double margin, int mileage, double displ, string fuelType, double power, string trany, string desc, string photo, int parking)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.margin = margin;
            this.mileage = mileage;
            this.displ = displ;
            this.fuelType = fuelType;
            this.power = power;
            this.trany = trany;
            this.desc = desc;
            this.photo = photo;
            this.parking = parking;
        }
    }
}
