using System;

namespace BiografProjekt
{
    public class Movie
    {
        #region Instance Field

        #endregion
        #region Constructor
        public Movie (int key, string title, TimeSpan length, int rating, string director, string mainActors)
        {
            Key = key;
            Title = title;
            Length = length;
            Rating = rating;
            Director = director;
            this.MainActors = mainActors;
        }
        #endregion
        #region Property

        public int Key { get; set; }

        public string Title { get; }

        public TimeSpan Length { get; }

        public int Rating { get; }

        public string Director { get; }

        public string MainActors { get; }

        #endregion
    }
}
