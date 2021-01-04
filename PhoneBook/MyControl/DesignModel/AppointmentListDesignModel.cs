using PhoneBook.ViewModel;
using PhoneBook.Data_Access_Layer;

namespace PhoneBook.MyControl.DesignModel
{
    class AppointmentListDesignModel : AppointmentListViewModel
    {
        public static AppointmentListDesignModel Obj { get { return new AppointmentListDesignModel(); } }
        public AppointmentListDesignModel()
        {
            DataAccess da = new DataAccess();
            Item = da.getAppointmentList();
        }
    }
}
