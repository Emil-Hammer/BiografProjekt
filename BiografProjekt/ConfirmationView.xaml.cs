using System;
using System.Collections.Generic;
using System.Windows;

namespace BiografProjekt
{
    /// <summary>
    /// Interaction logic for ConfirmationView.xaml
    /// </summary>
    public partial class ConfirmationView
    {
        public ConfirmationView()
        {
            DataContext = this;
            InitializeComponent();
        }

        public string GetTitle
        {
            get { return DomainModel.Instance.Show.MovieForShow.Title; }
        }

        public int GetLength
        {
            get { return DomainModel.Instance.Show.MovieForShow.Length; }
        }
        public int GetRating
        {
            get { return DomainModel.Instance.Show.MovieForShow.Rating; }
        }
        public int GetScreen
        {
            get { return DomainModel.Instance.Show.ScreenForShow.ScreenKey; }
        }

        public string GetDate
        {
            get { return DomainModel.Instance.Show.DateForShow.Day + "/" + DomainModel.Instance.Show.DateForShow.Month + "-" + DomainModel.Instance.Show.DateForShow.Year; }
        }

        public string GetTime
        {
            get { return DomainModel.Instance.Show.DateForShow.Hour + ":" + DomainModel.Instance.Show.DateForShow.Minute; }
        }

        public string GetSeats
        {
            get
            {
                string combinedString = string.Join(", ", DomainModel.Instance.Show.SeatForShow.GetSeatList);
                return combinedString;
            }
        }

        public List<string> TicketList
        {
            get
            {
                List<string> listOfTickets = new List<string>();

                if (DomainModel.Instance.Show.SliderAdult > 0)
                {
                    listOfTickets.Add(DomainModel.Instance.Show.SliderAdult + " Voksenbillet");
                }
                if (DomainModel.Instance.Show.SliderChild > 0)
                {
                    listOfTickets.Add(DomainModel.Instance.Show.SliderChild + " Børnebillet");
                }
                if (DomainModel.Instance.Show.SliderSenior > 0)
                {
                    listOfTickets.Add(DomainModel.Instance.Show.SliderSenior + " Seniorbillet");
                }
                if (DomainModel.Instance.Show.SliderFriends > 0)
                {
                    listOfTickets.Add(DomainModel.Instance.Show.SliderFriends + " BioVennerBillet");
                }

                return listOfTickets;
            }
        }

        public List<double> TicketCost
        {
            get
            {
                List<double> combinedCostList = new List<double>();
                double costOfAdult = DomainModel.Instance.Show.SliderAdult * DomainModel.Instance.Show.PriceAdult;
                double costOfChild = DomainModel.Instance.Show.SliderChild * DomainModel.Instance.Show.PriceChild;
                double costOfSenior = DomainModel.Instance.Show.SliderSenior * DomainModel.Instance.Show.PriceSenior;
                double costOfFriend = DomainModel.Instance.Show.SliderFriends * DomainModel.Instance.Show.PriceFriends;

                if (costOfAdult > 0)
                {
                    combinedCostList.Add(Math.Round(costOfAdult, 2));
                }
                if (costOfChild > 0)
                {
                    combinedCostList.Add(Math.Round(costOfChild, 2));
                }
                if (costOfSenior > 0)
                {
                    combinedCostList.Add(Math.Round(costOfSenior, 2));
                }
                if (costOfFriend > 0)
                {
                    combinedCostList.Add(Math.Round(costOfFriend, 2));
                }

                return combinedCostList;
            }
        }

        public List<string> TicketCombined
        {
            get
            {
                List<string> combinedTicketList = new List<string>();
                int counter = 0;
                double totalCost = 0;

                foreach (var v in TicketList)
                {
                   combinedTicketList.Add(v + " - " + TicketCost[counter] + " DKK");
                    counter++;
                }
                foreach (var b in TicketCost)
                {
                    totalCost = totalCost + b;
                }
                combinedTicketList.Add("Total: " + totalCost);
                return combinedTicketList;
            }
        }

        public string GetEndTime
        {
            get
            {
                DateTime endTime = DomainModel.Instance.Show.DateForShow.Add(new TimeSpan(0,DomainModel.Instance.Show.MovieForShow.Length,0));

                return endTime.Day + "/" + endTime.Month + " kl. " + endTime.Hour + ":" + endTime.Minute;

            }
        }

        private void BtnContinue_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = DomainModel.Instance.Show.PaymentForShow = new PaymentView();
        }
    }
}
