using PhoneBook.Logic;
using System.Windows.Controls;
using PhoneBook.ViewModel;

namespace PhoneBook.MyControl
{
    public partial class contact : UserControl
    {
        public contact()
        {
            InitializeComponent();  
        }
        private void contactPreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var x = (ContactViewModel)this.DataContext;
            businessLogic.contactDetailsSetter(x.id);
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var x = (ContactViewModel)this.DataContext;
            if (businessLogic.deleteContact(x.id))
            {
                businessLogic.reloadMainPage();
            }
        }
    }
}
