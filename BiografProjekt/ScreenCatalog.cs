using System;
using System.Collections.Generic;


namespace BiografProjekt
{
    class ScreenCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Screen> _screens;

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
    }
}
