using System;
using System.Collections.Generic;


namespace BiografProjekt
{
    class MovieCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Movie> _movies;

        public Dictionary<int, Movie> Movies
        {
            get { return _movies; }
        }

        public void AddMovie(string title, TimeSpan length, int agelimit, string director, string mainActors)
        {
            CreateMovie(new Movie(title, length, agelimit, director, mainActors));
        }

        private void CreateMovie(Movie s)
        {
            s.Key = _keyCount++;
            _movies.Add(s.Key, s);
        }
        public void DeleteMovie(int key)
        {
            _movies.Remove(key);
        }
    }
}
