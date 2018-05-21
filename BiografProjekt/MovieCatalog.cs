using System;
using System.Collections.Generic;


namespace BiografProjekt
{
    public class MovieCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Movie> _movies = new Dictionary<int, Movie>();

        

        public Dictionary<int, Movie> Movies
        {
            get { return _movies; }
        }

        public void AddMovie(string title, TimeSpan length, int agelimit, string director, string mainActors)
        {
            _keyCount++;
            CreateMovie(new Movie(title, length, agelimit, director, mainActors));
        }

        private void CreateMovie(Movie s)
        {
            _movies.Add(_keyCount, s);
        }
        public void DeleteMovie(int key)
        {
            _movies.Remove(key);
        }

        public Movie GetMovie(int key)
        {
            _movies.TryGetValue(key, out Movie movie);
            return movie;
        }

        public string GetAllMovie
        {
            get { return ListOfMovies(); }
        }

        public TimeSpan RunningTime(int key)
        {
            _movies.TryGetValue(key, out );
        }

        public string ListOfMovies()
        {
            List<string> nameList = new List<string>();
            foreach (var v in _movies)
            {
                nameList.Add(v.Value.Title);
            }

            string combinedString = string.Join(", ", nameList);
            combinedString = "Film: " + combinedString;
            return combinedString;
        }

    }
}
