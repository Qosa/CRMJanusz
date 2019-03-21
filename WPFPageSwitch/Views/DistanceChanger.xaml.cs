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

namespace WPFPageSwitch
{
    /// <summary>
    /// Logika interakcji dla klasy DistanceChanger.xaml
    /// </summary>
    public partial class DistanceChanger : UserControl, ISwitchable
    {
        private int distance = 123456;
        private int temp;
        public DistanceChanger()
        {
            temp = distance;
            InitializeComponent();
            fillTheGauge();
        }

        private void fillTheGauge()
        {
            oneDigit.Text = (distance % 10).ToString();
            tensDigit.Text = ((distance / 10) % 10).ToString();
            hundredsDigit.Text = ((distance / 100) % 10).ToString();
            thousandsDigit.Text = ((distance / 1000) % 10).ToString();
            tensThousandsDigit.Text = ((distance / 10000) % 10).ToString();
            hundredsThousandsDigit.Text = ((distance / 100000) % 10).ToString();
        }

        private void isDistanceOk()
        {
            distanceBar.Value = (Convert.ToDouble(distance) / Convert.ToDouble(temp)) * 100;
            if (distance > temp)
            {
                distanceBar.Foreground = new SolidColorBrush(Colors.DarkRed);
                opinion1.Foreground = new SolidColorBrush(Colors.DarkRed);
                opinion1.Text = "Eee ty!";
                opinion2.Text = "Kto normalny w gore kreci?";
            }
            else if (distance > 0.8*temp)
            {
                distanceBar.Foreground = new SolidColorBrush(Colors.Green);
                opinion1.Text = "Dobrze!";
                opinion1.Foreground = new SolidColorBrush(Colors.Green);
                opinion2.Text = "Na bank nikt sie nie zorientuje";
            } 
            else if(distance < 0.8*temp && distance > 0.6*temp)
            {
                distanceBar.Foreground = new SolidColorBrush(Colors.Orange);
                opinion1.Foreground = new SolidColorBrush(Colors.Orange);
                opinion1.Text = "Uwazaj!";
                opinion2.Text = "No no - czasem nie za duzo?";
            }
            else if(distance < 0.6*temp)
            {
                distanceBar.Foreground = new SolidColorBrush(Colors.Red);
                opinion1.Foreground = new SolidColorBrush(Colors.Red);
                opinion1.Text = "Za duzo!";
                opinion2.Text = "Teraz to na pewno ktos sie skapnie";
            }
        }

        private void checker_up()
        {
            if((distance / 100000) % 10 == 9 && (distance / 10000) % 10 == 9 && (distance / 1000) % 10 == 9 && (distance / 100) % 10 == 9 && (distance / 10) % 10 == 9 && distance % 10 == 9)
            {
                onesButtonUp.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 9 && (distance / 10000) % 10 == 9 && (distance / 1000) % 10 == 9 && (distance / 100) % 10 == 9 && (distance / 10) % 10 == 9)
            {
                tensButtonUp.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 9 && (distance / 10000) % 10 == 9 && (distance / 1000) % 10 == 9 && (distance / 100) % 10 == 9)
            {
                hundredsButtonUp.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 9 && (distance / 10000) % 10 == 9 && (distance / 1000) % 10 == 9)
            {
                thousandsButtonUp.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 9 && (distance / 10000) % 10 == 9)
            {
                tensThousandsButtonUp.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 9)
            {
                hundredsThousandsButtonUp.IsEnabled = false;
            }
        }

        private void checker_down()
        {
            if ((distance / 100000) % 10 == 0 && (distance / 10000) % 10 == 0 && (distance / 1000) % 10 == 0 && (distance / 100) % 10 == 0 && (distance / 10) % 10 == 0 && distance % 10 == 0)
            {
                onesButtonDown.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 0 && (distance / 10000) % 10 == 0 && (distance / 1000) % 10 == 0 && (distance / 100) % 10 == 0 && (distance / 10) % 10 == 0)
            {
                tensButtonDown.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 0 && (distance / 10000) % 10 == 0 && (distance / 1000) % 10 == 0 && (distance / 100) % 10 == 0)
            {
                hundredsButtonDown.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 0 && (distance / 10000) % 10 == 0 && (distance / 1000) % 10 == 0)
            {
                thousandsButtonDown.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 0 && (distance / 10000) % 10 == 0)
            {
                tensThousandsButtonDown.IsEnabled = false;
            }
            if ((distance / 100000) % 10 == 0)
            {
                hundredsThousandsButtonDown.IsEnabled = false;
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

        private void Button_1UP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            onesButtonDown.IsEnabled = true;
            distance += 1;
            fillTheGauge();
            checker_up();
            isDistanceOk();
        }
        private void Button_2UP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tensButtonDown.IsEnabled = true;
            onesButtonDown.IsEnabled = true;
            distance += 10;
            fillTheGauge();
            checker_up();
            isDistanceOk();
        }
        private void Button_3UP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            hundredsButtonDown.IsEnabled = true;
            tensButtonDown.IsEnabled = true;
            onesButtonDown.IsEnabled = true;
            distance += 100;
            fillTheGauge();
            checker_up();
            isDistanceOk();
        }
        private void Button_4UP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            thousandsButtonDown.IsEnabled = true;
            hundredsButtonDown.IsEnabled = true;
            tensButtonDown.IsEnabled = true;
            onesButtonDown.IsEnabled = true;
            distance += 1000;
            fillTheGauge();
            checker_up();
            isDistanceOk();
        }
        private void Button_5UP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tensThousandsButtonDown.IsEnabled = true;
            thousandsButtonDown.IsEnabled = true;
            hundredsButtonDown.IsEnabled = true;
            tensButtonDown.IsEnabled = true;
            onesButtonDown.IsEnabled = true;
            distance += 10000;
            fillTheGauge();
            checker_up();
            isDistanceOk();
        }
        private void Button_6UP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            hundredsThousandsButtonDown.IsEnabled = true;
            tensThousandsButtonDown.IsEnabled = true;
            thousandsButtonDown.IsEnabled = true;
            hundredsButtonDown.IsEnabled = true;
            tensButtonDown.IsEnabled = true;
            onesButtonDown.IsEnabled = true;
            distance += 100000;
            fillTheGauge();
            checker_up();
            isDistanceOk();
        }
        private void Button_1DOWN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            onesButtonUp.IsEnabled = true;
            distance -= 1;
            fillTheGauge();
            checker_down();
            isDistanceOk();
        }
        private void Button_2DOWN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tensButtonUp.IsEnabled = true;
            onesButtonUp.IsEnabled = true;
            distance -= 10;
            fillTheGauge();
            checker_down();
            isDistanceOk();
        }
        private void Button_3DOWN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            hundredsButtonUp.IsEnabled = true;
            tensButtonUp.IsEnabled = true;
            onesButtonUp.IsEnabled = true;
            distance -= 100;
            fillTheGauge();
            checker_down();
            isDistanceOk();
        }
        private void Button_4DOWN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            thousandsButtonUp.IsEnabled = true;
            hundredsButtonUp.IsEnabled = true;
            tensButtonUp.IsEnabled = true;
            onesButtonUp.IsEnabled = true;
            distance -= 1000;
            fillTheGauge();
            checker_down();
            isDistanceOk();
        }
        private void Button_5DOWN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tensThousandsButtonUp.IsEnabled = true;
            thousandsButtonUp.IsEnabled = true;
            hundredsButtonUp.IsEnabled = true;
            tensButtonUp.IsEnabled = true;
            onesButtonUp.IsEnabled = true;
            distance -= 10000;
            fillTheGauge();
            checker_down();
            isDistanceOk();
        }
        private void Button_6DOWN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            hundredsThousandsButtonUp.IsEnabled = true;
            tensThousandsButtonUp.IsEnabled = true;
            thousandsButtonUp.IsEnabled = true;
            hundredsButtonUp.IsEnabled = true;
            tensButtonUp.IsEnabled = true;
            onesButtonUp.IsEnabled = true;
            distance -= 100000;
            fillTheGauge();
            checker_down();
            isDistanceOk();
        }
        private void Test_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isDistanceOk();
        }
    }
}
