using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BiografProjekt
{
    public class Show : INotifyPropertyChanged
    {
        #region instance fields

        private int _movieKey;
        private int _screenKey;
        private DateTime _showDate;
        private int _showTime;
        private int _showKey;
        private SeatView _seatView;
        private TicketView _ticketView;
        private ReceiptView _receiptView;
        private PaymentView _paymentView;
        private int _ticket;
        private int _friends;
        private int _seniors;
        private int _adults;
        private int _child;
        private double _price;
        #endregion

        #region Constructor
        public Show(int showKey, int movieKey, int screenKey, DateTime dateTime, int showTime, double price)
        {
            _movieKey = movieKey;
            _screenKey = screenKey;
            _showDate = dateTime;
            _showTime = showTime;
            _showKey = showKey;
            _price = price;
            }
        #endregion

        #region Properties
        public Movie MovieForShow
        {
            get { return DomainModel.Instance.Movies.GetMovie(_movieKey); }
        }

        public PaymentView PaymentForShow
        {
            get { return _paymentView; }
            set { _paymentView = value; }
        }

        public ReceiptView ReceiptForShow
        {
            get { return _receiptView; }
            set { _receiptView = value; }
        }

        public Screen ScreenForShow
        {
            get { return DomainModel.Instance.Screens.GetScreen(_screenKey); }
        }

        public DateTime DateForShow
        {
            get { return _showDate; }
            set { _showDate = value; }
        }

        public int TimeForShow
        {
            get { return _showTime; }
            set { _showTime = value; }
        }

        public int MovieKey
        {
            get { return _movieKey; }
            set { _movieKey = value; }
        }

        public int ScreenKey
        {
            get { return _screenKey; }
            set { _screenKey = value; }
        }

        public int ShowKey
        {
            get { return _showKey; }
            set { _showKey = value; }
        }

        public SeatView SeatForShow
        {
            get { return _seatView; }
            set { _seatView = value; }
        }

        public TicketView TicketViewForShow
        {
            get
            {
                _ticketView = new TicketView();
                return _ticketView;
            }
            set { _ticketView = value; }
        }

        public int SliderAdult
        {
            get { return _adults; }
            set
            {
                _ticket += value;
                _adults = value;
                OnPropertyChanged();
            }
        }
        public int SliderChild
        {
            get { return _child; }
            set
            {
                _ticket += value;
                _child = value;
                OnPropertyChanged();
            }
        }

        public int SliderSenior
        {
            get { return _seniors; }
            set
            {
                _ticket += value;
                _seniors = value;
                OnPropertyChanged();
            }
        }

        public int SliderFriends
        {
            get { return _friends; }
            set
            {
                _ticket += value;
                _friends = value;
            }

        }
        public int TicketAmount
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket += value;
            }
        }

        public double PriceAdult
        {
            get { return _price; }
        }
        public double PriceChild
        {
            get { return _price*0.70; }
        }
        public double PriceSenior
        {
            get { return _price*0.70; }
        }
        public double PriceFriends
        {
            get { return _price*0.80; }
        }
        #endregion

        public override string ToString()
        {
            

            return _showDate.Day + "/" + _showDate.Month + "-" + _showDate.Year + " kl. " + _showDate.Hour + ":" + _showDate.Minute.ToString("00") + " - Sal: " + _screenKey;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}