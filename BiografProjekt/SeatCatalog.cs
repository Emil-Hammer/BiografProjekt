using System.Collections.Generic;

namespace BiografProjekt
{
    public class SeatCatalog
    {
        private static int _keyCount = 1;

        public Dictionary<int, Seat> Seats { get; } = new Dictionary<int, Seat>();

        public void Seat(int rows, int columns)
        {
            CreateSeat(new Seat(rows, columns));
        }

        private void CreateSeat(Seat s)
        {
            s.SeatKey = _keyCount++;
            Seats.Add(s.SeatKey, s);
        }
        public void DeleteMovie(int key)
        {
            Seats.Remove(key);
        }
    }
}
