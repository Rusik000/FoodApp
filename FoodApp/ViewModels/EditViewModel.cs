using FoodApp.Back_End.Command;
using FoodApp.Back_End.Models;
using FoodApp.Views;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace FoodApp.Back_End.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        public EditWindow EditWindows { get; set; }

        public MainWindow MainWindow { get; set; }

        public MainViewModel MainViewModel { get; set; }

        public ObservableCollection<Food> MyFood { get; set; }

        private Food _food;

        public Food EditFood { get { return _food; } set { _food = value; OnpropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand ChangeImageCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        string imagelocation = "";

        public EditViewModel()
        {
            

            CloseCommand = new RelayCommand((e) =>
            {
                EditWindows.Hide();

                var MainWindow = new MainWindow();

                MainWindow.Show();
            });
            // CloseCommand = new RelayCommand((e) => { MainWindow.Show(); });


            ChangeImageCommand = new RelayCommand((e) =>
            {

                var EditWindow = new EditWindow();

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Media files (*.jpg;*.png;)|*.jpg;*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    imagelocation = openFileDialog.FileName;
                    EditFood.ImagePath = imagelocation;
                    var MainWindow = new MainWindow();




                }

            });

            SaveCommand = new RelayCommand((e) =>
            {
                var MainWindow = new MainWindow();
                MainViewModel = new MainViewModel();
                MainViewModel.Food = EditFood;
                MainViewModel.MainWindows = MainWindow;
                MainWindow.DataContext = MainViewModel;



                EditWindows.Hide();
            });
        }



    }
}
