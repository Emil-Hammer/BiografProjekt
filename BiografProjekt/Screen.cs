namespace BiografProjekt
{
    public class Screen
    {
        #region Instance Fields

        #endregion

        #region Constructor

        public Screen(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        #endregion

        #region Properties

        public int ScreenKey { get; set; }

        public int Rows { get; }

        public int Columns { get; }

        #endregion
    }
}