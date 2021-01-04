using System.Windows;
using PhoneBook.Logic;

namespace PhoneBook
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
            //Calling the Logic.BusinessLogic
            businessLogic lg = new businessLogic();
            this.Close();
        }

    }
}
