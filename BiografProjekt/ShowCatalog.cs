using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace BiografProjekt
{
    public class ShowCatalog
    {
        private static int _keyCount = 0;

        public Dictionary<int, Show> Shows { get; } = new Dictionary<int, Show>();

        public void AddShow(int movieKey, int screenKey, DateTime dateTime, double price)
        {
            _keyCount++;
            CreateShow(new Show(_keyCount,movieKey,screenKey,dateTime, LengthOfMovie(movieKey), price));
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
        public int FindAvailableScreen(DatePicker datePicker, int hours, int minutes, int length)
        {
            TimeSpan movieTimeSpan = new TimeSpan(hours, minutes, 0);
            DateTime movieDateTime = new DateTime(datePicker.SelectedDate.Value.Year,
                datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day, hours, minutes, 0);
            TimeSpan movieRequestLength = new TimeSpan(0, length, 0);
            
            foreach (var show in Shows)
            {
                TimeSpan movieLength = new TimeSpan(0, show.Value.MovieForShow.Length, 0);
                if (movieDateTime.Ticks + movieTimeSpan.Ticks > show.Value.DateForShow.Ticks + movieLength.Ticks || movieDateTime.Ticks + movieTimeSpan.Ticks + movieRequestLength.Ticks < show.Value.DateForShow.Ticks)
                {
                    return 2;
                }
            }

            return 100;
        }
    }
}
