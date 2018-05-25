using System;
using System.Windows;
using System.Windows.Controls;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static Frame _mainFrame;

        public MainWindow()
        {
            

            DomainModel.Instance.Movies.AddMovie("Deadpool 2", 134, 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Avengers: Infinity War", 144, 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Utøya", 112, 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Solo: A Star Wars Story", 155, 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Screens.AddScreen(2,2);
            DomainModel.Instance.Screens.AddScreen(4, 1);
            DomainModel.Instance.Screens.AddScreen(6, 8);
            DomainModel.Instance.Shows.AddShow(2,1,new DateTime(2018,3,10,10,15,0));
            DomainModel.Instance.Shows.AddShow(3, 2, new DateTime(2018, 3, 10, 12, 15, 0));
            DomainModel.Instance.Movies.RunningTime(1);
            DomainModel.Instance.Movies.GetRating(1);
            InitializeComponent();
            _mainFrame = Main;
        }

        private void BtnP1_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new MovieView();
        }

        private void BtnP2_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminView();
        }
    }
}
