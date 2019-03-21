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
using System.Threading;
using System.ComponentModel;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Collections;
using Microsoft.Azure.CognitiveServices.Search.ImageSearch.Models;

namespace WPFPageSwitch
{
    public partial class MainListView : UserControl, ISwitchable, INotifyPropertyChanged, IEnumerable
    {
        public bool importCar { get; set; }
        private List<Car> _carsToImport = new List<Car>();
        public List<Car> CarsToImport
        {
            get { return _carsToImport; }
            set
            {
                _carsToImport = value;
            }
        }

        
        private wpfJanuszDBEntities5 _db = new wpfJanuszDBEntities5();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private List<cars> element;
        private Views.progressBar pbar = new Views.progressBar();
        private ObservableCollection<string> _auta = new ObservableCollection<string>();
        public ObservableCollection<string> Auta
        {
            get { return _auta; }
            set
            {
                _auta = value;
                NotifyPropertyChanged("Auta");
            }
        }
        public MainListView(bool importCar)
		{
            this.importCar = importCar;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
            pbar.Owner = Application.Current.MainWindow;
            pbar.ShowDialog();
            //List<string> auta = new List<string>();
            InitializeComponent();
            if (importCar == true)
            {
                makeTextBlock.Visibility = Visibility.Visible;
                brandComboBox.Visibility = Visibility.Visible;
                budgetTextBlock1.Visibility = Visibility.Visible;
                budgetTextBlock2.Visibility = Visibility.Visible;
                searchLabel.Visibility = Visibility.Hidden;
                searchButton.Visibility = Visibility.Hidden;
                searchComboBox.Visibility = Visibility.Hidden;
                searchTextBox.Visibility = Visibility.Hidden;
                sortComboBox.Visibility = Visibility.Hidden;
                sortTextBlock.Visibility = Visibility.Hidden;
                //listbox1.Visibility = Visibility.Hidden;
                foreach(var i in (from m in _db.import select m.make).Distinct().ToList()){
                    Auta.Add(i);
                }
                //brandComboBox.ItemsSource = auta;
                //List<import> to_import_list = new List<import>();
                //to_import_list = _db.import.ToList();
                //listbox1.ItemsSource = to_import_list;
            } else
            {
                listbox1.ItemsSource = element;
            }
        }
        private ObservableCollection<string> _modele = new ObservableCollection<string>();
        public ObservableCollection<string> Modele
        {
            get { return _modele; }
            set
            {
                _modele = value;
                NotifyPropertyChanged("Modele");
            }
        }

        private ObservableCollection<string> _years = new ObservableCollection<string>();
        public ObservableCollection<string> Years
        {
            get { return _years; }
            set
            {
                _years = value;
                NotifyPropertyChanged("Years");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
                worker.ReportProgress(i);
            }
            element = _db.cars.ToList();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbar.prgTest.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbar.Close();
        }

        public string MyItem { get; set; }
        private void brandComboBox_Changed(object sender, RoutedEventArgs e)
        {
            modelTextblock.Visibility = Visibility.Visible;
            modelComboBox.Visibility = Visibility.Visible;
            Modele.Clear();
            Years.Clear();
            List<string> modele = new List<string>();
            try
            {
                modele = (from m in _db.import where m.make == MyItem select m.model).Distinct().ToList();
                foreach (var i in modele)
                {
                    Modele.Add(i);
                    //Console.WriteLine(i);
                }
                NotifyPropertyChanged("Modele");
            }
            catch
            {
                Console.WriteLine("ex1");
                return;
            }

            //Console.WriteLine(item.Content.ToString());


            //modelComboBox.ItemsSource = modele;
        }

        public string MyItem2 { get; set; }
        private void modelComboBox_Changed(object sender, RoutedEventArgs e)
        {
            yearTextblock.Visibility = Visibility.Visible;
            yearComboBox.Visibility = Visibility.Visible;
            Years.Clear();
            List<Int64> years = new List<Int64>();
            years = (from m in _db.import where m.make == MyItem && m.model == MyItem2 select m.year).Distinct().ToList();
            foreach (var i in years)
            {
                Years.Add(i.ToString());
                Console.WriteLine(i);
            }
            try
            {

                NotifyPropertyChanged("Years");
            }
            catch
            {
                Console.WriteLine("ex1");
                return;
            }
        }

        public string MyItem3 { get; set; }
        private void yearComboBox_Changed(object sender, RoutedEventArgs e)
        {
            if(MyItem3 == null)
            {
                CarsToImport.Clear();
            } else
            {
                CarsToImport.Clear();
                listbox1.Items.Refresh();
                Import_car_generator(MyItem, MyItem2, MyItem3);
                listbox1.ItemsSource = CarsToImport;
                listbox1.Items.Refresh();
            }
        } 

        private void item_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(importCar == true)
            {
                if (listbox1.Items.IndexOf(listbox1.SelectedItem) >= 0)
                {
                    int Id = Convert.ToInt32(CarsToImport[listbox1.Items.IndexOf(listbox1.SelectedItem)].id);
                    Switcher.Switch(new DetailView(CarsToImport[Id]));
                }
            } else
            {
                if (listbox1.Items.IndexOf(listbox1.SelectedItem) >= 0)
                {
                    int Id = Convert.ToInt32(element[listbox1.Items.IndexOf(listbox1.SelectedItem)].id);
                    Switcher.Switch(new DetailView(Id));
                }
            }
        }

        private void search_Button(object sender, RoutedEventArgs e)
        {
            List<cars> auta = new List<cars>();
            ComboBoxItem item = searchComboBox.SelectedValue as ComboBoxItem;
            if (item.Content.ToString() == "Marka")
            {
                if (listbox1 == null) return;
                try
                {
                    auta = (from m in _db.cars where m.make == searchTextBox.Text select m).ToList();
                } catch
                {
                    MessageBox.Show("Blad zapytania do bazy danych! Sprobuj ponownie pozniej");
                }

                bool isEmpty = !auta.Any();
                if (isEmpty)
                {
                    MessageBox.Show("Niczego nie znaleziono!");
                    Switcher.Switch(new MainListView(true));
                }
                else
                {
                    listbox1.ItemsSource = auta;
                    element = auta;
                }
            }
            if (item.Content.ToString() == "Model")
            {
                if (listbox1 == null) return;
                try
                {
                    auta = (from m in _db.cars where m.model == searchTextBox.Text select m).ToList();
                }
                catch
                {
                    MessageBox.Show("Blad zapytania do bazy danych! Sprobuj ponownie pozniej");
                }

                bool isEmpty = !auta.Any();
                if (isEmpty)
                {
                    MessageBox.Show("Niczego nie znaleziono!");
                    Switcher.Switch(new MainListView(true));
                }
                else
                {
                    listbox1.ItemsSource = auta;
                    element = auta;
                }
            }
        }

        private void sortComboBox_Changed(object sender, RoutedEventArgs e)
        {
            List<cars> auta = new List<cars>();
            ComboBoxItem item = sortComboBox.SelectedValue as ComboBoxItem;
            Console.WriteLine(item.Content.ToString());
            if (item.Content.ToString() == "Alfabetycznie - Marka")
            {
                if (listbox1 == null) return;
                try
                {
                    auta = _db.cars.OrderBy(auto => auto.make).ToList();
                }
                catch
                {
                    MessageBox.Show("Blad zapytania do bazy danych! Sprobuj ponownie pozniej");
                }

                element = auta;
                listbox1.ItemsSource = auta;
            }
            if (item.Content.ToString() == "Alfabetycznie - Model")
            {
                if (listbox1 == null) return;
                try
                {
                    auta = _db.cars.OrderBy(auto => auto.model).ToList();
                }
                catch
                {
                    MessageBox.Show("Blad zapytania do bazy danych! Sprobuj ponownie pozniej");
                }

                element = auta;
                listbox1.ItemsSource = auta;
            }
            if (item.Content.ToString() == "Cena")
            {
                if (listbox1 == null) return;
                try
                {
                    auta = _db.cars.OrderBy(auto => auto.price).ToList();
                }
                catch
                {
                    MessageBox.Show("Blad zapytania do bazy danych! Sprobuj ponownie pozniej");
                }
                
                element = auta;
                listbox1.ItemsSource = auta;
            }
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void loginTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Switcher.Switch(new Login());
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }
        #endregion

        TSStatic ts1 = (TSStatic)Application.Current.Resources["GlobalTSS"];
        public void Import_car_generator(string make, string model, string year)
        {
            IList<ImageObject> images = ts1.GetImagesFromApi(make + " " + model + " " + year.ToString());
            Int64 year2 = Convert.ToInt64(year);
            int idCounter = 0;
            Random rnd2 = new Random();
            var qua = rnd2.Next(1, 4);
            Console.WriteLine(qua);
            var template = (from m in _db.import where m.make == make && m.model == model && m.year == year2 select m).Distinct().ToList();
            Console.WriteLine("Funkcja dziala");
            for (int i = 0; i <= qua; i++)
            {
                Car car = new Car();
                Console.WriteLine("FLAGA");
                foreach (var x in template)
                {
                    car.id = idCounter;
                    car.make = x.make;
                    car.model = x.model;
                    car.year = x.year;
                    car.displ = x.displ;
                    car.trany = x.trany;
                    car.fuelType = x.fuelType;
                    car.desc = "";
                    try
                    {
                        car.photo = images[i].ContentUrl;
                    }
                    catch
                    {
                        return;
                    }

                    if (x.year > 2005)
                    {
                        if (x.displ > 3.5 && x.VClass == "Two Seaters")
                        {
                            car.price = rnd2.Next(200000, 1000000);
                            car.margin = 0.15;
                        }
                        else if (x.displ > 3.5)
                        {
                            car.price = rnd2.Next(100000, 500000);
                            car.margin = 0.15;
                        }
                        else if (x.VClass == "Large Cars")
                        {
                            car.price = rnd2.Next(100000, 1000000);
                            car.margin = 0.15;
                        }
                        else if (x.VClass == "Midsize Cars")
                        {
                            car.price = rnd2.Next(50000, 200000);
                            car.margin = 0.12;
                        }
                        else
                        {
                            car.price = rnd2.Next(10000, 200000);
                            car.margin = 0.11;
                        }
                    }
                    else if (x.year < 2005 && x.year > 1995)
                    {
                        if (x.displ > 3.5 && x.VClass == "Two Seaters")
                        {
                            car.price = rnd2.Next(100000, 500000);
                            car.margin = 0.15;
                        }
                        else if (x.displ > 3.5)
                        {
                            car.price = rnd2.Next(250000, 1500000);
                            car.margin = 0.15;
                        }
                        else if (x.VClass == "Large Cars")
                        {
                            car.price = rnd2.Next(30000, 200000);
                            car.margin = 0.15;
                        }
                        else if (x.VClass == "Midsize Cars")
                        {
                            car.price = rnd2.Next(5000, 50000);
                            car.margin = 0.12;
                        }
                        else
                        {
                            car.price = rnd2.Next(1000, 50000);
                            car.margin = 0.11;
                        }
                    }
                    else
                    {
                        if (x.displ > 3.5 && x.VClass == "Two Seaters")
                        {
                            car.price = rnd2.Next(10000, 1000000);
                            car.margin = 0.15;
                        }
                        else if (x.displ > 3.5)
                        {
                            car.price = rnd2.Next(5000, 200000);
                            car.margin = 0.15;
                        }
                        else if (x.VClass == "Large Cars")
                        {
                            car.price = rnd2.Next(10000, 1000000);
                            car.margin = 0.15;
                        }
                        else if (x.VClass == "Midsize Cars")
                        {
                            car.price = rnd2.Next(5000, 200000);
                            car.margin = 0.12;
                        }
                        else
                        {
                            car.price = rnd2.Next(10000, 200000);
                            car.margin = 0.11;
                        }
                    }
                }
                CarsToImport.Add(car);
                Console.WriteLine(idCounter);
                idCounter++;
            }
            Console.WriteLine(CarsToImport.Count());
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}