using System.Windows.Controls;
using PhoneBook.MyControl.DesignModel;

namespace PhoneBook.MyControl
{
    public partial class AppointmentListControl : UserControl
    {
        public AppointmentListControl()
        {
            InitializeComponent();
            Appointmentlistcontrol.ItemsSource = AppointmentListDesignModel.Obj.Item;
        }
    }
}
