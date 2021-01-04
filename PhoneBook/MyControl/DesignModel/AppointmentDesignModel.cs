using PhoneBook.ViewModel;

namespace PhoneBook.MyControl.DesignModel
{
    class AppointmentDesignModel : AppointmentViewModel
    {
        public static AppointmentDesignModel Instance => new AppointmentDesignModel();

        public AppointmentDesignModel()
        {
            AppointmentWith = "Zaman";
            Title = "This is just a test";
            DateTime = "12/20/2019 12:00:00";
        }
    }
}
