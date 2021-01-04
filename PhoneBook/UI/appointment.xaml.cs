using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using PhoneBook.ViewModel;
using PhoneBook.Data_Access_Layer;
using PhoneBook.Logic;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using System;
using ToastNotifications.Messages;

namespace PhoneBook.UI
{
    public partial class appointment : Window
    {
        private int userid;
        public appointment(int id)
        {
            DataAccess da = new DataAccess();
            da.hasAppiontment(id);
            userid = id;
            InitializeComponent();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            if (!appointmentwith.Text.Equals("") && !titletxt.Text.Equals("") && !datePicker.Value.ToString().Equals(""))
            {
                AppointmentViewModel avm = new AppointmentViewModel();
                avm.AppointmentWith = appointmentwith.Text;
                avm.Title = titletxt.Text;
                avm.DateTime = datePicker.Value.ToString();
                avm.id = userid;

                TextRange tr = new TextRange(detailstxt.Document.ContentStart, detailstxt.Document.ContentEnd);
                avm.Details = tr.Text;

                DataAccess da = new DataAccess();
                da.saveAppointment(avm);
                appointmentwith.Text = null;
                titletxt.Text = null;
                datePicker.Text = null;
                detailstxt.Document.Blocks.Clear();
                //Warning.Visibility = Visibility.Collapsed;
                notifier.ShowSuccess("Appointment Saved Successfully");
                //Warning.Visibility = Visibility.Visible;
            }

            else
            {
                notifier.ShowError("Saving Failed. Fill up required Fields.");
                //Warning.Visibility = Visibility.Visible;
            }

        }

        private void btnsave_MouseEnter(object sender, MouseEventArgs e)
        {
            btnsave.Foreground = Brushes.Black;
        }

        private void btnsave_MouseLeave(object sender, MouseEventArgs e)
        {
            btnsave.Foreground = Brushes.White;
        }

        private void btncancel_MouseEnter(object sender, MouseEventArgs e)
        {
            btncancel.Foreground = Brushes.Black;
        }

        private void btncancel_MouseLeave(object sender, MouseEventArgs e)
        {
            btncancel.Foreground = Brushes.White;
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
           // newAppointment.Visibility = Visibility.Hidden;
           // appoinmentList.Visibility = Visibility.Visible;
            businessLogic.appointmentPageViewer(userid);
            this.Close();
        }

        private void btnNewAppointment_MouseEnter(object sender, MouseEventArgs e)
        {
            btnNewAppointment.Foreground = Brushes.Black;
        }

        private void btnNewAppointment_MouseLeave(object sender, MouseEventArgs e)
        {
            btnNewAppointment.Foreground = Brushes.White;
        }

        private void btnNewAppointment_Click(object sender, RoutedEventArgs e)
        {
            newAppointment.Visibility = Visibility.Visible;
            appoinmentList.Visibility = Visibility.Hidden;
        }
        public void AppointmentDetailsSetter(int id)
        {
            AppointmentDetails.Visibility = Visibility.Visible;
            DataAccess da = new DataAccess();
            AppointmentViewModel avm = da.getAppointmentDetails(id);
            appointmentTitle.Content = avm.Title;
            appointmentWith.Text = avm.AppointmentWith;
            time.Text = avm.DateTime;

            details.Document.Blocks.Clear();
            details.Document.Blocks.Add(new Paragraph(new Run(avm.Details)));
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainPage.isAppointmentOpen = false;
        }
        private Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 20);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(30),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
    }

}
