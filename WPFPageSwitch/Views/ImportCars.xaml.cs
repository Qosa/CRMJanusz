using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy ImportCars.xaml
    /// </summary>
    public partial class ImportCars : UserControl
    {
        TSStatic ts1 = (TSStatic)Application.Current.Resources["GlobalTSS"];
        
        public ImportCars()
        {
            ts1.spanChange += changer;
            InitializeComponent();
            ts1.data.Clear();
            carsDuringImport.ItemsSource = ts1.data;
            for (var i = 0; i < ts1.timersList.Count(); i++)
            {
                ts1.data.Add(new MyData());
                ts1.data[i].Make = ts1.carsList[i].make + ts1.carsList[i].model + ts1.carsList[i].year.ToString();
                ts1.data[i].Time = ts1.spanList[i];
                ts1.data[i].Id = i;
            }
        }

        private void changer(object sender, EventArgs e)
        {
            for (var i = 0; i < ts1.data.Count(); i++)
            {
                ts1.data[i].Time = ts1.spanList[i];
            }
            carsDuringImport.Items.Refresh();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Console.WriteLine(b.CommandParameter);
        }

        private void CancelImport_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button b = sender as Button;
            int i = Convert.ToInt16(b.CommandParameter);
            ts1.delete_or_cancel_import(i);
        }
    }
}
