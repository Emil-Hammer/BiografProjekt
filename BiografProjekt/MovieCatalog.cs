using System;
using System.Collections.Generic;
using System.Linq;


namespace BiografProjekt
{
    public class MovieCatalog
    {
        private static int _keyCount = 0;
        private Dictionary<int, Movie> _movies = new Dictionary<int, Movie>();

        

        public Dictionary<int, Movie> Movies
        {
            get { return _movies; }
        }

        public void AddMovie(string title, TimeSpan length, int agelimit, string director, string mainActors)
        {
            _keyCount++;
            int key = _keyCount;
            CreateMovie(new Movie(key, title, length, agelimit, director, mainActors));
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
            _movies.TryGetValue(key, out Movie movie);
            if (movie == null)
            {
                throw new NullReferenceException("The key didn't match a movie object.");
            }
            else
            {
                return movie.Length;
            }
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
