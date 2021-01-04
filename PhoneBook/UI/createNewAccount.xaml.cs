using System.Windows;
using System.Windows.Input;
using PhoneBook.Logic;
using PhoneBook.Data_Access_Layer;

namespace PhoneBook.UI
{
    /// <summary>
    /// Interaction logic for createNewAccount.xaml
    /// </summary>
    public partial class createNewAccount : Window
    {
        private string username = "";
        private string password = "";
        private string confirmedPassword = "";
        public createNewAccount()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            if (!username.Equals("") && !password.Equals(""))
            {
                if (!password.Equals(confirmedPassword))
                {
                    confirmedPasswordDoesNotMatchLbl.Visibility = Visibility.Visible;

                }
                else
                {
                    usernameOrPasswordIsNotFilled.Visibility = Visibility.Hidden;
                    DataAccess da = new DataAccess();
                    if (!da.createNewUserAccount(username, password))
                        userNameAlreadyTakenLbl.Visibility = Visibility.Visible;
                    else
                    {
                        userNameAlreadyTakenLbl.Visibility = Visibility.Collapsed;
                        this.Close();
                    }
                }
            }
            else
            {
                usernameOrPasswordIsNotFilled.Visibility = Visibility.Visible;
            }
        }


        private void showPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            showPasswordText.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Hidden;
            showPasswordText.Text = passwordBox.Password.ToString();
        }

        private void showPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            showPasswordText.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Visible;
        }

        private void showConfirmPasssword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            showConfirmedPasswordText.Visibility = Visibility.Visible;
            confirmPasswordBox.Visibility = Visibility.Hidden;
            showConfirmedPasswordText.Text = confirmPasswordBox.Password.ToString();
        }

        private void showConfirmPasssword_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            showConfirmedPasswordText.Visibility = Visibility.Hidden;
            confirmPasswordBox.Visibility = Visibility.Visible;
        }

        private void passwordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!businessLogic.IsPasswordValid(passwordBox.Password.ToString()))
            {
                wrongPasswordLbl.Visibility = Visibility.Visible;
                password = "";
            }
            else
            {
                wrongPasswordLbl.Visibility = Visibility.Collapsed;
                password = passwordBox.Password.ToString();
                if (password.Equals(confirmedPassword))
                {
                    confirmedPasswordDoesNotMatchLbl.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void confirmPasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!businessLogic.IfPasswordMatched(passwordBox.Password.ToString(), confirmPasswordBox.Password.ToString()))
            {
                confirmedPasswordDoesNotMatchLbl.Visibility = Visibility.Visible;
                password = "";
                confirmedPassword = confirmPasswordBox.Password.ToString();
            }
            else
            {
                confirmedPasswordDoesNotMatchLbl.Visibility = Visibility.Collapsed;
                password = confirmPasswordBox.Password.ToString();
                confirmedPassword = confirmPasswordBox.Password.ToString();
            }
        }


        private void usernameText_KeyUp(object sender, KeyEventArgs e)
        {
            if (!usernameText.Text.Equals(""))
            {
                username = usernameText.Text;
            }
            else username = "";
        }
    }
}
