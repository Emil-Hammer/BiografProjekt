using System;

namespace BiografProjekt
{
    public class Movie
    {
        #region Instance Field

        private int _key;
        private string _title;
        private TimeSpan _length;
        private int _agelimit;
        private string _director;
        private string _mainActors;
        #endregion
        #region Constructor
        public Movie (string title, TimeSpan length, int rating, string director, string mainActors)
        {
            _title = title;
            _length = length;
            _agelimit = rating;
            _director = director;
            _mainActors = mainActors;
        }
        #endregion
        #region Property

        public int Key
        {
            get { return _key;  }
            set { _key = value; }
        }
        public string Title
        {
            get { return _title; }
        }

        public TimeSpan Length
        {
            get { return _length; }
        }

        public int Rating
        {
            get { return _agelimit; }
        }

        public string Director
        {
            get { return _director; }
        }

        public string mainActors
        {
            get { return _mainActors; }
        }
        #endregion
    }
}
