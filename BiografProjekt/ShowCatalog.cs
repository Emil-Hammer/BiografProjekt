using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class ShowCatalog
    {
        private static int _keyCount = 0;

        public Dictionary<int, Show> Shows { get; } = new Dictionary<int, Show>();

        public void AddShow(int movieKey, int screenKey, DateTime dateTime)
        {
            _keyCount++;
            CreateShow(new Show(_keyCount,movieKey,screenKey,dateTime, LengthOfMovie(movieKey)));
        }

        private void CreateShow(Show s)
        {
            Shows.Add(_keyCount, s);
        }
        public void DeleteShow(int key)
        {
            Shows.Remove(key);
        }

        public int LengthOfMovie(int movieKey)
        {
            return DomainModel.Instance.Movies.RunningTime(movieKey);
        }

        public Show GetShows(int key)
        {
            Shows.TryGetValue(key, out Show show);
            return show;
        }
        public string GetAllShows
        {
            get { return ListOfShows(); }
        }

        public string ListOfShows()
        {
            List<DateTime> nameList = new List<DateTime>();
            foreach (var v in Shows)
            {
                nameList.Add(v.Value.DateForShow);
            }

            string combinedString = string.Join(", ", nameList);
            return combinedString;
        }
    }
}
