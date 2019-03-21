using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFPageSwitch.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ParkingMap.xaml
    /// </summary>
    public partial class ParkingMap : UserControl, INotifyPropertyChanged
    {
        private wpfJanuszDBEntities5 _db = new wpfJanuszDBEntities5();
        private cars editedCar;
        private Car Car;
        private bool editMode = false;
        public event PropertyChangedEventHandler PropertyChanged;
        private int _place;
        public delegate void Del(TimeSpan _time);
        public int counter;
        //private List<TimeSpan> ts1 = new List<TimeSpan>();
        TSStatic ts1 = (TSStatic)Application.Current.Resources["GlobalTSS"];
        public int Place
        {
            get { return _place; }
            set { _place = value; NotifyPropertyChanged("Place"); }
        }

        public ParkingMap(cars Car)
        {
            editMode = true;
            this.editedCar = Car;
            InitializeComponent();
            parkingButton.IsEnabled = false;
            isItBusy();
            string name = "P" + editedCar.parking.ToString();
            object parkingPlace = ParkingSlots.FindName(name);
            if (parkingPlace is Button)
            {
                Console.WriteLine("P" + editedCar.parking.ToString());
                Button button = parkingPlace as Button;
                button.Background = Brushes.Red;
            }
            else
            {
                Console.WriteLine("P" + editedCar.parking.ToString());
            }
        }

        public ParkingMap(Car Car)
        {
            this.Car = Car;
            InitializeComponent();
            parkingButton.IsEnabled = false;
            isItBusy();
        }



        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void isItBusy()
        {
            for(int i=1; i <=30; i++)
            {
                string name = "P" + i.ToString();
                object parkingPlace = ParkingSlots.FindName(name);
                if(parkingPlace is Button)
                {
                    var query = (from m in _db.cars where m.parking == i select m.parking);
                    int result = Convert.ToInt16(query.FirstOrDefault());
                    Button button = parkingPlace as Button;

                    if(editMode == true)
                    {
                        if (i == editedCar.parking)
                        {
                            button.Background = Brushes.Red;
                            button.IsHitTestVisible = false;
                            Place = Convert.ToInt32(editedCar.parking);
                        }
                        else if (result != 0)
                        {
                            button.IsEnabled = false;
                        }
                        else
                        {
                            button.Background = Brushes.Green;
                        }
                    }
                    else
                    {
                        if (result != 0)
                        {
                            button.IsEnabled = false;
                        }
                        else
                        {
                            button.Background = Brushes.Green;
                        }
                    }

                }
            }

            foreach (var i in ts1.tempParkingSlots)
            {
                string name = "P" + i.ToString();
                object parkingPlace = ParkingSlots.FindName(name);
                if (parkingPlace is Button)
                {
                    Button button = parkingPlace as Button;
                    button.IsEnabled = false;
                }
            }
        }

        private void Busy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("To miejsce jest juz zajete!");
        }

        private void P1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 1;
            parkingButton.IsEnabled = true;
        }

        private void P2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 2;
            parkingButton.IsEnabled = true;
        }

        private void P3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 3;
            parkingButton.IsEnabled = true;
        }

        private void P4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 4;
            parkingButton.IsEnabled = true;
        }

        private void P5_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 5;
            parkingButton.IsEnabled = true;
        }

        private void P6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 6;
            parkingButton.IsEnabled = true;
        }

        private void P7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 7;
            parkingButton.IsEnabled = true;
        }

        private void P8_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 8;
            parkingButton.IsEnabled = true;
        }

        private void P9_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 9;
            parkingButton.IsEnabled = true;
        }

        private void P10_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 10;
            parkingButton.IsEnabled = true;
        }

        private void P11_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 11;
            parkingButton.IsEnabled = true;
        }

        private void P12_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 12;
            parkingButton.IsEnabled = true;
        }

        private void P13_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 13;
            parkingButton.IsEnabled = true;
        }

        private void P14_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 14;
            parkingButton.IsEnabled = true;
        }

        private void P15_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 15;
            parkingButton.IsEnabled = true;
        }

        private void P16_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 16;
            parkingButton.IsEnabled = true;
        }

        private void P17_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 17;
            parkingButton.IsEnabled = true;
        }

        private void P18_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 18;
            parkingButton.IsEnabled = true;
        }

        private void P19_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 19;
            parkingButton.IsEnabled = true;
        }

        private void P20_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 20;
            parkingButton.IsEnabled = true;
        }

        private void P21_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 21;
            parkingButton.IsEnabled = true;
        }

        private void P22_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 22;
            parkingButton.IsEnabled = true;
        }

        private void P23_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 23;
            parkingButton.IsEnabled = true;
        }

        private void P24_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 24;
            parkingButton.IsEnabled = true;
        }

        private void P25_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 25;
            parkingButton.IsEnabled = true;
        }

        private void P26_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 26;
            parkingButton.IsEnabled = true;
        }

        private void P27_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 27;
            parkingButton.IsEnabled = true;
        }

        private void P28_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 28;
            parkingButton.IsEnabled = true;
        }

        private void P29_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 29;
            parkingButton.IsEnabled = true;
        }

        private void P30_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Place = 30;
            parkingButton.IsEnabled = true;
        }

        private void backClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }

        private readonly BackgroundWorker worker = new BackgroundWorker();
        private void apply_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(Place == 0)
            {
                MessageBox.Show("Nie wybrano miejsca!");
            } else
            {
                if (editMode == true)
                {
                    editedCar.parking = Place;
                    cars auto = (from m in _db.cars where m.id == editedCar.id select m).Single();
                    auto.parking = Place;
                    _db.SaveChanges();
                }
                else
                {
                    Car.parking = Place;
                    Console.WriteLine(Car.model);
                    Console.WriteLine(Car.parking);
                    cars newCar = new cars();
                    newCar.make = Car.make;
                    newCar.model = Car.model;
                    newCar.price = Convert.ToInt32(Car.price);
                    newCar.margin = Car.margin;
                    newCar.mileage = Car.mileage;
                    newCar.power = Convert.ToInt32(Car.power);
                    newCar.year = Convert.ToInt32(Car.year);
                    newCar.trany = Car.trany;
                    newCar.parking = Car.parking;
                    newCar.desc = Car.desc;
                    newCar.displ = Car.displ;
                    newCar.fuelType = Car.fuelType;
                    newCar.parking = Place;

                    Random rand = new Random();
                    int hr = rand.Next(1, 9);
                    int min = rand.Next(1, 59);
                    ts1.timerClock(newCar, new TimeSpan(hr, min, 1), ts1.timersList.Count());
                    ts1.tempParkingSlots.Add(Place);
                    ts1.timerColumnNbr++;

                    MessageBox.Show("Pomyslnie dodano pojazd do oferty!");
                    Switcher.Switch(new MainListView(true)); 
                }
            }
        }
    }
}
