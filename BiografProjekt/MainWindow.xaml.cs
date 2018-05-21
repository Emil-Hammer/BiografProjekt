using System;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DomainModel.Instance.Movies.AddMovie("Hej med dig", TimeSpan.FromMinutes(134), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Hej med dig 2", TimeSpan.FromMinutes(144), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Hej med dig 3", TimeSpan.FromMinutes(112), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Hej med dig 4", TimeSpan.FromMinutes(155), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            var myKey = DomainModel.Instance.Movies.GetMovie(1);
            DomainModel.Instance.Screens.AddScreen(2,2);
            DomainModel.Instance.Screens.AddScreen(4, 1);
            DomainModel.Instance.Screens.AddScreen(6, 8);
            DomainModel.Instance.Shows.AddShow(2,1,new DateTime(2018,3,10,10,15,0));
            DomainModel.Instance.Shows.AddShow(3, 2, new DateTime(2018, 3, 10, 12, 15, 0));
            DomainModel.Instance.Movies.RunningTime(1);
            InitializeComponent();

        }
    }
}
