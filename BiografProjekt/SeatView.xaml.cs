using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BiografProjekt
{
    public partial class SeatView : INotifyPropertyChanged
    {
        private int _seatNumber;
        private int _rowNumber = 1;
        private List<string> _seatList;
        private string _returner;

        public SeatView()
        {
            DataContext = this;
            _seatList = new List<string>();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
                var button = (Button)sender;
                if (button.Background.Equals(Brushes.LimeGreen))
                {
                    if (DomainModel.Instance.Show.TicketAmount != 0)
                    {
                        DomainModel.Instance.Show.TicketAmount = -1;
                        button.Background = Brushes.Blue;
                        _seatList.Add(button.Tag.ToString());
                        OnPropertyChanged(nameof(GetTicket));
                    }
                    else
                    {
                        MessageBox.Show("Du har allerede valgt dine billetter.");
                    }
                }
                else if (button.Background.Equals(Brushes.Blue))
                {
                    DomainModel.Instance.Show.TicketAmount = 1;
                    button.Background = Brushes.LimeGreen;
                    _seatList.Remove(button.Tag.ToString());
                    OnPropertyChanged(nameof(GetTicket));
                }
                else if (button.Background.Equals(Brushes.Red))
                {
                    MessageBox.Show("Dette sæde er optaget");
                }

                if (DomainModel.Instance.Show.TicketAmount != 0)
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
            MainWindow.MainFrame.Content = new ConfirmationView();
        }

        public int GetTicket
        {
            get
            {
                if (DomainModel.Instance.Show == null)
                {
                    return 0;
                }
                return DomainModel.Instance.Show.TicketAmount;
            }
            set
            {
                OnPropertyChanged();
                DomainModel.Instance.Show.TicketAmount = value; 
            }
        }

        public string GetSeatNumber
        {
            get
            {
                int rowNo = _rowNumber;
                int seatNo = _seatNumber;

                List<string> arrayAbc = new List<string> {"0","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P"};
                string  returner= arrayAbc[rowNo] +":" + Convert.ToString(seatNo);

                _seatNumber++;
                if (seatNo == 10)
                {
                    _rowNumber++;
                    _seatNumber = 1;
                }

                _returner = returner;
                return returner;
            }

        }

        public string GetTag
        {
            get
            {
                return _returner;
            }
        }

        public List<string> GetSeatList
        {
            get { return _seatList; }
        }
       

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
