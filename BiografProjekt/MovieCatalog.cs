using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class MovieCatalog
    {
        private static int _keyCount;

        public Dictionary<int, Movie> Movies { get; } = new Dictionary<int, Movie>();

        public void AddMovie(string title, TimeSpan length, int agelimit, string director, string mainActors)
        {
            _keyCount++;
            int key = _keyCount;
            CreateMovie(new Movie(key, title, length, agelimit, director, mainActors));
        }

        private void CreateMovie(Movie s)
        {
            Movies.Add(_keyCount, s);
        }

        public void DeleteMovie(int key)
        {
            Movies.Remove(key);
        }

        public Movie GetMovie(int key)
        {
            Movies.TryGetValue(key, out Movie movie);
            return movie;
        }

        public string GetAllMovie => ListOfMovies();

        public int GetRating(int key)
        {
            Movies.TryGetValue(key, out Movie movie);
            if (movie == null)
            {
                throw new NullReferenceException("The key didn't match a movie object.");
            }
            else
            {
                return movie.Rating;
            }
        }

        public List<string> GetAllTitle
        {
            get { return ListOfTitles(); }
        }

        public TimeSpan RunningTime(int key)
        {
            Movies.TryGetValue(key, out Movie movie);
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
            foreach (var v in Movies)
            {
                nameList.Add(v.Value.Title);
            }

            string combinedString = string.Join(", ", nameList);
            return combinedString;
        }

        public List<string> ListOfTitles()
        {
            List<string> nameList = new List<string>();
            foreach (var v in Movies)
            {
                nameList.Add(v.Value.Title);
            }

            return nameList;
        }
    }
}