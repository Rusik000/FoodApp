using FoodApp.Back_End.Command;
using FoodApp.Back_End.Models;
using FoodApp.Back_End.Repo;
using FoodApp.ViewModels;
using FoodApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FoodApp.Back_End.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public FakeRepo FoodRepository { get; set; }


        public ObservableCollection<Food> Foods { get; set; }

        private Food _food;

        public Food Food { get { return _food; } set { _food = value; OnpropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }



        public RelayCommand EditCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }

        public EditViewModel EditViewModel { get; set; }
        public HistoryViewModel HistoryViewModels { get; set; }

        public HistoryWindow HistoryWindows { get; set; }
        public MainWindow MainWindows { get; set; }


        private string _name = "";
        private decimal _weight = 0;
        private decimal _price = 0;
        private string _imagePath = "";

        private decimal _quantity = 0;
        private decimal _sum = 0;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnpropertyChanged(); }
        }

        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value; OnpropertyChanged(); }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; OnpropertyChanged(); }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnpropertyChanged(); }
        }
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnpropertyChanged(); }
        }

        public decimal Sum
        {
            get { return _sum; }
            set { _sum = value; OnpropertyChanged(); }
        }



        public MainViewModel()
        {

            MainWindows = new MainWindow();




            Food = new Food
            {
                Name = "Foods",
                Weight = 0,
                Price = 0,
                ImagePath = "../Images/DefaultImage.png",
                Quantity = 0,
                Sum = 0,
            };




            FoodRepository = new FakeRepo();
            Foods = new ObservableCollection<Food>(FoodRepository.GetAll());


            EditCommand = new RelayCommand((e) =>
            {
  

                var editWindow = new EditWindow();
                EditViewModel = new EditViewModel();
                EditViewModel.EditFood = Food;
                EditViewModel.EditWindows = editWindow; //for close EditView
                editWindow.DataContext = EditViewModel;



                editWindow.ShowDialog();

            });


            HistoryViewModels = new HistoryViewModel();

            ResetCommand = new RelayCommand((e) =>
            {
                Food = new Food
                {
                    Name = "Foods",
                    Weight = 0,
                    Price = 0,
                    ImagePath = "../Images/DefaultImage.png",
                    Quantity = 0,
                    Sum = 0,
                };
            });



            BuyCommand = new RelayCommand((e) =>
            {


       


                Name = Food.Name; Price = Food.Price; Weight = Food.Weight; ImagePath = Food.ImagePath; Quantity = Food.Quantity ; Sum = Food.Sum;




                var historyWindow = new HistoryWindow();

                if (HistoryViewModels.MyHistoryFood == null)
                {

                    HistoryViewModels = new HistoryViewModel(Name, Price, Weight, ImagePath, Quantity, Sum);
                    HistoryViewModels.MyHistoryFood = new ObservableCollection<Food>();
                    for (int i = 0; i < Quantity; i++)
                    {

                    HistoryViewModels.MyHistoryFood.Add(Food);
                    HistoryViewModels.MyHistoryFood.RemoveAt(0);
                    }

              
                }

                if (HistoryViewModels.MyHistoryFood != null)
                {
                    for (int i = 0; i < Quantity; i++)
                    {
                        HistoryViewModels.MyHistoryFood.Add(Food);
                    }
                    

                 
                }


                HistoryViewModels.HistoryWindows= historyWindow;

               var MainWindows = new MainWindow();

                HistoryViewModel historyViewModel = new HistoryViewModel();


                Sum += Food.Quantity * Food.Price;

                Food.Sum = Sum;

      

                

                MessageBox.Show(Sum.ToString());

                historyWindow.DataContext = HistoryViewModels;

                historyWindow.ShowDialog();

               



            });


        }

    }
}
