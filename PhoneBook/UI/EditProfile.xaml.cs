using PhoneBook.Logic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PhoneBook.UI
{
    public partial class EditProfile : Window
    {
        private int userid;
        public EditProfile(int userid, string suername)
        {
            InitializeComponent();
            lblDisplayName.Content = "Hi " + suername;
            this.userid = userid;
        }

        private void btnConfirm_MouseEnter(object sender, MouseEventArgs e)
        {
            btnConfirm.Foreground = Brushes.Black;
        }

        private void btnConfirm_MouseLeave(object sender, MouseEventArgs e)
        {
            btnConfirm.Foreground = Brushes.White;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!txtPasswordToConfirm.Password.ToString().Equals(""))
            {
                if (businessLogic.isPasswordValid(userid, txtPasswordToConfirm.Password.ToString()))
                {
                    enterPasswordWarning.Visibility = Visibility.Hidden;
                    passwordGrid.Visibility = Visibility.Hidden;
                    editGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    enterPasswordWarning.Visibility = Visibility.Visible;
                    enterPasswordWarning.Content = "Invalid Password";
                }
            }
            else
            {
                enterPasswordWarning.Visibility = Visibility.Visible;
                enterPasswordWarning.Content = "Enter Your Password First";
            }
        }

        private void btnSave_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSave.Foreground = Brushes.Black;
        }

        private void btnSave_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSave.Foreground = Brushes.White;
        }

        private void btnCancel_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCancel.Foreground = Brushes.Black;
        }

        private void btnCancel_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCancel.Foreground = Brushes.White;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {

            if (!newpassword.Password.ToString().Equals("") && !confirmednewpassword.Password.ToString().Equals(""))
            {
                if (newpassword.Password.ToString().Equals(confirmednewpassword.Password.ToString()))
                {
                    if (businessLogic.IsPasswordValid(newpassword.Password.ToString()))
                    {
                        if (businessLogic.updateUserPassword(userid, newpassword.Password.ToString()))
                        {
                            PasswordWarning.Visibility = Visibility.Visible;
                            PasswordWarning.Content = "Password Changed Successfully";
                            PasswordWarning.Foreground = Brushes.Green;
                            newpassword.Clear();
                            confirmednewpassword.Clear();
                        }
                        else
                        {
                            PasswordWarning.Visibility = Visibility.Visible;
                            PasswordWarning.Content = "Could Not Change Password";
                            PasswordWarning.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        PasswordWarning.Visibility = Visibility.Visible;
                        PasswordWarning.Content = "Password Must Be EIGHT Character";
                        PasswordWarning.Foreground = Brushes.Red;
                    }
                }
                else
                {
                    PasswordWarning.Visibility = Visibility.Visible;
                    PasswordWarning.Content = "Two Password Does Not Match";
                    PasswordWarning.Foreground = Brushes.Red;
                }
            }
            else
            {
                PasswordWarning.Visibility = Visibility.Visible;
                PasswordWarning.Content = "Enter Password First";
                PasswordWarning.Foreground = Brushes.Red;
            }
        }
    }
}
