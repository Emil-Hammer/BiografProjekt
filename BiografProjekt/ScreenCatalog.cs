using System.Collections.Generic;

namespace BiografProjekt
{
    public class ScreenCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Screen> _screens = new Dictionary<int, Screen>();

        public Dictionary<int, Screen> Screens
        {
            get { return _screens; }
        }

        public void AddScreen(int rows, int columns)
        {
            CreateScreen(new Screen(rows, columns));
        }

        private void CreateScreen(Screen s)
        {
            s.ScreenKey = _keyCount++;
            _screens.Add(s.ScreenKey, s);
        }
        public void DeleteMovie(int key)
        {
            _screens.Remove(key);
        }

        public Screen GetScreen(int key)
        {
            _screens.TryGetValue(key, out Screen screen);
            return screen;
        }

        public string GetAllScreens
        {
            get { return ListOfScreens(); }
        }

        public string ListOfScreens()
        {
            List<int> nameList = new List<int>();
            foreach (var v in _screens)
            {
                nameList.Add(v.Value.Columns);
            }

            string combinedString = string.Join(", ", nameList);
            combinedString = "Columns: " + combinedString;
            return combinedString;
        }
    }
}
