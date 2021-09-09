using FoodApp.Back_End.Models;
using FoodApp.Back_End.Repo;
using FoodApp.Back_End.ViewModels;
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

namespace FoodApp.ViewModels
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public HistoryWindow HistoryWindows { get; set; }

        public MainWindow MainWindows { get; set; }

        public MainViewModel MainViewModels { get; set; }

        public ObservableCollection<Food> _myHistoryFood;

        public ObservableCollection<Food> MyHistoryFood { get { return _myHistoryFood; } set { _myHistoryFood = value; OnpropertyChanged(); } }

        public Food _food { get; set; }

        public Food HistoryFood { get { return _food; } set { _food = value; OnpropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public FakeRepo FoodRepository { get; set; }


        public ObservableCollection<Food> MyHistoryFood2 = new ObservableCollection<Food>();

        HistoryWindow HistoryWindows2 = new HistoryWindow();
        public HistoryViewModel(string _name, decimal _price, decimal _weight, string _imagePath, decimal _quantity, decimal _sum)
        {
          //  MessageBox.Show($"{_name}");
            var historyWindow = new HistoryWindow();


            var MainWindow = new MainWindow();
            MainViewModels = new MainViewModel();
            MainViewModels.Food = HistoryFood;
            MainViewModels.MainWindows = MainWindow;


            /*
            HistoryFood.Name = _name;
            HistoryFood.Price = _price;
            HistoryFood.Weight = _weight;
                HistoryFood.ImagePath = _imagePath;

            */

            try
            {
                if (MyHistoryFood != null)
                {


                   MyHistoryFood.Add(new Food()
                    {

                        Name = HistoryFood.Name,
                        Price = Convert.ToDecimal(HistoryFood.Price),
                        Weight = Convert.ToDecimal(HistoryFood.Weight),
                        ImagePath = HistoryFood.ImagePath,
                        Quantity = HistoryFood.Quantity,
                        Sum = HistoryFood.Sum,

                    });




                    // historyWindow.Listbox1.Items.Refresh();
                    foreach (var item in MyHistoryFood)
                    {

                        historyWindow.Listbox1.Items.Add(item);

                    }


                    //historyWindow.Listbox1.ItemsSource = null;

                    //historyWindow.Listbox1.Items.Clear();

                    // historyWindow.Listbox1.ItemsSource = null;
                    historyWindow.Listbox1.ItemsSource = MyHistoryFood;


                    MessageBox.Show($"{HistoryFood.Name}");


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            MainWindow.DataContext = MainViewModels;

            //try
            //{


            //    //   HistoryViewModels.MyHistoryFood = Foods;



            //    MyHistoryFood2.Add(new Food()
            //    {

            //        Name = _name,
            //        Price = Convert.ToDecimal(_price),
            //        Weight = Convert.ToDecimal(_weight),
            //        ImagePath = _imagePath,

            //    });
            //        MessageBox.Show(_imagePath);



            //    foreach (var item in MyHistoryFood2)
            //    {

            //        HistoryWindows2.Listbox1.Items.Add(item);

            //    }

            //    HistoryWindows2.Listbox1.ItemsSource = MyHistoryFood2;

            //    if (MyHistoryFood2 == null)
            //    {
            //        MessageBox.Show("eMPTY");
            //    }

            //}
            //catch (Exception)
            //{


            //} 


            //  historyWindow.Listbox1.ItemsSource = null;


        }


        public void addListbox()
        {

        }

        public HistoryViewModel()
        {

            //FoodRepository = new FakeRepo();
            //MyHistoryFood = new ObservableCollection<Food>(FoodRepository.GetAll());


          


    

            //MainWindow.Hide();
            // var firstEven = MyHistoryFood.FirstOrDefault(n => n.Name== MainViewModels.MainWindows.FoodComboBox.SelectedValue);

            //    HistoryWindows.Listbox1.Items.Add(MainViewModels.MainWindows.FoodComboBox.SelectedValue);


        }

    }
}
