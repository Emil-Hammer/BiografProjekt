using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : INotifyPropertyChanged
    {
        private int _textboxCounter;

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
        
        private void ButtonRemoveMovie_OnClick(object sender, RoutedEventArgs e)
        {
            Movie obj = (Movie) ListView.SelectedItem;
            DomainModel.Instance.Movies.DeleteMovie(obj.Key);
            MainWindow.MainFrame.Content = new AdminView();
        }

        private void BtnCreateMovie_OnClick(object sender, RoutedEventArgs e)
        {
            DomainModel.Instance.Movies.AddMovie(Title.Text, Convert.ToInt32(Length.Text),
                Convert.ToInt32(Agelimit.Text), Director.Text, MainActors.Text);
            Title.Text = "";
            Length.Text = "";
            Agelimit.Text = "";
            Director.Text = "";
            MainActors.Text = "";
            MainWindow.MainFrame.Content = new AdminView();

        }

        private void BtnCreateShow_OnClick(object sender, RoutedEventArgs e)
        {
            Movie movVar = (Movie)ListView.SelectedItem;


            //Hele denne del opfører sig meget underligt og virker ikke.
            if (DatePicker.SelectedDate != null) 
            {
                var screen = DomainModel.Instance.Shows.FindAvailableScreen(DatePicker, Convert.ToInt32(ComboboxHour.Text), Convert.ToInt32(ComboboxMinute.Text), movVar.Length);
                
                if (screen == 100)
                {
                    MessageBox.Show("Kunne ikke finde en gyldig sal at placere showet i. Prøv et andet tidspunkt.");
                }
                else if (screen == 101)
                {
                    MessageBox.Show("Du har ikke valgt en dato");
                }
                else
                {
                DateTime datePicker = DatePicker.SelectedDate.Value;
                
                DateTime movDateTime = new DateTime(datePicker.Year,datePicker.Month,datePicker.Day, Convert.ToInt32(ComboboxHour.Text), Convert.ToInt32(ComboboxMinute.Text), 0);
                DomainModel.Instance.Shows.AddShow(movVar.Key, screen,movDateTime,Convert.ToInt32(TextBoxPrice.Text));
                MessageBox.Show("Oprettet show!");
                }
            }
        }


        private void Length_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void Movie_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "" || Length.Text == "" || Agelimit.Text == "" || Director.Text == "" ||
                MainActors.Text == "")
            {
                CreateMovie.IsEnabled = false;
            }
            else
            {
                CreateMovie.IsEnabled = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            ComboboxScreen_SelectionChanged(sender, e);
            if (sender != null)
            {
                ButtonMovieRemove.IsEnabled = true;
            }
            else
            {
                ButtonMovieRemove.IsEnabled = false;
            }
        }

        private void ComboboxScreen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxHour.SelectedValue == null ||
                ComboboxMinute.SelectedValue == null || DatePicker.SelectedDate == null || ListView.SelectedItem == null || _textboxCounter == 0)
            {
                CreateShow.IsEnabled = false;
            }
            else
            {
                CreateShow.IsEnabled = true;
            }
         
        }

        private void TextBoxPrice_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxPrice.Text == "")
            {
                _textboxCounter = 0;
            }
            else
            {
                _textboxCounter = 1;
            }
            
            ComboboxScreen_SelectionChanged(sender, null);

        }
    }
}