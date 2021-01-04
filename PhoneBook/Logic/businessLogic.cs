using PhoneBook.UI;
using PhoneBook.Data_Access_Layer;
using PhoneBook.DatabaseConnection;
using System.IO;
using System;
using PhoneBook.ViewModel;

namespace PhoneBook.Logic
{
    class businessLogic
    {
        private static Login lg;
        private static MainPage mp;
        private static appointment app;
        public businessLogic()
        {
            loginPageViewer();
            DataAccess dal = new DataAccess();
           
            if (!dal.IsConnected())
            {
                lg.setConnectionStatus(false);
            }
            else
            {
                string script = File.ReadAllText(@"..\..\DBSchema\DBSchema_1.0.txt");
                Console.WriteLine(script);
                DataBaseConnection db = new DataBaseConnection();
                db.createTable(script);
            }
        }
        public static void loginPageViewer()
        {
            lg = new Login();
            lg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lg.Show();
        }
        public static bool IsPasswordValid(string password)
        {
            if (password.Length < 8) return false;

            else return true;
        }

        public static bool IfPasswordMatched(string password, string confirmedPassword)
        {
            if (password.Equals(confirmedPassword)) return true;

            else return false;
        }
        public static int isUserValid(string username, string password)
        {
            DataAccess da = new DataAccess();
            int x = da.validateUser(username, password);
            if (x != 0)
            {
                return x;
            }
            else return 0;
        }
        public static void mainPageViewer(int x,int indicator,string username)
        {
            mp = new MainPage(x,indicator,username);
            mp.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mp.Show();
        }

        public static bool isContactValid(ContactViewModel cvm)
        {
            if (cvm.name.Equals(""))
            {
                return false;
            }
            if (cvm.num1.Equals(""))
            {
                return false;
            }
            if (cvm.street.Equals("Street"))
            {
                cvm.street = "";
            }
            if (cvm.city.Equals("City"))
            {
                cvm.city = "";
            }
            if (cvm.state.Equals("State/Province"))
            {
                cvm.state = "";
            }
            if (cvm.zip.Equals("Zip/Postal Ciode"))
            {
                cvm.zip = "";
            }
            if (cvm.country.Equals("Country/Region"))
            {
                cvm.country = "";
            }
            DataBaseConnection db = new DataBaseConnection();
            if (db.saveContact(cvm))
            {
                return true;
            }
            return false;
        }
        public static void contactDetailsSetter(int id)
        {
            mp.contactDetailsSetter(id);
        }
        public static void AppointmentDetailsSetter(int id)
        {
            app.AppointmentDetailsSetter(id);
        }
        public static void appointmentPageViewer(int x)
        {
            app = new appointment(x);
            app.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            app.Show();
            MainPage.isAppointmentOpen = true;
        }
        public static bool isPasswordValid(int id, string password)
        {
            DataAccess da = new DataAccess();
            return da.isPasswordValid(id, password);
        }
        public static bool updateUserPassword(int id, string password)
        {
            DataAccess da = new DataAccess();
            return da.updateUserPassword(id, password);
        }
        public static bool deleteContact(int id)
        {
            DataAccess da = new DataAccess();
            return (da.deleteContact(id)) ;
        }
        public static void reloadMainPage()
        {
            mp.Reload();
        }
    }
}
