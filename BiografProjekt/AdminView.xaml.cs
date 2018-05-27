using System;
using System.Dynamic;
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


        //textbox input should add new title to listview? 

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectDate = (DatePicker) sender;
            selectDate.SelectedDate.ToString();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAdd.IsEnabled = ListViewItem.IsEnabledProperty != null; // Det er vel ikke dette så den viser filmene i listview?
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            new 
        }

        private void ButtonRemove_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
