using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class ShowCatalog
    {
        private static int _keyCount = 1;

        public Dictionary<int, Show> Shows { get; } = new Dictionary<int, Show>();

        public void AddShow(int movieKey, int screenKey, DateTime dateTime)
        {
            CreateShow(new Show(movieKey, screenKey, dateTime));
        }

        private void CreateShow(Show s)
        {
            s.ShowKey = _keyCount++;
            Shows.Add(s.ShowKey, s);
        }
        public void DeleteShow(int key)
        {
            Shows.Remove(key);
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
                nameList.Add(v.Value.DateTime);
            }

            string combinedString = string.Join(", ", nameList);
            return combinedString;
        }
    }
}
