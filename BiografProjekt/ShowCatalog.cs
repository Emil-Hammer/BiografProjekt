using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class ShowCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Show> _shows;

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
    }
}
