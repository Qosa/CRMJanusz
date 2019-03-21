using Microsoft.Azure.CognitiveServices.Search.ImageSearch;
using Microsoft.Azure.CognitiveServices.Search.ImageSearch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using WPFPageSwitch.Views;

namespace WPFPageSwitch
{
    public class TSStatic
    {

        private wpfJanuszDBEntities5 _db = new wpfJanuszDBEntities5();
        private ObservableCollection<TimeSpan> _spanList = new ObservableCollection<TimeSpan>();
        public ObservableCollection<TimeSpan> spanList
        {
            get { return _spanList; }
            set
            {
                _spanList = value;
                NotifyPropertyChanged("spanList");
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

        private List<string> _carList = new List<string>();
        public List<string> carList
        {
            get { return _carList; }
            set { _carList = value; }
        }

        private List<cars> _cars = new List<cars>();
        public List<cars> carsList
        {
            get { return _cars; }
            set { _cars = value; }
        }

        private ObservableCollection<MyData> _data = new ObservableCollection<MyData>();
        public ObservableCollection<MyData> data
        {
            get { return _data; }
            set { _data = value; }
        }

        private int _timerColumnNbr = 0;
        public int timerColumnNbr
        {
            get { return _timerColumnNbr; }
            set { _timerColumnNbr = value; }
        }

        private List<DispatcherTimer> _timersList = new List<DispatcherTimer>();
        public List<DispatcherTimer> timersList
        {
            get { return _timersList; }
            set { _timersList = value; }
        }

        private List<int> _tempParkingSlots = new List<int>();
        public List<int> tempParkingSlots
        {
            get { return _tempParkingSlots; }
            set { _tempParkingSlots = value; }
        }

        public ParkingMap pmap { get; set; }

        public void timerClock(cars Car, TimeSpan span, int i)
        {
            spanList.Add(span);
            carsList.Add(Car);
            timersList.Add(new DispatcherTimer());
            timersList[i].Interval = TimeSpan.FromSeconds(1);
            timersList[i].Tick += (sender, e) => { timer_Tick(sender, e, spanList[spanList.Count() - 1], i, Car); }; ;
            timersList[i].Start();
        }

        private static readonly object locker = new object();
        public event EventHandler spanChange;
        public void timer_Tick(object sender, EventArgs e, TimeSpan span, int i, cars Car)
        {
            lock (locker)
            {
                try
                {
                    spanList[i] = spanList[i].Subtract(TimeSpan.FromMinutes(1));
                }
                catch
                {
                    return;
                }
            }
            if (spanList[i] != span) if(spanChange != null) spanChange(this, null);
            if(spanList[i] <= TimeSpan.Zero)
            {
                timersList[i].Stop();
                delete_or_cancel_import(i);
                _db.cars.Add(Car);
                _db.SaveChanges();
            }
        }

        public void delete_or_cancel_import(int i)
        {
            int timers = timersList.Count();

            //zastopowanie wszystkich timerow
            for (var u = 0; u < timers; u++)
            {
                timersList[u].Stop();
            }
            timersList.Clear();
            spanList.RemoveAt(i);
            carsList.RemoveAt(i);
            tempParkingSlots.RemoveAt(i);
            data.RemoveAt(i);

            //zaladowanie danych z list carList i spanList do tablic tymczasowych i wyczyszczenie ich
            ObservableCollection<TimeSpan> temp_spanList = new ObservableCollection<TimeSpan>();
            List<string> temp_carList = new List<string>();
            List<cars> temp_cars = new List<cars>();
            for (var t = 0; t < timers - 1; t++)
            {
                temp_spanList.Add(spanList[t]);
                temp_cars.Add(carsList[t]);
            }
            spanList.Clear();
            carsList.Clear();
            data.Clear();

            //powtorne zaladowanie list timersList,carList,spanList juz bez usunietego rekordu
            for (var j = 0; j < timers - 1; j++)
            {
                timerClock(temp_cars[j], temp_spanList[j], j);
                data.Add(new MyData());
                data[j].Make = carsList[j].make + carsList[j].model + carsList[j].year.ToString();
                data[j].Time = spanList[j];
                data[j].Id = j;
            }
        }

        public IList<ImageObject> GetImagesFromApi(string searchTerm)
        {
            string subscriptionKey = "63a26ea020de4f7f833f549e8ae13b6f";
            Images imageResults = null;

            try
            {
                var client = new ImageSearchClient(new ApiKeyServiceClientCredentials(subscriptionKey));
                imageResults = client.Images.SearchAsync(query: searchTerm).Result;
            }
            catch
            {
                Console.WriteLine("NO INTERNET OR AUTH ERROR");
            }


            if (imageResults == null)
            {
                return null;
            }
            else
            {
                return imageResults.Value;
            }
        }
    }

}

