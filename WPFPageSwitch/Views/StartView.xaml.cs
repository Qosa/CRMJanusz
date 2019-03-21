using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFPageSwitch.Views;

namespace WPFPageSwitch
{
	public partial class StartView : UserControl, ISwitchable
	{
        TSStatic ts1 = (TSStatic)Application.Current.Resources["GlobalTSS"];
        public StartView()
		{
            InitializeComponent();
            ts1.spanChange += changer;
            try
            {
                mainImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\images\\mirek.png"));
            }
            catch
            {
                TextBlock textIfImageUnavailable = new TextBlock();
                textIfImageUnavailable.Text = "OBRAZEK NIEDOSTEPNY";
                textIfImageUnavailable.Foreground = new SolidColorBrush(Colors.DarkRed);
                textIfImageUnavailable.Margin = new Thickness(130, 150, 100, 150);
                LayoutRoot.Children.Add(textIfImageUnavailable);
                Grid.SetColumn(textIfImageUnavailable, 0);
                Grid.SetRow(textIfImageUnavailable, 0);
            }
            if (ts1.timersList.Count() != 0)
            {   
                importInfo.Content = ts1.timersList.Count();
                importInfo.Visibility = Visibility.Visible;
                //Fill_stackPanel();
            }
            
        }

        private void changer(object sender, EventArgs e)
        {
            for (var i = 0; i < ts1.spanList.Count(); i++)
            {
                object timerBlk = timerStack.FindName("timerBlk" + i.ToString());
                if (timerBlk is TextBlock)
                {
                    TextBlock block = timerBlk as TextBlock;
                    block.Text = ts1.spanList[i].ToString();
                }
            }
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainListView(false));
        }
        private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new SellVehicle());
        }
        private void Button3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainListView(true));
        }
        private void Button4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new testx());
        }
        #endregion

        private void ImportInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            /*
            if (Popup1.IsOpen == true)
            {
                Popup1.IsOpen = false;
            }
            else
            {
                Popup1.IsOpen = true;
            }
            */
            Switcher.Switch(new ImportCars());
        }

        /*
        private void PositionPopup()
        {
            Popup1.VerticalOffset = this.Top + (this.Height - Popup1.Height) / 2;
            Popup1.HorizontalOffset = this.Left + (this.Width - Popup1.Width) / 2;
        }*/
        /*
        private void Fill_stackPanel()
        {
            for (var i = 0; i < ts1.timersList.Count(); i++)
            {
                Console.WriteLine("spanlist: " + ts1.spanList.Count().ToString());
                Console.WriteLine("carlist: " + ts1.carList.Count().ToString());
                Console.WriteLine("timerslist: " + ts1.timersList.Count().ToString());
                Grid grid1 = new Grid();
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(135, GridUnitType.Star);
                ColumnDefinition c2 = new ColumnDefinition();
                c2.Width = new GridLength(50, GridUnitType.Star);
                ColumnDefinition c3 = new ColumnDefinition();
                c3.Width = new GridLength(15, GridUnitType.Star);
                grid1.ColumnDefinitions.Add(c1);
                grid1.ColumnDefinitions.Add(c2);
                grid1.ColumnDefinitions.Add(c3);
                timerStack.Children.Add(grid1);
                TextBlock block1 = new TextBlock();
                Console.WriteLine("aktualnie: " + i.ToString());
                block1.Text = ts1.carList[i];
                block1.Foreground = Brushes.Black;
                Grid.SetColumn(block1, 0);
                RegisterName("timerGrid" + i.ToString(), grid1);
                grid1.Children.Add(block1);
                TextBlock block2 = new TextBlock();
                RegisterName("timerBlk" + i.ToString(), block2);
                block2.Foreground = Brushes.Black;
                Grid.SetColumn(block2, 1);
                grid1.Children.Add(block2);
                Button button = new Button();
                button.Name = "btn" + i.ToString();
                button.Click += (sender, e) => { CancelImport_Click(sender, e, (int)Char.GetNumericValue(button.Name[3])); };
                button.Width = 15;
                button.Height = 15;
                button.Content = "x";
                button.FontSize = 10;
                button.HorizontalContentAlignment = HorizontalAlignment.Left;
                button.VerticalContentAlignment = VerticalAlignment.Top;
                button.Background = Brushes.Red;
                Grid.SetColumn(button, 2);
                grid1.Children.Add(button);
            }
        }

        
        private void CancelImport_Click(object sender, System.Windows.RoutedEventArgs e, int i)
        {
            int timers = ts1.timersList.Count();
            
            //zastopowanie wszystkich timerow
            for(var u = 0; u < timers; u++)
            {
                ts1.timersList[u].Stop();
            }
            ts1.timersList.Clear();
            ts1.spanList.RemoveAt(i);
            ts1.carList.RemoveAt(i);

            //zaladowanie danych z list carList i spanList do tablic tymczasowych i wyczyszczenie ich
            ObservableCollection<TimeSpan> temp_spanList = new ObservableCollection<TimeSpan>();
            List<string> temp_carList = new List<string>();
            for (var t = 0; t < timers - 1; t++)
            {
                temp_spanList.Add(ts1.spanList[t]);
                temp_carList.Add(ts1.carList[t]);
            }
            ts1.spanList.Clear();
            ts1.carList.Clear();

            //usuniecie grida ze stackpanelu zawierajacego usuwany rekord
            for (var l = 0; l < timers; l++)
            {
                object timerGrid = timerStack.FindName("timerGrid" + l.ToString());
                if (timerGrid is Grid)
                {
                    Grid grid = timerGrid as Grid;
                    timerStack.Children.Remove(grid);
                    UnregisterName("timerGrid" + l.ToString());
                    UnregisterName("timerBlk" + l.ToString());
                }
            }

            //powtorne zaladowanie list timersList,carList,spanList juz bez usunietego rekordu
            for (var j = 0; j < timers - 1; j++)
            {
                ts1.timerClock(temp_carList[j], temp_spanList[j], j);
            }
            
            Fill_stackPanel();
            importInfo.Content = ts1.timersList.Count();
            if (ts1.timersList.Count() == 0)
            {
                importInfo.Visibility = Visibility.Visible;
            }
                Popup1.IsOpen = false;

        }*/
    }
}