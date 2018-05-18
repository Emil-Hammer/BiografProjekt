using System;
using System.Windows;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DomainModel.Instance.Movies.AddMovie("Hej med dig", TimeSpan.FromMinutes(134), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Hej med dig 2", TimeSpan.FromMinutes(144), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Hej med dig 3", TimeSpan.FromMinutes(112), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Hej med dig 4", TimeSpan.FromMinutes(155), 5, "Leonardo da Vinci", "Leonardo diCaprio");
            InitializeComponent();

        }
    }
}
