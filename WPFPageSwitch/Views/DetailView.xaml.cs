using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using WPFPageSwitch.Views;

namespace WPFPageSwitch
{
    /// <summary>
    /// Logika interakcji dla klasy DetailView.xaml
    /// </summary>
    public partial class DetailView : UserControl, ISwitchable
    {
        private januszDBEntities7 _db = new januszDBEntities7();
        private int ID { get; set; }

        private cars auto;
        private Car Car;

        public DetailView(int samochod)
        {
            InitializeComponent();
            ID = samochod;
            System.Console.WriteLine(ID);
            auto = (from m in _db.cars where m.id == ID select m).Single();
            markamodelTextBlock.Text = auto.make+" "+auto.model;
            cenaTextBlock.Text = auto.price.ToString();
            marzaTextBlock.Text = auto.price.ToString();
            rokprodTextBlock.Text = auto.year.ToString();
            pojsilTextBlock.Text = auto.displ.ToString();
            paliwoTextBlock.Text = auto.fuelType;
            przebiegTextBlock.Text = auto.mileage.ToString();
            opisTextBlock.Text = auto.desc;
            powerTextBlock.Text = auto.power.ToString();
            tranyTextBlock.Text = auto.trany;

            if (auto.photo == "")
            {
                return;
            }
            else
            {
                try
                {
                    autoImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(auto.photo));
                }
                catch
                {
                    TextBlock textIfImageUnavailable = new TextBlock();
                    textIfImageUnavailable.Text = "OBRAZEK NIEDOSTEPNY";
                    textIfImageUnavailable.Foreground = new SolidColorBrush(Colors.DarkRed);
                    textIfImageUnavailable.Margin = new Thickness(150, 0, 0, 150);
                    LayoutRoot.Children.Add(textIfImageUnavailable);
                    Grid.SetRow(textIfImageUnavailable, 2);
                    Grid.SetColumn(textIfImageUnavailable, 0);
                }
            }
        }

        public DetailView(Car Car)
        {
            InitializeComponent();
            editButton.Visibility = Visibility.Hidden;
            distanceChangerButton.Visibility = Visibility.Hidden;
            tuningButton.Visibility = Visibility.Hidden;
            deleteButton.Visibility = Visibility.Hidden;
            importButton.Visibility = Visibility.Visible;
            System.Console.WriteLine(ID);
            this.Car = Car;
            markamodelTextBlock.Text = Car.make + " " + Car.model;
            cenaTextBlock.Text = Car.price.ToString();
            marzaTextBlock.Text = Car.margin.ToString();
            rokprodTextBlock.Text = Car.year.ToString();
            pojsilTextBlock.Text = Car.displ.ToString();
            paliwoTextBlock.Text = Car.fuelType;
            przebiegTextBlock.Text = Car.mileage.ToString();
            opisTextBlock.Text = Car.desc;
            powerTextBlock.Text = Car.power.ToString();
            tranyTextBlock.Text = Car.trany;

            if (Car.photo == "")
            {
                return;
            }
            else
            {
                try
                {
                    autoImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Car.photo));
                }
                catch
                {
                    TextBlock textIfImageUnavailable = new TextBlock();
                    textIfImageUnavailable.Text = "OBRAZEK NIEDOSTEPNY";
                    textIfImageUnavailable.Foreground = new SolidColorBrush(Colors.DarkRed);
                    textIfImageUnavailable.Margin = new Thickness(150, 0, 0, 150);
                    LayoutRoot.Children.Add(textIfImageUnavailable);
                    Grid.SetRow(textIfImageUnavailable, 2);
                    Grid.SetColumn(textIfImageUnavailable, 0);
                }
            }
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }
        #endregion

        private void sell_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new BuyerDataForm(auto));
        }

        private void edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new SellVehicle(true,ID));
        }

        private void distanceChanger_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new DistanceChanger());
        }

        private void tuning_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new TuningPage());
        }

        private void import_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new ParkingMap(Car));
        }

        private void delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string messageBoxText = "Czy jestes pewien?";
            string caption = "Usun pojazd";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            if(result == MessageBoxResult.Yes)
            {
                _db.cars.Remove(auto);
                _db.SaveChanges();
                Switcher.Switch(new MainListView(true));
            }
        }

    }
}
