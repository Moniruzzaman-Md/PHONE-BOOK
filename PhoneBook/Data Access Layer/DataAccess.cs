using PhoneBook.DatabaseConnection;
using PhoneBook.ViewModel;
using System.Collections;
using System.Collections.Generic;


namespace PhoneBook.Data_Access_Layer
{
    class DataAccess
    {
        private DataBaseConnection ds = new DataBaseConnection();
        private static ArrayList al { set; get; }

        public bool IsConnected()
        {
            if (ds.connectionCheck()) return true;
            else return false;
        }

        public bool createNewUserAccount(string username, string password)
        {
            if (ds.ifUserExist(username))
            {
                return false;
            }
            else
            {
                ds.insertUserInfo(username, password);
                return true;
            }
        }
        public int validateUser(string username, string password)
        {
            return ds.isUserValid(username, password);
        }
        public bool saveContact(ContactViewModel cvm)
        {
            if (ds.saveContact(cvm)) return true;
            return false;
        }
        public bool hasContact(int userid)
        {
            al = ds.contactList(userid);
            if (al.Count == 0) return false;
            else return true;
        }
        public bool hasContact(int userid, string substring) 
        {
            al = ds.contactSearch(userid, substring);
            if (al.Count == 0) return false;
            else return true;
        }
        public bool hasAppiontment(int id)
        {
            al = ds.appoinmentList(id);
            if (al.Count == 0) return false;
            else return true;
        }
        public List<ContactViewModel> getContactList()
        {
            List<ContactViewModel> list = new List<ContactViewModel>();
            for (int i = 0; i < al.Count; i++)
            {
                list.Add((ContactViewModel)al[i]);
            }
            return list;
        }
        public ContactViewModel contactDetailsList(int id)
        {
           return ds.contactDetailsList(id);
        }
        public bool saveAppointment(AppointmentViewModel avm)
        {
            if (ds.saveAppointment(avm)) return true;
            else return false;
        }
        public List<AppointmentViewModel> getAppointmentList()
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();
            for (int i = 0; i < al.Count; i++)
            {
                list.Add((AppointmentViewModel)al[i]);
            }
            return list;
        }
        public AppointmentViewModel getAppointmentDetails(int id)
        {
            return ds.getAppointmentDetails(id);
        }
        public List<AppointmentViewModel> getAppointmentTimeList(int id)
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();
            ArrayList array = ds.getAppointmentTimeList(id);
            for (int i = 0; i < array.Count; i++)
            {
                list.Add((AppointmentViewModel)array[i]);
            }
            return list;
        }
        public bool isPasswordValid(int id, string password)
        {
            return ds.isPasswordValid(id, password);
        }
        public bool updateUserPassword(int id, string password)
        {
            return ds.updateUserPassword(id, password);
        }
        public bool deleteContact(int id)
        {
            return ds.deleteContact(id);
        }
    }
}
