﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static Frame MainFrame;

        public MainWindow()
        {
            DomainModel.Instance.Movies.AddMovie("Deadpool 2", 134, 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Avengers: Infinity War", 144, 5, "Leonardo da Vinci",
                "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Utøya", 112, 5, "Leonardo da Vinci", "Leonardo diCaprio");
            DomainModel.Instance.Movies.AddMovie("Solo: A Star Wars Story", 155, 5, "Leonardo da Vinci",
                "Leonardo diCaprio");
            DomainModel.Instance.Screens.AddScreen(2, 2);
            DomainModel.Instance.Screens.AddScreen(4, 1);
            DomainModel.Instance.Screens.AddScreen(6, 8);
            DomainModel.Instance.Shows.AddShow(2, 1, new DateTime(2018, 3, 10, 10, 15, 0), 100);
            DomainModel.Instance.Shows.AddShow(3, 2, new DateTime(2018, 3, 10, 12, 15, 0), 100);
            DomainModel.Instance.Movies.RunningTime(1);
            DomainModel.Instance.Movies.GetRating(1);
            InitializeComponent();
            MainFrame = Main;
        }

        private void BtnP1_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Main.Content.Equals(DomainModel.Instance.Show.ReceiptForShow))
            {
                    if (DomainModel.Instance.Show != null)
                    {
                        foreach (var v in DomainModel.Instance.Show.SeatForShow.GetSeatButtonList)
                        {
                            v.Background = Brushes.LimeGreen;
                        }

                        DomainModel.Instance.Show.SeatForShow.GetSeatList.Clear();
                    }
            }

            if (DomainModel.Instance.Show != null)
            {
                DomainModel.Instance.Show.SeatForShow.GetSeatButtonList.Clear();
                DomainModel.Instance.Show.SeatForShow.GetSeatList.Clear();
            }

            Main.Content = new MovieView();
        }

        private void BtnP2_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminView();
        }
    }
}