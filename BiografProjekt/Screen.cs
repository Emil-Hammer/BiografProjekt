namespace BiografProjekt
{
    public class Screen
    {
        #region Instance Fields

        private int _keys;
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

        public int ScreenKey
        {
            get => _keys;
            set => _keys = value;
        }

        public int Rows => _rows;

        public int Columns => _columns;

        #endregion
    }
}