using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiografProjekt
{
    public class Screen
    {
        #region Instance Fields
        private int _screenNumber;
        //private string _movie;
        private int _date;
        private int _time;
        #endregion

        #region Constructor
        public Screen(int screenNumber, int date, int time)
        {
        _screenNumber = screenNumber;
        _date = date;
        _time = time;
        }
        #endregion

        #region Properties
        public int ScreenNumber
    {
        get { return _screenNumber; }
    }

    public int Date
    {
        get { return _date; }
    }
    public int Time
    {
        get { return _time; }
    }
        #endregion
    }
}

