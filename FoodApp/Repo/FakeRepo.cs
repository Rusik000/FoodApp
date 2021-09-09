using FoodApp.Back_End.Models;
using FoodApp.Back_End.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FoodApp.Back_End.Repo
{
    public class FakeRepo
    {
 
        public List<Food> GetAll()
        {
            // ImageSource = new BitmapImage(new Uri(@"LogoFoodStore.png", UriKind.Relative));
            return new List<Food>
            {

                new Models.Food
                {
                    Name="Caldo de Galinha",
                    Weight=10,
                    Price=0.5M,
                    ImagePath="../Images/p1.png",
                    Quantity=1,
           
                    
                },

                new Models.Food
                {
                    Name="Forel",
                    Weight=10,
                    Price=5M,
                    ImagePath="../Images/p2.png",
                    Quantity=1,
              
                },

                new Models.Food
                {
                    Name="Alyonka",
                    Weight=10,
                    Price=2M,
                    ImagePath="../Images/p3.jpg",
                    Quantity=1,
       
                },

                new Models.Food
                {
                    Name="Fiorella",
                    Weight=10,
                    Price=0.5M,
                    ImagePath="../Images/p4.jpg",
                    Quantity=1,
            
                },

                new Models.Food
                {
                    Name="Pistachios",
                    Weight=10,
                    Price=5M,
                    ImagePath="../Images/p5.jpg",
                    Quantity=1,
          
                },

                new Models.Food
                {
                    Name="Azərçay",
                    Weight=100,
                    Price=2.5M,
                    ImagePath="../Images/p6.jpg",
                    Quantity=1,
           
                },

            };
        }
    }
}
