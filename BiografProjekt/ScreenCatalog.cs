using System.Collections.Generic;
using System.Windows.Controls;

namespace BiografProjekt
{
    public class ScreenCatalog
    {
        private static int _keyCount = 1;

        public Dictionary<int, Screen> Screens { get; } = new Dictionary<int, Screen>();

        public void AddScreen()
        {
            CreateScreen(new Screen());
        }

        private void CreateScreen(Screen s)
        {
            s.ScreenKey = _keyCount++;
            Screens.Add(s.ScreenKey, s);
        }
        public void DeleteMovie(int key)
        {
            Screens.Remove(key);
        }

        public Screen GetScreen(int key)
        {
            Screens.TryGetValue(key, out Screen screen);
            return screen;
        }

        public string GetAllScreens
        {
            get { return ListOfScreens(); }
        }

        public string ListOfScreens()
        {
            List<int> nameList = new List<int>();
            foreach (var v in Screens)
            {
                nameList.Add(v.Value.Columns);
            }

            string combinedString = string.Join(", ", nameList);
            return combinedString;
        }
        
    }
}
