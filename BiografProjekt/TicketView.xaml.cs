using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for TicketView.xaml
    /// </summary>
    public partial class TicketView : INotifyPropertyChanged
    {
        private double _ptcAdult;
        private double _ptcChild;
        private double _ptcSenior;
        private double _ptcFriends;
        private double _ptcTotal;

        public TicketView()
        {
            DataContext = this;
            InitializeComponent();
        }

        public double PriceAdult
        {
            get { return DomainModel.Instance.Show.PriceAdult; }
        }
        public double PriceChild
        {
            get { return DomainModel.Instance.Show.PriceChild; }
        }
        public double PriceSenior
        {
            get { return DomainModel.Instance.Show.PriceSenior; }
        }
        public double PriceFriends
        {
            get { return DomainModel.Instance.Show.PriceFriends; }
        }

        public double PriceTicketCombinedAdult
        {
            get { return _ptcAdult; }
            set
            {
                _ptcAdult = value;
                OnPropertyChanged();
            }
        }
        public double PriceTicketCombinedChild
        {
            get { return _ptcChild; }
            set
            {
                _ptcChild = value;
                OnPropertyChanged();
            }
        }
        public double PriceTicketCombinedSenior
        {
            get { return _ptcSenior; }
            set
            {
                _ptcSenior = value;
                OnPropertyChanged();
            }
        }
        public double PriceTicketCombinedFriends
        {
            get { return _ptcFriends; }
            set
            {
                _ptcFriends = value;
                OnPropertyChanged();
            }
        }

        public double TotalPrice
        {
            get { return _ptcTotal; }
            set
            {
                _ptcTotal = value;
                OnPropertyChanged();
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            DomainModel.Instance.Show.SliderAdult = Convert.ToInt32(SliderAdult.Value);
            DomainModel.Instance.Show.SliderChild = Convert.ToInt32(SliderChild.Value);
            DomainModel.Instance.Show.SliderFriends = Convert.ToInt32(SliderFriends.Value);
            DomainModel.Instance.Show.SliderSenior = Convert.ToInt32(SliderSenior.Value);

            if (DomainModel.Instance.Show.SeatForShow == null)
            {
                DomainModel.Instance.Show.SeatForShow = new SeatView();
            }
            MainWindow.MainFrame.Content = DomainModel.Instance.Show.SeatForShow;
            
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int ticketCounter = Convert.ToInt32(SliderAdult.Value + SliderChild.Value + SliderFriends.Value + SliderSenior.Value);

            Button.IsEnabled = ticketCounter != 0;
            PriceTicketCombinedAdult = SliderAdult.Value * PriceAdult;
            PriceTicketCombinedChild = SliderChild.Value * PriceChild;
            PriceTicketCombinedSenior = SliderSenior.Value * PriceSenior;
            PriceTicketCombinedFriends = SliderFriends.Value * PriceFriends;
            TotalPrice = PriceTicketCombinedAdult + PriceTicketCombinedChild + PriceTicketCombinedFriends +
                         PriceTicketCombinedSenior;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
