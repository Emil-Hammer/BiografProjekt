using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BiografProjekt
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private Movie _selectedMovie;
        private Show _selectedShow;
        private ObservableCollection<Movie> _movieCollection;
        private ObservableCollection<Show> _showCollection;

        public MovieViewModel()
        {
            _movieCollection = new ObservableCollection<Movie>();
            _showCollection = new ObservableCollection<Show>();

            foreach (Movie m in DomainModel.Instance.Movies.Movies.Values)
            {
                _movieCollection.Add(m);
            }
        }

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                FindShows();
                
                OnPropertyChanged();
            }
        }

        public Show SelectedShow
        {
            get { return _selectedShow; }
            set
            {
                _selectedShow = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Movie> MovieCollection
        {
            get { return _movieCollection; }
        }

        public ObservableCollection<Show> ShowCollection
        {
            get { return _showCollection; }
        }

        public void FindShows()
        {
            _showCollection.Clear();
            foreach (Show obj in DomainModel.Instance.Shows.Shows.Values)
            {
                int showMovieKey = obj.MovieKey;
                if(_selectedMovie != null)
                {
                    if (_selectedMovie.Key == showMovieKey)
                    {
                        _showCollection.Add(obj);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}