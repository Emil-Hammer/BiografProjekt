using System;

namespace BiografProjekt
{
    public class Show
    {
        #region instance fields

        private int _movieKey;
        private int _screenKey;
        private DateTime _showDate;
        private int _showTime;
        private int _showKey;
        #endregion

        #region Constructor
        public Show(int showKey, int movieKey, int screenKey, DateTime dateTime, int showTime)
        {
            _movieKey = movieKey;
            _screenKey = screenKey;
            _showDate = dateTime;
            _showTime = showTime;
            _showKey = showKey;
        }
        #endregion

        #region Properties
        public Movie MovieForShow
        {
            get { return DomainModel.Instance.Movies.GetMovie(_movieKey); }
        }

        public Screen ScreenForShow
        {
            get { return DomainModel.Instance.Screens.GetScreen(_screenKey); }
        }

        public DateTime DateForShow
        {
            get { return _showDate; }
            set { _showDate = value; }
        }

        public int TimeForShow
        {
            get { return _showTime; }
            set { _showTime = value; }
        }

        public int MovieKey
        {
            get { return _movieKey; }
            set { _movieKey = value; }
        }

        public int ScreenKey
        {
            get { return _screenKey; }
            set { _screenKey = value; }
        }

        public int ShowKey
        {
            get { return _showKey; }
            set { _showKey = value; }
        }
        #endregion

    }
}