namespace appContacto.Interfaces
{
    using ViewModels;
    public class InstanceLocator
    {
        #region Properties
        public MainViewmodel Main { get; set; }
        #endregion        
        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewmodel();
        }
#endregion
    }
}