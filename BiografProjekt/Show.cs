using System;

namespace BiografProjekt
{
    public class Show
    {
        #region instance fields
        private int _keys;
        private Screen _screen;
        private Movie _movie;
        private DateTime _dateTime;
        #endregion

        #region Constructor
        public Show(int movieKey, int screenKey, DateTime dateTime)
        {
            _dateTime = dateTime;
            _movie = DomainModel.Instance.Movies.GetMovie(movieKey);
            _screen = DomainModel.Instance.Screens.GetScreen(screenKey);
        }
        #endregion

        #region Properties
        public int ShowKey
        {
            get => _keys;
            set => _keys = value;
        }

        public Screen getScreen => _screen;

        public Movie getMovie => _movie;

        public DateTime DateTime => _dateTime;

        #endregion
    }
}