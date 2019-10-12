

namespace appContacto.ViewModels
{
    using appContacto.Models;
    using System.Collections.Generic;
    public class MainViewmodel
    {
        #region Properties
        public List<Contact> ContactList { get; set; }

        #region ViewModel
        public ContactViewmodel ContactViewModel { get; set; }
        #endregion

        #region Constructor
        public MainViewmodel()
        {
            instance = this;
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

}
