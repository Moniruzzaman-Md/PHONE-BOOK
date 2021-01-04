using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhoneBook.ViewModel;
using PhoneBook.Logic;
using PhoneBook.Data_Access_Layer;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Collections.Generic;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Net.Mail;
using System.Net;

namespace PhoneBook.UI
{

    public partial class MainPage : Window
    {
        private string filepath = "";
        private System.Int32 maxNumOfNewNumber = 5;
        private System.Int32 newNumAdded = 0;
        private int userid;
        private string username;
        private DataAccess da = new DataAccess();
        public static bool isAppointmentOpen = false;
        public MainPage(int x, int indicator, string username)
        {
            if (indicator == 0)
                da.hasContact(x);
            userid = x;
            this.username = username;
            InitializeComponent();
            userlabel.Content = "Hi " + username;
            if (indicator == 0)
            {
                crossButton.IsEnabled = false;
            }
            else
                crossButton.IsEnabled = true;

            DispatcherTimer clock = new DispatcherTimer();
            clock.Interval = new TimeSpan(0, 0, 1);
            clock.Tick += clock_Tick;
            clock.Start();
        }
        private void clock_Tick(object sender, EventArgs e)
        {
            List<AppointmentViewModel> list = da.getAppointmentTimeList(userid);
            foreach (AppointmentViewModel model in list)
            {
                if (model.DateTime.Equals(DateTime.Now.ToString()))
                {
                    notifier.ShowInformation("Appointment at " + model.DateTime + " With " + model.AppointmentWith);
                    for (int i = 1; i < 15; i++)
                        Console.Beep(1000, 500);
                }
            }
        }
        private void newContact_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            newContactButton.Foreground = Brushes.Black;
        }

        private void newContact_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            newContactButton.Foreground = Brushes.White;
        }

        private void group_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            groupButton.Foreground = Brushes.Black;
        }

        private void group_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            groupButton.Foreground = Brushes.White;
        }

        private void appointment_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            appointmentsButton.Foreground = Brushes.Black;
        }

        private void appointment_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            appointmentsButton.Foreground = Brushes.White;
        }

        private void aboutUs_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            aboutUsButton.Foreground = Brushes.Black;
        }

        private void aboutUs_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            aboutUsButton.Foreground = Brushes.White;
        }

        private void addPhoto_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            addPhoto.Foreground = Brushes.Black;
        }

        private void addPhoto_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            addPhoto.Foreground = Brushes.White;
        }

        private void addNumberButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            addNumberButton.Foreground = Brushes.Black;
        }

        private void addNumberButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            addNumberButton.Foreground = Brushes.White;
        }

        private void addNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (newNumAdded < maxNumOfNewNumber)
            {
                if (newNumAdded == 0)
                    newNumber2.Visibility = Visibility.Visible;
                else if (newNumAdded == 1)
                    newNumber3.Visibility = Visibility.Visible;
                else if (newNumAdded == 2)
                    newNumber4.Visibility = Visibility.Visible;
                else if (newNumAdded == 3)
                    newNumber5.Visibility = Visibility.Visible;
                else if (newNumAdded == 4)
                    newNumber6.Visibility = Visibility.Visible;
                newNumAdded++;
            }
            else newNumLimitText.Visibility = Visibility.Visible;
        }

        private void street_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtStreet.Text.ToString()).Equals("Street"))
            {
                txtStreet.Text = "";
                txtStreet.Foreground = Brushes.White;
            }
        }

        private void street_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtStreet.Text.ToString()).Equals(""))
            {
                txtStreet.Text = "Street";
                txtStreet.Foreground = Brushes.Gray;
            }
        }

        private void city_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtCity.Text.ToString()).Equals("City"))
            {
                txtCity.Text = "";
                txtCity.Foreground = Brushes.White;
            }
        }

        private void city_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtCity.Text.ToString()).Equals(""))
            {
                txtCity.Text = "City";
                txtCity.Foreground = Brushes.Gray;
            }
        }

        private void state_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtState.Text.ToString()).Equals("State/Province"))
            {
                txtState.Text = "";
                txtState.Foreground = Brushes.White;
            }
        }

        private void state_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtState.Text.ToString()).Equals(""))
            {
                txtState.Text = "State/Province";
                txtState.Foreground = Brushes.Gray;
            }
        }

        private void zipCode_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtZipCode.Text.ToString()).Equals("Zip/Postal Ciode"))
            {
                txtZipCode.Text = "";
                txtZipCode.Foreground = Brushes.White;
            }
        }

        private void zipCode_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtZipCode.Text.ToString()).Equals(""))
            {
                txtZipCode.Text = "Zip/Postal Ciode";
                txtZipCode.Foreground = Brushes.Gray;
            }
        }

        private void country_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtCountry.Text.ToString()).Equals("Country/Region"))
            {
                txtCountry.Text = "";
                txtCountry.Foreground = Brushes.White;
            }
        }

        private void country_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((txtCountry.Text.ToString()).Equals(""))
            {
                txtCountry.Text = "Country/Region";
                txtCountry.Foreground = Brushes.Gray;

            }
        }

        private void newContactButton_Click(object sender, RoutedEventArgs e)
        {
            newContact.Visibility = Visibility.Visible;
            contactDetails.Visibility = Visibility.Hidden;
        }

        private void btnSave_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnSave.Foreground = Brushes.Black;
        }

        private void btnSave_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnSave.Foreground = Brushes.White;
        }

        private void btnCancel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCancel.Foreground = Brushes.Black;
        }

        private void btnCancel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCancel.Foreground = Brushes.White;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ContactViewModel cvm = new ContactViewModel();

            cvm.name = newContactNmae.Text;
            cvm.uid = userid;
            cvm.num1 = newNumber1.Text;
            cvm.num2 = newNumber2.Text;
            cvm.num3 = newNumber3.Text;
            cvm.num4 = newNumber4.Text;
            cvm.num5 = newNumber5.Text;
            cvm.num6 = newNumber6.Text;

            cvm.email = txtNewContactEmail.Text;
            cvm.street = txtStreet.Text;
            cvm.city = txtCity.Text;
            cvm.state = txtState.Text;
            cvm.zip = txtZipCode.Text;
            cvm.country = txtCountry.Text;
            if (IsRichTextBoxEmpty(txtAbout))
            {
                cvm.about = "null";
            }
            else
            {
                TextRange text = new TextRange(txtAbout.Document.ContentStart, txtAbout.Document.ContentEnd);
                cvm.about = text.Text;
            }
            cvm.group = _group.Text;

            try
            {
                if (!filepath.Equals(""))
                {
                    filepath = filepath.Replace("\\", "\\\\\\\\");
                    cvm.image = filepath;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            if (businessLogic.isContactValid(cvm))
            {
                ifsaved.Content = "Contact Saved";
                ifsaved.Foreground = Brushes.Green;
                businessLogic.mainPageViewer(userid, 0, username);
                this.Close();
            }
            else
            {
                ifsaved.Content = "Saving Failed";
                ifsaved.Foreground = Brushes.Red;
            }
        }

        private void addPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                        "Portable Network Graphic (*.png)|*.png";


                if (openFileDialog.ShowDialog() == true)
                {
                    //Get the path of specified file
                    filepath = openFileDialog.FileName;


                    //Read the contents of the file into a stream
                    //System.Drawing.Bitmap image = new System.Drawing.Bitmap(filePath);

                    ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(@filepath, UriKind.Absolute)));
                    imgUserImage.Background = brush;
                    addPhoto.Visibility = Visibility.Hidden;
                    imgUserImage.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void appointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            if (isAppointmentOpen == false)
            {
                businessLogic.appointmentPageViewer(userid);
            }
        }
        public void contactDetailsSetter(int id)
        {
            contactDetails.Visibility = Visibility.Visible;
            newContact.Visibility = Visibility.Hidden;
            DataAccess da = new DataAccess();
            ContactViewModel cvm = da.contactDetailsList(id);
            if (!cvm.image.Equals(""))
            {
                try
                {
                    ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(cvm.image, UriKind.Absolute)));
                    image.Background = brush;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                ImageBrush brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/PhoneBook;component/Image/Icon/uid.jpg", UriKind.Absolute)));
                image.Background = brush;
            }
            lblContactName.Content = cvm.name;
            Number1.Text = cvm.num1;
            if (cvm.num2.Equals(""))
            {
                Number2.Visibility = Visibility.Collapsed;
            }
            else
            {
                Number2.Text = cvm.num2;
                Number2.Visibility = Visibility.Visible;

            }
            if (cvm.num3.Equals(""))
            {
                Number3.Visibility = Visibility.Collapsed;
            }
            else
            {
                Number3.Text = cvm.num3;
                Number3.Visibility = Visibility.Visible;
            }
            if (cvm.num4.Equals(""))
            {
                Number4.Visibility = Visibility.Collapsed;
            }
            else
            {
                Number4.Text = cvm.num4;
                Number4.Visibility = Visibility.Visible;
            }
            if (cvm.num5.Equals(""))
            {
                Number5.Visibility = Visibility.Collapsed;
            }
            else
            {
                Number5.Text = cvm.num5;
                Number5.Visibility = Visibility.Visible;
            }
            if (cvm.num6.Equals(""))
            {
                Number6.Visibility = Visibility.Collapsed;
            }
            else
            {
                Number6.Text = cvm.num6;
                Number6.Visibility = Visibility.Visible;
            }
            if (cvm.email.Equals(""))
            {
                email.Visibility = Visibility.Collapsed;
                lblemail.Visibility = Visibility.Collapsed;
            }
            else
            {
                email.Text = cvm.email;
                email.Visibility = Visibility.Visible;
                lblemail.Visibility = Visibility.Visible;
            }
            if (cvm.street.Equals(""))
            {
                street.Visibility = Visibility.Collapsed;
                lblstreet.Visibility = Visibility.Collapsed;
            }
            else
            {
                street.Text = cvm.street;
                street.Visibility = Visibility.Visible;
                lblstreet.Visibility = Visibility.Visible;
            }
            if (cvm.city.Equals(""))
            {
                city.Visibility = Visibility.Collapsed;
                lblcity.Visibility = Visibility.Collapsed;
            }
            else
            {
                city.Text = cvm.city;
                city.Visibility = Visibility.Visible;
                lblcity.Visibility = Visibility.Visible;
            }
            if (cvm.zip.Equals(""))
            {
                zip.Visibility = Visibility.Collapsed;
                lblzip.Visibility = Visibility.Collapsed;
            }
            else
            {
                zip.Text = cvm.zip;
                zip.Visibility = Visibility.Visible;
                lblzip.Visibility = Visibility.Visible;
            }
            if (cvm.state.Equals(""))
            {
                state.Visibility = Visibility.Collapsed;
                lblstate.Visibility = Visibility.Collapsed;
            }
            else
            {
                state.Text = cvm.state;
                state.Visibility = Visibility.Visible;
                lblstate.Visibility = Visibility.Visible;
            }
            if (cvm.country.Equals(""))
            {
                country.Visibility = Visibility.Collapsed;
                lblcountry.Visibility = Visibility.Collapsed;
            }
            else
            {
                country.Text = cvm.country;
                country.Visibility = Visibility.Visible;
                lblcountry.Visibility = Visibility.Visible;
            }
            if (cvm.group.Equals(""))
            {
                group.Visibility = Visibility.Collapsed;
                lblgroup.Visibility = Visibility.Collapsed;
            }
            else
            {
                group.Text = cvm.group;
                group.Visibility = Visibility.Visible;
                lblgroup.Visibility = Visibility.Visible;
            }
            if (cvm.about.Equals("null"))
            {
                about.Visibility = Visibility.Collapsed;
                lblabout.Visibility = Visibility.Collapsed;
            }
            else
            {
                about.Document.Blocks.Clear();
                about.Document.Blocks.Add(new Paragraph(new Run(cvm.about)));
                about.Visibility = Visibility.Visible;
                lblabout.Visibility = Visibility.Visible;
            }

        }
        public bool IsRichTextBoxEmpty(RichTextBox rtb)
        {
            var start = rtb.Document.ContentStart;
            var end = rtb.Document.ContentEnd;
            int difference = start.GetOffsetToPosition(end);
            if (difference == 2)
                return true;
            else return false;
        }

        private void imgUserImage_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                        "Portable Network Graphic (*.png)|*.png";


                if (openFileDialog.ShowDialog() == true)
                {
                    //Get the path of specified file
                    filepath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //System.Drawing.Bitmap image = new System.Drawing.Bitmap(filePath);

                    ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(@filepath, UriKind.Absolute)));
                    imgUserImage.Background = brush;
                    addPhoto.Visibility = Visibility.Hidden;
                    imgUserImage.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            newContactNmae.Text = null;
            newNumber1.Text = null;
            newNumber2.Text = null;
            newNumber3.Text = null;
            newNumber4.Text = null;
            newNumber5.Text = null;
            newNumber6.Text = null;
            txtNewContactEmail.Text = null;
            txtStreet.Text = null;
            txtCity.Text = null;
            txtState.Text = null;
            txtZipCode.Text = null;
            txtCountry.Text = null;
            _group.Text = null;
            txtAbout.Document.Blocks.Clear();
            addPhoto.Visibility = Visibility.Visible;
            imgUserImage.Visibility = Visibility.Hidden;
            newContact.Visibility = Visibility.Hidden;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!searchBox.Text.Equals("") && !searchBox.Text.Equals("Search a Name or Number"))
            {
                da.hasContact(userid, searchBox.Text);
                businessLogic.mainPageViewer(userid, 1, username);
                this.Close();
            }
        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((searchBox.Text.ToString()).Equals("Search a Name or Number"))
            {
                searchBox.Text = "";
            }
        }

        private void searchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((searchBox.Text.ToString()).Equals(""))
            {
                searchBox.Text = "Search a Name or Number";
                searchButton.Visibility = Visibility.Visible;
                crossButton.Visibility = Visibility.Hidden;
            }
            else
            {
                searchButton.Visibility = Visibility.Visible;
                crossButton.Visibility = Visibility.Hidden;
            }
        }
        private void crossButton_Click(object sender, RoutedEventArgs e)
        {
            businessLogic.mainPageViewer(userid, 0, username);
            this.Close();
        }
        private Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 20);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(15),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        private void edit_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            edit.Foreground = Brushes.Black;
        }

        private void edit_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            edit.Foreground = Brushes.White;
        }

        private void logout_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            logout.Foreground = Brushes.Black;
        }

        private void logout_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            logout.Foreground = Brushes.White;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            businessLogic.loginPageViewer();
            this.Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditProfile ep = new EditProfile(userid, username);
            ep.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ep.ShowDialog();
        }
        public void Reload()
        {
            businessLogic.mainPageViewer(userid, 0, username);
            this.Close();
        }
    }

}

