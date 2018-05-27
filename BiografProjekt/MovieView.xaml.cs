using System.Windows;
using System.Windows.Controls;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView
    {
        public MovieView()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            DomainModel.Instance.Show = (Show) ListBoxShow.SelectedItem;
            MainWindow.MainFrame.Content = DomainModel.Instance.Show.TicketViewForShow;
        }

        private void ListBoxShow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button.IsEnabled = ListBoxShow.SelectedItem != null;
        }
    }
}
