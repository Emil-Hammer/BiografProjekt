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
            CreateShow(new Show(_keyCount, movieKey, screenKey, dateTime, LengthOfMovie(movieKey), price));
            DomainModel.Instance.Shows.Shows[_keyCount].ScreenForShow.GetShowDateTimeList.Add(dateTime);
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
            if (datePicker.SelectedDate != null)
            {
                DateTime wantedShowTime = new DateTime(datePicker.SelectedDate.Value.Year,
                    datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day, hours, minutes, 0);
                TimeSpan wantedShowLength = new TimeSpan(0, length, 0);
                DateTime wantedShowEnd = wantedShowTime + wantedShowLength;
                foreach (var v in DomainModel.Instance.Screens.Screens)
                {
                    foreach (var b in v.Value.GetShowDateTimeList)
                    {
                        long start = b.Ticks;
                        long slut = b.Ticks + TimeSpan.FromMinutes(180).Ticks;
                        if (wantedShowTime.Ticks > slut || wantedShowEnd.Ticks < start)
                        {
                            return v.Value.ScreenKey;
                        }

                        return 100;
                    }
                }

                return 100;

                //List<int> listShow = new List<int>();
                //List<int> listShow2 = new List<int>();

                //    foreach (var show in Shows)
                //    {

                //        TimeSpan movieLength = new TimeSpan(0, show.Value.MovieForShow.Length, 0);

                //        if (!(movieDateTime.Ticks > show.Value.DateForShow.Ticks + movieLength.Ticks
                //            ||movieDateTime.Ticks + movieRequestLength.Ticks < show.Value.DateForShow.Ticks))
                //        {
                //            listShow.Add(show.Value.ScreenForShow.ScreenKey); // Shows in the datetime with screens
                //        }
                //        else
                //        {
                //            listShow2.Add(show.Value.ScreenForShow.ScreenKey); // Shows not in the datetime with screens
                //        }
                //    }

                //    foreach (var v in listShow)
                //        {
                //            if (listShow2.Contains(v))
                //            {
                //                listShow2.Remove(v);
                //            }

                //    if(listShow2.Count > 0)
                //    {
                //        return listShow2[0]; 
                //    }
                //    else
                //    {
                //        return 100; // 100 is hardcoded to be an error.
                //        }
                //    }
                //}
                //return 101; // 101 is hardcoded to be an error.
            }

            return 101;
        }
    }
}