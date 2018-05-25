using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BiografProjekt
{
    public class DomainModel : INotifyPropertyChanged
    {
        private static DomainModel _instance;
        private int _ticket;
        private int _friends;
        private int _seniors;
        private int _adults;
        private int _child;

        public static DomainModel Instance
        {
            get
            {
                _instance = _instance ?? (_instance = new DomainModel());
                return _instance;
            }
        }

        private DomainModel()
        {
            Movies = new MovieCatalog();
            Screens = new ScreenCatalog();
            Shows = new ShowCatalog();
        }

        

        #region Properties
        public MovieCatalog Movies { get; }
        public ScreenCatalog Screens { get; }
        public ShowCatalog Shows { get; }
        public Show Show { get; set; }

        public int SliderAdult
        {
            get { return _adults; }
            set
            {
                _ticket += value;
                _adults = value;
                OnPropertyChanged();
            }
        }

        public int SliderChild
        {
            get { return _child; }
            set
            {
                _ticket += value;
                _child = value;
                OnPropertyChanged();
            }
        }

        public int SliderSenior
        {
            get { return _seniors; }
            set
            {
                _ticket += value;
                _seniors = value;
                OnPropertyChanged();
            }
        }

        public int SliderFriends
        {
            get { return _friends;}
            set
            {
                _ticket += value;
                _friends = value;
            }

        }

        public int TicketAmount
        {
            get { return _ticket; }
            set
            {
                _ticket += value;
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}