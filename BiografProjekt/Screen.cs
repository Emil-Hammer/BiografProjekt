using System.Collections.Generic;

namespace BiografProjekt
{
    public class Screen
    {
        #region Instance Fields

        private int _rows;
        private int _columns;
        #endregion

        #region Constructor

        public Screen(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        #endregion

        #region Properties

        public int ScreenKey { get; set; }

        public int Rows { get; }

        public int Columns { get; }

        #endregion
    }
}