namespace MindKeeper.ViewModel.Base
{
    public class GeneralVM : ViewModelBase
    {
        #region Singleton implementation
        private static GeneralVM instance;
        protected GeneralVM()
        { }

        public static GeneralVM Instance()
        {
            if(instance == null)
                instance = new GeneralVM();

            return instance;
        }
        #endregion
    }
}
