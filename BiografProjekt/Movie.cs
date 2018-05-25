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
        #endregion

        public override string ToString()
        {
            return Title;
        }
    }
}
