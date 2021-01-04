using PhoneBook.ViewModel;

namespace PhoneBook.MyControl.DesignModel
{
    class ContactDesignModel : ContactViewModel
    {
        public static ContactDesignModel Instance => new ContactDesignModel();

        #region Constructor
        public ContactDesignModel()
        {
            Initials = "DM";
            Name = "Zaman";
            Number = "01860-555763";

        }

    }
    #endregion
}

