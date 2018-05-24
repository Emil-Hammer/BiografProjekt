using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BiografProjekt
{
    public class Seat
    {
        #region Instance Fields

        private int _rows;
        private int _columns;
        private int _seatKey;

        #endregion

        public Seat(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public int SeatKey
        {
            get { return _seatKey; }
            set { _seatKey = value; }
        }
    }
}