using System;
using System.Collections.Generic;

namespace BiografProjekt
{
    public class Screen
    {
        #region Instance Fields

        private List<DateTime> _shows;

        #endregion
        #region Constructor
        public Screen()
        {
            _shows = new List<DateTime>();
        }

        #endregion

        #region Properties

        public int ScreenKey { get; set; }

        public List<DateTime> GetShowDateTimeList
        {
            get { return _shows; }
            set { _shows = value; }
        }

        #endregion
    }
}