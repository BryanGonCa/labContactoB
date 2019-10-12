using System;
using System.Collections.Generic;
using System.Text;

namespace appContacto.ViewModels
{
    public class MainViewmodel
    {
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
