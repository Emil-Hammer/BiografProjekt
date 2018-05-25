using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BiografProjekt
{
    public partial class SeatView : INotifyPropertyChanged
    {
        private int _seatNumber = 1;
        private int _rowNumber = 1;

        public SeatView()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button.Background.Equals(Brushes.LimeGreen))
            {
                if (DomainModel.Instance.TicketAmount != 0)
                {
                    DomainModel.Instance.TicketAmount = -1;
                    button.Background = Brushes.Blue;
                }
                else
                {
                    MessageBox.Show("Du har allerede valgt dine billetter.");
                }
            }
            else if (button.Background.Equals(Brushes.Blue))
            {
                DomainModel.Instance.TicketAmount = 1;
                button.Background = Brushes.LimeGreen;
            }
            else if (button.Background.Equals(Brushes.Red))
            {
                MessageBox.Show("Dette sæde er optaget");
            }

            if (DomainModel.Instance.TicketAmount != 0)
            {
                BtnContinue.IsEnabled = false;
            }
            else
            {
                BtnContinue.IsEnabled = true;
            }
            OnPropertyChanged();
        }

        private void BtnContinue_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ConfirmationView(this);
        }

        public int GetTicket
        {
            get { return DomainModel.Instance.TicketAmount; }
            set => DomainModel.Instance.TicketAmount = value;
        }

        public string GetSeatNumber
        {
            get
            {
                int seatNo = _seatNumber++;
                int rowNo = _rowNumber;

                if (seatNo == 10)
                {
                    _seatNumber = 1;
                    _rowNumber++;
                }

                string[] arrayAbc = new string[] {"0","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T"};

                return arrayAbc[rowNo] + ":" + Convert.ToString(seatNo);}
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
