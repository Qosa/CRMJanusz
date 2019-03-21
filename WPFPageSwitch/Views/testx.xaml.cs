using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFPageSwitch.Views
{
    /// <summary>
    /// Logika interakcji dla klasy testx.xaml
    /// </summary>
    public partial class testx : UserControl
    {
        TSStatic ts1 = (TSStatic)Application.Current.Resources["GlobalTSS"];
        public testx()
        {
            //spanList = ts1.spanList;
            spanList = ts1.spanList[0].ToString();
            InitializeComponent();
            ts1.spanChange += changer;
                foreach (var i in Application.Current.Windows) Console.WriteLine(i);

            //timeBlk1.Text = ts1.ts1[0].ToString();
            //Console.WriteLine("span: "+ts1.ts1[0].ToString());
        }

        private void changer(object sender, EventArgs e)
        {
            timeBlk1.Text = ts1.spanList[0].ToString();
            timeBlk2.Text = ts1.spanList[1].ToString();
            timeBlk3.Text = ts1.spanList[2].ToString();
            McTextBlock.Text = ts1.spanList[2].ToString();
            Console.WriteLine("Current spanlist: "+ spanList.ToString());
        }

        private string _span;
        public string spanList
        {
            get { return _span; }
            set
            {
                _span = value;
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

        private void backClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }

        private void testClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if(Popup1.IsOpen == true)
            {
                Popup1.IsOpen = false;
            } 
            else
            {
                Popup1.IsOpen = true;
            }
            
        }
    }
}
