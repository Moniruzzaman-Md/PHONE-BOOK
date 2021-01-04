using System.Windows.Controls;
using PhoneBook.MyControl.DesignModel;

namespace PhoneBook.MyControl
{
    public partial class contactListControl : UserControl
    {
        public contactListControl()
        {
            InitializeComponent();
            listcontrol.ItemsSource = ContactListDesignModel.Obj.Item;
        }
    }
}
