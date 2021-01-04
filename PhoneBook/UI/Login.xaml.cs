using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using PhoneBook.Logic;

namespace PhoneBook.UI
{
    public partial class Login : Window
    {
        private string username="";
        private string password="";
        public Login()
        {
            InitializeComponent();
        }
        public void setConnectionStatus(bool status)
        {
            if (!status) connectionStatus.Visibility = Visibility.Visible;
            else connectionStatus.Visibility = Visibility.Hidden;
        }
        private void btn_ShowPassBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            pass_PasswordBox.Visibility = Visibility.Hidden;
            txt_PasswordText.Visibility = Visibility.Visible;
            txt_PasswordText.Text = pass_PasswordBox.Password.ToString();
        }

        private void btn_ShowPassBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            pass_PasswordBox.Visibility = Visibility.Visible;
            txt_PasswordText.Visibility = Visibility.Hidden;
        }

        private void btn_LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            int x = businessLogic.isUserValid (username, password);
            if (x==0)
            {
                wrongUsernameOrPassword.Visibility = Visibility.Visible;
            }
            else
            {
                businessLogic.mainPageViewer(x,0,username);
                this.Close();
            }
        }

        private void lbl_CreateNewAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            lbl_CreateNewAccount.Foreground = Brushes.BurlyWood;
        }

        private void lbl_CreateNewAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl_CreateNewAccount.Foreground = Brushes.Gray;
        }

        private void lbl_CreateNewAccount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            createNewAccount cna = new createNewAccount();
            cna.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cna.ShowDialog();

        }

        private void txt_UserName_keyUp(object sender, KeyEventArgs e)
        {
            username = txt_UserName.Text;
        }

        private void pass_PasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            password = pass_PasswordBox.Password.ToString();
        }
    }
}
