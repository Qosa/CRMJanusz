using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Globalization;
using WPFPageSwitch.Views;

namespace WPFPageSwitch
{
    public partial class SellVehicle : UserControl, ISwitchable
    {
        private wpfJanuszDBEntities5 _db = new wpfJanuszDBEntities5();
        private bool _editMode = false;
        private int _id;
        private cars auto;
        private Car Car = new Car();

        public SellVehicle()
        {
            InitializeComponent();
        }

        public SellVehicle(bool editmode,int id)
        {
            InitializeComponent();
            _editMode = editmode;
            _id = id;
            if (_editMode == true)
            {
                auto = (from m in _db.cars where m.id == _id select m).Single();
                markaTextBox.Text = auto.make;
                modelTextBox.Text = auto.model;
                cenaTextBox.Text = auto.price.ToString();
                marzaTextBox.Text = auto.margin.ToString().Replace(',','.');
                rok_produkcjiTextBox.Text = auto.year.ToString();
                poj_silnikaTextBox.Text = auto.displ.ToString();
                przebiegTextBox.Text = auto.mileage.ToString();
                mocTextBox.Text = auto.power.ToString();
                paliwoRadioGroup_checker();
                skrzyniaComboBox_checker();
                opisTextBox.Text = auto.desc;
                zdjecieTextBox.Text = auto.photo;
                parkingGrid.Visibility = Visibility.Visible;
            }
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainListView(true));
        }
        #endregion

        private void paliwoRadioGroup_checker()//ustawia radiobutton paliwo na uprzednio wybrana wartosc w trybie edycji
        {
            if(auto.fuelType == "benzyna")
            {
                benzynaRadioButton.IsChecked = true;
            } 
            else if(auto.fuelType == "diesel")
            {
                dieselRadioButton.IsChecked = true;
            }
            else
            {
                elektrykRadioButton.IsChecked = true;
            }
        }

        private string radioGroup_choice()//sprawdza ktory radiobutton z grupy paliwo zostal wybrany
        {
            if (benzynaRadioButton.IsChecked == true)
            {
                return "benzyna";
            }
            else if (dieselRadioButton.IsChecked == true)
            {
                return "diesel";
            }
            else if (elektrykRadioButton.IsChecked == true)
            {
                return "elektryk";
            }
            else
            {
                return null;
            }
        }

        private void skrzyniaComboBox_checker() //ustawia combobox skrzynia na uprzednio wybrana wartosc w trybie edycji
        {
            if(auto.trany == "Manualna")
            {
                skrzyniaComboBox.SelectedIndex = 0;
            }
            else
            {
                skrzyniaComboBox.SelectedIndex = 1;
            }
        }

        private void typComboBox_Changed(object sender, RoutedEventArgs e) //dostosowuje formularz do wybranego typu pojazdu
        {
            ComboBoxItem item = typComboBox.SelectedValue as ComboBoxItem;
            if (item.Content.ToString() != "Samochod")
            {
                if (fuelGrid == null) return;
                fuelGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                if (fuelGrid == null) return;
                fuelGrid.Visibility = Visibility.Visible;
            }
        }

        private void dodajZdjecie_Click(object sender, RoutedEventArgs e) //klikniecie uruchamia dialog wyboru zdjecia
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                if (System.IO.Directory.Exists(AppDomain.CurrentDomain.GetData("DataDirectory").ToString()))
                {
                    if(System.IO.File.Exists(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\images\\" + System.IO.Path.GetFileName(filename)))
                    {
                        zdjecieTextBox.Text = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\images\\" + System.IO.Path.GetFileName(filename);
                    }
                    else
                    {
                        System.IO.File.Copy(filename, AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\images\\" + System.IO.Path.GetFileName(filename), true);
                        zdjecieTextBox.Text = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\images\\" + System.IO.Path.GetFileName(filename);
                    }
                }
                else
                {
                    MessageBox.Show("Brak katalogu docelowego!");
                    Switcher.Switch(new MainListView(true));
                }

            }
        }

        private static bool IsTextAllowed(string text)//funkcja sprawdzajaca, czy nie wpisano znakow tam gdzie powinny byc cyfry
        {
            Regex _regex = new Regex("[^0-9.,-]+");
            return !_regex.IsMatch(text);
        }

        private bool _isValid = true; //zmienna kontrolujaca walidacje formularza

        private void validationError(Control control) //funkcja wywolywana, jesli pole nie przeszlo walidacji
        {
            control.BorderBrush = Brushes.DarkRed;
            control.BorderThickness = new Thickness(2);
            _isValid = false;
        }
        private void validationOK(TextBox control) //zdjecie czerwonej obwodki w przypadku poprawienia bledu
        {
            control.BorderThickness = new Thickness(0);
        }

        private bool formValidator() //walidacja formularza
        {
            _isValid = true;

                if (markaTextBox.Text == "" || markaTextBox.Text.Length > 50)
                {
                    validationError(markaTextBox);
                }
                else
                {
                    validationOK(markaTextBox);
                }

                if (modelTextBox.Text == "" || modelTextBox.Text.Length > 50)
                {
                    validationError(modelTextBox);
                }
                else
                {
                    validationOK(modelTextBox);
                }

                if (cenaTextBox.Text == "" || !IsTextAllowed(cenaTextBox.Text))
                {
                    validationError(cenaTextBox);
                }
                else
                {
                    validationOK(cenaTextBox);
                }

                if (marzaTextBox.Text == "" || !IsTextAllowed(marzaTextBox.Text))
                {
                    validationError(marzaTextBox);
                }
                else
                {
                    validationOK(marzaTextBox);
                }

                if (rok_produkcjiTextBox.Text == "" || !IsTextAllowed(rok_produkcjiTextBox.Text))
                {
                    validationError(rok_produkcjiTextBox);
                }
                else
                {
                    validationOK(rok_produkcjiTextBox);
                }

                if (mocTextBox.Text == "" || !IsTextAllowed(rok_produkcjiTextBox.Text))
                {
                    validationError(mocTextBox);
                }
                else
                {
                    validationOK(mocTextBox);
                }

                if (radioGroup_choice() == null)
                {
                    paliwoTextBlock.Foreground = new SolidColorBrush(Colors.DarkRed);
                    _isValid = false;
                }
                else
                {
                    validationOK(opisTextBox);
                }

                if (przebiegTextBox.Text == "" || !IsTextAllowed(przebiegTextBox.Text))
                {
                    validationError(przebiegTextBox);
                }
                else
                {
                    validationOK(przebiegTextBox);
                }

                if (poj_silnikaTextBox.Text == "" || !IsTextAllowed(poj_silnikaTextBox.Text))
                {
                    validationError(poj_silnikaTextBox);
                }
                else
                {
                    validationOK(poj_silnikaTextBox);
                }

                if (opisTextBox.Text == "" || zdjecieTextBox.Text.Length > 1000)
                {
                    validationError(opisTextBox);
                }
                else
                {
                    validationOK(opisTextBox);
                }

                if(zdjecieTextBox.Text == "" || zdjecieTextBox.Text.Length > 500)
                {
                    zdjecieTextBox.Text = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\images\\mirekBrak.png";
                }

                if (_isValid == false)
                {
                    MessageBox.Show("Istnieją puste lub nieprawidlowo wypelnione pola. Popraw je!");
                    return _isValid = false;
                }
                else
                {
                    return _isValid = true;
                }
        }

        private void changeParkingSlot_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new ParkingMap(auto));
        }

            private void Sprzedaj_Click(object sender, System.Windows.RoutedEventArgs e)
        {

                if(formValidator() == false) { return; };

                if (_editMode == false)
                {
                    Car.make = markaTextBox.Text;
                    Car.model = modelTextBox.Text;
                    Car.price = Convert.ToInt32(cenaTextBox.Text);
                    Car.margin = Math.Round(float.Parse(marzaTextBox.Text, CultureInfo.GetCultureInfo("en-GB")), 2);
                    Car.year = Convert.ToInt32(rok_produkcjiTextBox.Text);
                    Car.mileage = Convert.ToInt32(przebiegTextBox.Text);
                    Car.displ = Math.Round(float.Parse(poj_silnikaTextBox.Text, CultureInfo.GetCultureInfo("en-GB")), 1);
                    Car.fuelType = radioGroup_choice();
                    Car.power = Convert.ToInt32(mocTextBox.Text);
                    Car.trany = (skrzyniaComboBox.SelectedValue as ComboBoxItem).Content.ToString();
                    Car.desc = opisTextBox.Text;
                    Car.photo = zdjecieTextBox.Text;
                    Switcher.Switch(new ParkingMap(Car));
                }
                else
                {
                    if(auto != null)
                    {
                        auto.make = markaTextBox.Text;
                        auto.model = modelTextBox.Text;
                        auto.price = Convert.ToInt32(cenaTextBox.Text);
                        auto.margin = Math.Round(float.Parse(marzaTextBox.Text, CultureInfo.GetCultureInfo("en-GB")),2);
                        auto.year = Convert.ToInt32(rok_produkcjiTextBox.Text);
                        auto.mileage = Convert.ToInt32(przebiegTextBox.Text);
                        auto.displ = Math.Round(float.Parse(poj_silnikaTextBox.Text, CultureInfo.GetCultureInfo("en-GB")), 1);
                        auto.fuelType = radioGroup_choice();
                        auto.power = Convert.ToInt32(mocTextBox.Text);
                        auto.trany = (skrzyniaComboBox.SelectedValue as ComboBoxItem).Content.ToString();
                        auto.desc = opisTextBox.Text;
                        auto.photo = zdjecieTextBox.Text;
                        System.Console.WriteLine("Text:"+System.IO.Path.GetFileName(zdjecieTextBox.Text));
                        _db.SaveChanges();
                        MessageBox.Show("Pomyslnie edytowano dane pojazdu!");
                        Switcher.Switch(new MainListView(true));
                    }
                    else
                    {
                        MessageBox.Show("Ups! Cos poszlo nie tak. Byc moze pojazdu nie ma w ofercie");
                        Switcher.Switch(new MainListView(true));
                    }
                }
        }

    }
}