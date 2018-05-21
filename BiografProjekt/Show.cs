using System;

namespace BiografProjekt
{
    public class Show
    {
        #region instance fields

        #endregion

        #region Constructor
        public Show(int movieKey, int screenKey, DateTime dateTime)
        {
            DateTime = dateTime;
            getMovie = DomainModel.Instance.Movies.GetMovie(movieKey);
            getScreen = DomainModel.Instance.Screens.GetScreen(screenKey);
        }
        #endregion

        #region Properties
        public int ShowKey { get; set; }

        public Screen getScreen { get; }

        public Movie getMovie { get; }

        public DateTime DateTime { get; }

        #endregion
    }
}