using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for SeatView.xaml
    /// </summary>
    public partial class SeatView : Page
    {
        private int _tickets = DomainModel.Instance.TicketAmount;
        public SeatView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button.Background.Equals(Brushes.LightBlue))
            {
                if (_tickets != 0)
                {
                    _tickets--;
                    button.Background = Brushes.Blue;
                }
                else
                {
                    MessageBox.Show("Du har allerede valgt dine billetter.");
                }
            }
            else if (button.Background.Equals(Brushes.Blue))
            {
                _tickets++;
                button.Background = Brushes.LightBlue;
            }
            else if (button.Background.Equals(Brushes.Red))
            {
                MessageBox.Show("Dette sæde er optaget");
            }

          
        }
    }
}
