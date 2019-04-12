using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPageSwitch.Views
{
    /// <summary>
    /// Logika interakcji dla klasy BuyerDataForm.xaml
    /// </summary>
    public partial class BuyerDataForm : UserControl
    {
        private januszDBEntities7 _db = new januszDBEntities7();
        TSStatic ts1 = (TSStatic)Application.Current.Resources["GlobalTSS"];
        private cars Car;

        private string _filename;
        public string filename { get; set; }

        public BuyerDataForm(cars Car)
        {
            this.Car = Car;
            InitializeComponent();
        }

        private void generatePDF()
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            { 
                string file_path = "C:\\Python Projects\\" + filename;
                string seller_name = "Komis Janusz";
                string seller_address = "Januszkowice 123, 25-001 Klerykow";
                string seller_companyid = "123-456-789";
                string car = Car.make + " " + Car.model;
                string car_year = Car.year.ToString();
                string car_price = Car.price.ToString();
                    
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                Console.WriteLine(file_path);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(file_path, FileMode.Create));
                document.Open();

                Paragraph para = new Paragraph("UMOWA SPRZEDAZY SAMOCHODU")
                {
                    Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 16f, Font.BOLD),
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(para);

                string text = "Zawarta w Poznaniu dnia " + ((System.DateTime.Now).Date).ToString() + " pomiędzy: \n" +
                seller_name + "," + seller_address + ", Numer NIP: " + seller_companyid +
                "\n a \n" +
                buyer_name.Text +" "+buyer_surname.Text + " , legitymującym się dowodem osobistym o numerze " + buyer_idnumber.Text +
                " , zamieszkałym w " + buyer_address.Text + " " + buyer_postalcode.Text + " " + buyer_postalcity.Text;
                Paragraph paragraph = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER,
                    Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12f)
                };
                paragraph.Add(text);

                string text2 = "§ 1 \nPrzedmiotem niniejszym umowy jest przeniesienie przez Sprzedającego na Kupującego prawa własności pojazdu " + car + " , rok produkcji " + car_year;
                Paragraph paragraph2 = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER
                };
                paragraph2.Add(text2);

                string text3 = "§ 2 \nSprzedający oświadcza, że pojazd będący przedmiotem umowy stanowi jego własność i jest wolny od wad prawnych. ";
                Paragraph paragraph3 = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER
                };
                paragraph3.Add(text3);

                string text4 = "§ 3 \nStrony zgodnie ustalają cenę sprzedaży samochodu określonego w § 1 niniejszej na kwotę: " + car_price;
                Paragraph paragraph4 = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER
                };
                paragraph4.Add(text4);

                string text5 = "§ 4 \nKupujący oświadcza, że stan techniczny pojazdu jest mu znany i nie wnosi do niego zastrzeżeń.";
                Paragraph paragraph5 = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER
                };
                paragraph5.Add(text5);

                string text6 = "§ 5 \n1. W sprawach nieuregulowanych w niniejszej umowie zastosowanie mają obowiązujące w tym zakresie przepisy kodeksu cywilnego.\n2.Wszelkie zmiany niniejszej umowy wymagają dla swej ważności formy pisemnej pod rygorem nieważności.\n3.Niniejszą umowę sporządzono w dwóch jednobrzmiących egzemplarzach, po jednym dla każdej ze stron. ";
                Paragraph paragraph6 = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER
                };
                paragraph6.Add(text6);

                string text7 = "KUPUJACY                                                           SPRZEDAJACY ";
                Paragraph paragraph7 = new Paragraph
                {
                    SpacingBefore = 10,
                    SpacingAfter = 10,
                    Alignment = Element.ALIGN_CENTER
                };
                paragraph7.Add(text7);

                document.Add(paragraph);
                document.Add(paragraph2);
                document.Add(paragraph3);
                document.Add(paragraph4);
                document.Add(paragraph5);
                document.Add(paragraph6);
                document.Add(paragraph7);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                try
                {
                    System.Diagnostics.Process.Start("C:\\Python Projects\\" + filename);
                }
                catch
                {
                    MessageBox.Show("Aby przeglądać/drukować umowy musisz zainstalować program Acrobat Reader! Umowa jest dostępna w katalogu 'umowy'");
                }
            }
        }

        private static bool IsTextAllowed(string text)//funkcja sprawdzajaca, czy nie wpisano znakow tam gdzie powinny byc cyfry
        {
            Regex _regex = new Regex("[^0-9.,-]+");
            return !_regex.IsMatch(text);
        }

        private bool _isValid;
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

        private bool formValidator()
        {
            _isValid = true;

            if(buyer_name.Text == "")
            {
                validationError(buyer_name);
            }
            else
            {
                validationOK(buyer_name);
            }
            if (buyer_surname.Text == "")
            {
                validationError(buyer_surname);
            }
            else
            {
                validationOK(buyer_surname);
            }
            if (buyer_idnumber.Text == "")
            {
                validationError(buyer_idnumber);
            }
            else
            {
                validationOK(buyer_idnumber);
            }
            if (buyer_address.Text == "")
            {
                validationError(buyer_address);
            }
            else
            {
                validationOK(buyer_address);
            }
            if (buyer_postalcode.Text == "" || !IsTextAllowed(buyer_postalcode.Text))
            {
                validationError(buyer_postalcode);
            }
            else
            {
                validationOK(buyer_postalcode);
            }
            if (buyer_postalcity.Text == "" || IsTextAllowed(buyer_postalcity.Text))
            {
                validationError(buyer_postalcity);
            }
            else
            {
                validationOK(buyer_postalcity);
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

        private void apply_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (formValidator() == false)
            {
                return;
            }
            else
            {
                filename = "umowa_" + DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("hhmmss") + ".pdf";
                transactions transaction = new transactions();
                ts1.budget += Car.price;
                transaction.balance = ts1.budget;
                transaction.buyer_address = buyer_address.Text;
                transaction.buyer_city = buyer_postalcity.Text;
                transaction.buyer_postalcode = buyer_postalcode.Text;
                transaction.buyer_idnbr = buyer_idnumber.Text;
                transaction.car = Car.make + " " + Car.model;
                transaction.buyer_name = buyer_name.Text;
                transaction.buyer_surname = buyer_surname.Text;
                transaction.datetime = (DateTime.Now).ToString();
                transaction.price = Car.price;
                transaction.tr_type = "SPRZEDAZ";
                transaction.filename = filename;
                _db.transactions.Add(transaction);
                _db.SaveChanges();
                generatePDF();
                //_db.cars.Remove(Car)
                Switcher.Switch(new StartView());
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new StartView());
        }
    }
}
