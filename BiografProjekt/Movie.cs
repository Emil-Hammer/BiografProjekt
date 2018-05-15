using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiografProjekt
{
    public class Movie
    {
        #region Instance Field
        private string _title;
        private int _length;
        private string _rating;
        private string _director;
        private string _mainActors;
        private int _price;
        #endregion
        #region Constructor
        public Movie (string title, int length, string rating, string director, string mainActors, int price)
        {
            _title = title;
            _length = length;
            _rating = rating;
            _director = director;
            _mainActors = mainActors;
            _price = price;
        }
        #endregion
        #region Property
        public string Title
        {
            get { return _title; }
        }

        public int Length
        {
            get { return _length; }
        }

        public string Rating
        {
            get { return _rating; }
        }

        public string Director
        {
            get { return _director; }
        }

        public string mainActors
        {
            get { return _mainActors; }
        }

        public int Price
        {
            get { return _price; }
        }
        #endregion
    }
}
