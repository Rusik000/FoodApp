using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FoodApp.Back_End.Models
{

    public class Food : Entity, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

     

        public Food() 
        {
            Sum = Price * Quantity;
        }

        public Food(string name, decimal price, decimal weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public Food(string name, decimal price, decimal weight, string imagePath)
        {
            Name = name;
            Price = price;
            Weight = weight;
            ImagePath = imagePath;
        }

        


        public Food(string name, decimal price, decimal weight, decimal quantity, decimal sum, string imagePath)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Quantity = quantity;
            Sum = sum;
            ImagePath = imagePath;
        }

        public string _Name;
        public decimal _Price;
        public decimal _Weight;
        public decimal _Quantity=0;
        public decimal _sum=0;
        public string _imagePath;




        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnpropertyChanged(); }
        }
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; OnpropertyChanged(); }
        }
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; OnpropertyChanged(); }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; OnpropertyChanged(); }
        }


        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnpropertyChanged(); }
        }

        public decimal Sum
        {
            get { return _sum; }
            set { _sum = value; OnpropertyChanged(); }
        }

        

    }
}
