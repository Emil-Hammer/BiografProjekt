using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView
    {
        public PaymentView()
        {
            InitializeComponent();
        }

        private void BtnContinue_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var v in DomainModel.Instance.Show.SeatForShow.GetSeatButtonList)
            {
                v.Background = Brushes.Red;
            }
            MainWindow.MainFrame.Content = DomainModel.Instance.Show.ReceiptForShow = new ReceiptView();
        }

        private void CardInfo_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Cardnumber.Text == "" || Securitycode.Text == "" || Year.Text == "" ||
                Month.Text == "" || Cardnumber.Text.Length != 16)
            {
                BtnPay.IsEnabled = false;
            }
            else
            {
                BtnPay.IsEnabled = true;
            }
        }

        private void Number_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
    }
}
