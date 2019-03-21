using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPFPageSwitch.Views;

namespace WPFPageSwitch
{
    /// <summary>
    /// Logika interakcji dla klasy DistanceChanger.xaml
    /// </summary>

    public partial class TuningPage : UserControl, ISwitchable
    {
        public static readonly DependencyProperty PowerValueProperty =
        DependencyProperty.Register("PowerValue", typeof(double), typeof(TuningPage), new UIPropertyMetadata(0.0));

        private double PowerValue
        {
            get { return (double)this.GetValue(PowerValueProperty); }
            set { this.SetValue(PowerValueProperty, value); }
        }

        public static readonly DependencyProperty SwagValueProperty =
        DependencyProperty.Register("SwagValue", typeof(double), typeof(TuningPage), new UIPropertyMetadata(0.0));

        private double SwagValue
        {
            get { return (double)this.GetValue(SwagValueProperty); }
            set { this.SetValue(SwagValueProperty, value); }
        }

        public static readonly DependencyProperty PartsPriceProperty =
        DependencyProperty.Register("PartsPrice", typeof(double), typeof(TuningPage), new UIPropertyMetadata(0.0));

        private double PartsPrice
        {
            get { return (double)this.GetValue(PartsPriceProperty); }
            set { this.SetValue(PartsPriceProperty, value); }
        }

        public TuningPage()
        {
            InitializeComponent();
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

        private void CB1_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 20;
            SwagValue += 15;
            PartsPrice += 100;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB1_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 20;
            SwagValue -= 15;
            PartsPrice -= 100;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB2_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SwagValue += 5;
            PartsPrice += 10;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB2_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            SwagValue -= 5;
            PartsPrice -= 10;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB3_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 25;
            SwagValue += 15;
            PartsPrice += 50;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB3_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 25;
            SwagValue -= 15;
            PartsPrice -= 50;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB4_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 20;
            SwagValue += 10;
            PartsPrice += 30;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB4_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 20;
            SwagValue -= 10;
            PartsPrice -= 30;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB5_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SwagValue += 10;
            PartsPrice += 70;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB5_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            SwagValue -= 10;
            PartsPrice -= 70;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB6_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 10;
            SwagValue += 15;
            PartsPrice += 50;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB6_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 10;
            SwagValue -= 15;
            PartsPrice -= 50;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB7_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 10;
            SwagValue += 10;
            PartsPrice += 80;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB7_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 10;
            SwagValue -= 10;
            PartsPrice -= 80;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB8_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 10;
            SwagValue += 10;
            PartsPrice += 100;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB8_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 10;
            SwagValue -= 10;
            PartsPrice -= 100;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB9_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue += 5;
            SwagValue += 10;
            PartsPrice += 30;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }

        private void CB9_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PowerValue -= 5;
            SwagValue -= 10;
            PartsPrice -= 30;
            System.Console.WriteLine(PowerValue);
            System.Console.WriteLine(SwagValue);
        }
    }
}
