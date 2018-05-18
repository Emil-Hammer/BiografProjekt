using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class ShowCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Show> _shows = new Dictionary<int, Show>();

        public Dictionary<int, Show> Shows
        {
            get { return _shows; }
        }

        public void AddShow(int movieKey, int screenKey, DateTime dateTime)
        {
            CreateShow(new Show(movieKey, screenKey, dateTime));
        }

        private void CreateShow(Show s)
        {
            s.ShowKey = _keyCount++;
            _shows.Add(s.ShowKey, s);
        }
        public void DeleteShow(int key)
        {
            _shows.Remove(key);
        }

        public Show GetShows(int key)
        {
            _shows.TryGetValue(key, out Show show);
            return show;
        }
        public string GetAllShows
        {
            get { return ListOfShows(); }
        }

        public string ListOfShows()
        {
            List<DateTime> nameList = new List<DateTime>();
            foreach (var v in _shows)
            {
                nameList.Add(v.Value.DateTime);
            }

            string combinedString = string.Join(", ", nameList);
            combinedString = "Tidspunkt for shows: " + combinedString;
            return combinedString;
        }
    }
}
