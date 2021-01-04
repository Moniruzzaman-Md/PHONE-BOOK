using PhoneBook.Logic;
using System.Windows.Controls;
using PhoneBook.ViewModel;

namespace PhoneBook.MyControl
{
    public partial class Appointment : UserControl
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void appointment_PreviwMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var x = (AppointmentViewModel)this.DataContext;
            businessLogic.AppointmentDetailsSetter(x.id);
        }
    }
}
