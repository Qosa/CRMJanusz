using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace WPFPageSwitch.Views
{
    /// <summary>
    /// Logika interakcji dla klasy test.xaml
    /// </summary>
    public partial class test : UserControl, INotifyPropertyChanged
    {
        private januszDBEntities7 _db = new januszDBEntities7();
        private ObservableCollection<string> _auta = new ObservableCollection<string>();
        public ObservableCollection<string> Auta
        {
            get { return _auta; }
            set
            {
                _auta = value;
                NotifyPropertyChanged("List");
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
        public test()
        {
            NotifyPropertyChanged("Auta");
            foreach (var i in (from m in _db.import select m.make).Distinct().ToList())
            {
                Auta.Add(i);
                NotifyPropertyChanged("Auta");
            }
            InitializeComponent();
        }

        private void brandComboBox_Changed(object sender, RoutedEventArgs e)
        {
            List<string> modele = new List<string>();
            try
            {
                ComboBoxItem item = brandComboBox.SelectedValue as ComboBoxItem;
                Console.WriteLine(item.Content.ToString());
                modele = (from m in _db.import where m.make == "Ferrari" select m.model).ToList();
                foreach (var i in modele)
                {
                    Console.WriteLine(i);
                }
                NotifyPropertyChanged("ListString");
                Console.WriteLine("DZIALA");
            }
            catch
            {
                Console.WriteLine("ex1");
                return;
            }

            //Console.WriteLine(item.Content.ToString());
            //modelComboBox.ItemsSource = modele;
        }
    }
}
