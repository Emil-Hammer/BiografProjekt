namespace BiografProjekt
{
    public class DomainModel
    {
        private static DomainModel _instance;

        public static DomainModel Instance
        {
            get
            {
                _instance = _instance ?? (_instance = new DomainModel());
                return _instance;
            }
        }

        private DomainModel()
        {
            Movies = new MovieCatalog();
            Screens = new ScreenCatalog();
            Shows = new ShowCatalog();
        }

        #region Properties
        public MovieCatalog Movies { get; }
        public ScreenCatalog Screens { get; }
        public ShowCatalog Shows { get; }

        #endregion
    }
}