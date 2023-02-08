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

namespace Chat_App
{
    /// <summary>
    /// Interaction logic for AuthorizationForm.xaml
    /// </summary>
    public partial class AuthorizationForm : Window
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //this.Close();
        }

        private void TextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (TxtBox_Username.Text == "Enter Your Username:")
                TxtBox_Username.Text = "";
        }
    }
}
