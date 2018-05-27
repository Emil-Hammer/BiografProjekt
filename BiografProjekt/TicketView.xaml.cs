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
                _ptcAdult = DomainModel.Instance.Show.SliderAdult * DomainModel.Instance.Show.PriceAdult;
                OnPropertyChanged(nameof(PriceTicketCombinedAdult));
            }
        }
        public double PriceTicketCombinedChild
        {
            get { return _ptcChild; }
            set
            {
                _ptcChild = DomainModel.Instance.Show.SliderChild * DomainModel.Instance.Show.PriceChild;
                OnPropertyChanged(nameof(PriceTicketCombinedChild));
            }
        }
        public double PriceTicketCombinedSenior
        {
            get { return _ptcSenior; }
            set
            {
                _ptcSenior = DomainModel.Instance.Show.SliderSenior * DomainModel.Instance.Show.PriceSenior;
                OnPropertyChanged(nameof(PriceTicketCombinedSenior));
            }
        }
        public double PriceTicketCombinedFriends
        {
            get { return _ptcFriends; }
            set
            {
                _ptcFriends = DomainModel.Instance.Show.SliderFriends * DomainModel.Instance.Show.PriceFriends;
                OnPropertyChanged(nameof(PriceTicketCombinedFriends));
            }
        }

        public double TotalPrice => PriceTicketCombinedFriends + PriceTicketCombinedAdult + PriceTicketCombinedChild + PriceTicketCombinedSenior;

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            DomainModel.Instance.Show.SliderAdult = Convert.ToInt32(SliderAdult.Value);
            DomainModel.Instance.Show.SliderChild = Convert.ToInt32(SliderChild.Value);
            DomainModel.Instance.Show.SliderFriends = Convert.ToInt32(SliderFriends.Value);
            DomainModel.Instance.Show.SliderSenior = Convert.ToInt32(SliderSenior.Value);

            MainWindow.MainFrame.Content = DomainModel.Instance.Show.SeatForShow;
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int ticketCounter = Convert.ToInt32(SliderAdult.Value + SliderChild.Value + SliderFriends.Value + SliderSenior.Value);

            Button.IsEnabled = ticketCounter != 0;
            OnPropertyChanged(nameof(PriceTicketCombinedAdult));
            OnPropertyChanged(nameof(PriceTicketCombinedChild));
            OnPropertyChanged(nameof(PriceTicketCombinedFriends));
            OnPropertyChanged(nameof(PriceTicketCombinedSenior));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
