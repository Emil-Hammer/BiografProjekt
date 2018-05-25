using System;
using System.Windows;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for TicketView.xaml
    /// </summary>
    public partial class TicketView
    {
        public TicketView()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            DomainModel.Instance.SliderAdult = Convert.ToInt32(SliderAdult.Value);
            DomainModel.Instance.SliderChild = Convert.ToInt32(SliderChild.Value);
            DomainModel.Instance.SliderFriends = Convert.ToInt32(SliderFriends.Value);
            DomainModel.Instance.SliderSenior = Convert.ToInt32(SliderSenior.Value);

            MainWindow.MainFrame.Content = new SeatView();
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var ticketCounter = SliderAdult.Value + SliderChild.Value + SliderFriends.Value + SliderSenior.Value;

            Button.IsEnabled = ticketCounter != 0;
        }
    }
}
