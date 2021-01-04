using PhoneBook.ViewModel;
using PhoneBook.Data_Access_Layer;

namespace PhoneBook.MyControl.DesignModel
{
    class ContactListDesignModel : ContactListViewModel
    {
        public static ContactListDesignModel Obj { get { return new ContactListDesignModel(); } }

        #region Constructor is Written Here
        public ContactListDesignModel()
        {
            DataAccess da = new DataAccess();
            Item = da.getContactList();
        }
        #endregion
    }
}