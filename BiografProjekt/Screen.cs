namespace BiografProjekt
{
    public class Screen
    {
        #region Instance Fields

        private int _rows;
        private int _columns;

        #endregion

        #region Constructor
        public Screen()
        {
        }

        #endregion

        #region Properties

        public int ScreenKey { get; set; }

        public int Rows { get; }

        public int Columns { get; }

        #endregion
    }
}