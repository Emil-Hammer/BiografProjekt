using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class Movie
    {
        #region Constructor
        public Movie (int key, string title, int length, int rating, string director, string mainActors)
        {
            Key = key;
            Title = title;
            Length = length;
            Rating = rating;
            Director = director;
            MainActors = mainActors;
        }
        #endregion
        #region Property

        public int Key { get; set; }

        public string Title { get; }

        public int Length { get; }

        public int Rating { get; }

        public string Director { get; }

        public string MainActors { get; }

        //public string ShowsForMovie
        //{
        //    get { return ShowsForMovies(); }
        //}
        #endregion

        //public string ShowsForMovies()
        //{
        //    List<DateTime> showsIncludingMovie = new List<DateTime>();
        //    foreach (var obj in DomainModel.Instance.Shows.Shows)
        //    {
        //        int showMovieKey = obj.Key;
        //        if (Key == showMovieKey)
        //        {
        //            showsIncludingMovie.Add(obj.Value.DateForShow);
        //        }
        //    }

        //    return showsIncludingMovie.
        //}

        public override string ToString()
        {
            return Title;
        }
    }
}
