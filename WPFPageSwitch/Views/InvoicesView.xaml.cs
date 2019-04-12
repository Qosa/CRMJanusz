using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Paragraph = iTextSharp.text.Paragraph;

namespace WPFPageSwitch.Views
{
    /// <summary>
    /// Logika interakcji dla klasy InvoicesView.xaml
    /// </summary>
    public partial class InvoicesView : UserControl
    {
        private januszDBEntities7 _db = new januszDBEntities7();

        private ObservableCollection<string> _time_period = new ObservableCollection<string>();
        public ObservableCollection<string> time_period
        {
            get { return _time_period; }
            set
            {
                _time_period = value;
                NotifyPropertyChanged("Auta");
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

        public InvoicesView()
        {
            InitializeComponent();
            transactionsList.ItemsSource = _db.transactions.ToList();
        }

        public ComboBoxItem Selected_item { get; set; }
        private void timeperiodComboBox_Changed(object sender, RoutedEventArgs e)
        {
            time_period.Clear();
            Console.WriteLine(Selected_item);
            if(Selected_item.Content.ToString() == "za miesiac")
            {
                printButton.IsEnabled = false;
                timePeriodComboBox.IsEnabled = true;
                transactionsList.ItemsSource = _db.transactions.ToList();
                foreach (var i in (from m in _db.transactions select m.datetime).Distinct().ToList())
                {
                    Console.WriteLine((Convert.ToDateTime(i)).ToString("MMyyyy"));
                    string date = (Convert.ToDateTime(i)).ToString("yyyy/MM");
                    if (time_period.Count() != 0)
                    {
                        if(time_period[time_period.Count() - 1] == date)
                        {
                            continue;
                        }
                        else
                        {
                            time_period.Add(date);
                        }
                    }
                    else
                    {
                        time_period.Add(date);
                    }
                }
            }
            if (Selected_item.Content.ToString() == "za rok")
            {
                printButton.IsEnabled = false;
                timePeriodComboBox.IsEnabled = true;
                transactionsList.ItemsSource = _db.transactions.ToList();
                foreach (var i in (from m in _db.transactions select m.datetime).Distinct().ToList())
                {
                    Console.WriteLine((Convert.ToDateTime(i)).ToString("yyyy"));
                    string date = (Convert.ToDateTime(i)).ToString("yyyy");
                    if (time_period.Count() != 0)
                    {
                        if (time_period[time_period.Count() - 1] == date)
                        {
                            continue;
                        }
                        else
                        {
                            time_period.Add(date);
                        }
                    }
                    else
                    {
                        time_period.Add(date);
                    }
                }
            }
            if (Selected_item.Content.ToString() == "calosc")
            {
                summary = _db.transactions.ToList();
                transactionsList.ItemsSource = summary;
                printButton.IsEnabled = true;
                timePeriodComboBox.IsEnabled = false;
            }
        }

        public string Selected_item2 { get; set; }
        private void timeperiod2ComboBox_Changed(object sender, RoutedEventArgs e)
        {
            printButton.IsEnabled = true;
            var transactions = (from m in _db.transactions where m.datetime.Contains(Selected_item2) select m).ToList();
            transactionsList.ItemsSource = transactions;
            summary = transactions;
        }
        
        private void Show_Contract_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button b = sender as Button;
            try
            {
                Console.WriteLine(b.CommandParameter);
                System.Diagnostics.Process.Start("C:\\Python Projects\\" + b.CommandParameter);
            }
            catch
            {
                MessageBox.Show("Aby przeglądać/drukować umowy musisz zainstalować program Acrobat Reader! Umowa jest dostępna w katalogu 'umowy'");
            }
        }

        private void Delete_Contract_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button b = sender as Button;
            string caption = "Usun transakcje";
            string messageBoxText = "Czy jestes pewien?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            if (result == MessageBoxResult.Yes)
            {
                int tran_id = Convert.ToInt32(b.CommandParameter);
                var transaction = (from item in _db.transactions where item.id == tran_id select item).FirstOrDefault();
                _db.transactions.Remove(transaction);
                _db.SaveChanges();
                transactionsList.ItemsSource = _db.transactions.ToList();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }

        public List<transactions> summary { get; set; }
        private void Print_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            generatePDF(summary,Selected_item2);
        }

        public class Helper
        {
            string id;
            string datetime;
            string car;
            string price;
            string balance;
            string filename;

            public Helper(string id, string datetime, string car, string price, string balance, string filename)
            {
                this.id = id;
                this.datetime = datetime;
                this.car = car;
                this.price = price;
                this.balance = balance;
                this.filename = filename;
            }
        }

        private void generatePDF(List<transactions> list,string period)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string filename = "raport_" + DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("hhmmss") + ".pdf";
                string file_path = "C:\\Python Projects\\" + filename;
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                Console.WriteLine(file_path);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(file_path, FileMode.Create));
                document.Open();

                Paragraph para = new Paragraph("RAPORT FINANSOWY ZA "+period)
                {
                    Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 16f, Font.BOLD),
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(para);

                PdfPTable table = new PdfPTable(6);

                foreach (var i in list)
                {
                    Helper temp = new Helper(i.id.ToString(), i.datetime, i.car, i.price.ToString(), i.balance.ToString(), i.filename);
                    //string text = i.id + "  " + i.datetime + "  " + i.car + "  " + i.price + "  " + i.balance + "  " + i.filename;
                    foreach (PropertyInfo propertyInfo in temp.GetType().GetProperties())
                    {
                        table.AddCell(propertyInfo.GetValue(temp).ToString());
                    }

                }

                document.Add(table);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                try
                {
                    System.Diagnostics.Process.Start(file_path);
                }
                catch
                {
                    MessageBox.Show("Aby przeglądać/drukować umowy musisz zainstalować program Acrobat Reader! Umowa jest dostępna w katalogu 'umowy'");
                }
            }
        }

    }
}