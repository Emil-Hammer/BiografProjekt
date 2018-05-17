namespace BiografProjekt
{
    public class DomainModel
    {
        private MovieCatalog _movieCatalog;
        private ScreenCatalog _screenCatalog;
        private ShowCatalog _showCatalog;
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
            _movieCatalog = new MovieCatalog();
            _screenCatalog = new ScreenCatalog();
            _showCatalog = new ShowCatalog();
        }

        #region Properties
        public MovieCatalog Movies { get { return _movieCatalog; } }
        public ScreenCatalog Screens { get { return _screenCatalog; } }
        public ShowCatalog Shows { get { return _showCatalog; } }
        #endregion
    }
}