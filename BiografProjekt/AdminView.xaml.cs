using System;
using System.Windows;
using System.Windows.Controls;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView
    {
        public AdminView()
        {
            InitializeComponent();

            ComboboxHour.Items.Add(0);
            for (int i = 1; i < 24; i++)
            {
                ComboboxHour.Items.Add(i);
            }

            for (int i = 0; i < 56; i++)
            {
                if (i % 5 == 0)
                {
                    ComboboxMinute.Items.Add(i);
                }
            }
        }

        private void ButtonBase_OnClick__(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDate = (DatePicker) sender;
            selectDate.SelectedDate.ToString();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
