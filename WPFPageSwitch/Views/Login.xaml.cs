using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPageSwitch
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : UserControl, ISwitchable
	{
		public Login()
		{
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            InitializeComponent();
        }

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if(usernameTextBox.Text=="admin" && passwordBox.Password.ToString() == "password")
            {
                Switcher.Switch(new StartView());
            } else
            {
                Switcher.Switch(new StartView());
                //MessageBox.Show("Zle haslo!");
            }
			    
		}

        #region ISwitchable Members

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}