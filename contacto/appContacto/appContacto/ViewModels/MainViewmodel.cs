

namespace appContacto.ViewModels
{
    using appContacto.Models;
    using System.Collections.Generic;
    public class MainViewmodel
    {
        #region Properties
        public List<Contact> ContactList { get; set; }

        #region ViewModel
        public ContactViewmodel contactViewmodel { get; set; }
        #endregion

        #region Constructor
        public MainViewmodel()
        {
            instance = this;
            this.contactViewmodel = new ContactViewmodel();
        } 
        #endregion

        #region singleton
        private static MainViewmodel instance;

        public static MainViewmodel GetInstance()
        {
            if(instance==null)
            {
                instance = new MainViewmodel();
            }
            return (instance);
        }
        #endregion
    }
    #endregion
}
