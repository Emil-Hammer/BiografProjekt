using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : Page
    {
        public PaymentView()
        {
            InitializeComponent();
        }

        private void BtnContinue_OnClick(object sender, RoutedEventArgs e)
        {
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
