using ISIP424_Shornikova.WPF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISIP424_Shornikova.WPF.Pages
{
    public partial class MainPage : Page
    {
        private List<Movie> _allMovies;
        public MainPage()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            _allMovies = Core.Context.Movie.ToList();
            UpdateMoviesList();
        }

        private void UpdateMoviesList()
        {
            string search = SearchBox.Text.ToLower();
            List<Movie> filtered = new List<Movie>();
            foreach (Movie m in _allMovies)
            {
                if (m.Title != null && m.Title.ToLower().Contains(search))
                {
                    filtered.Add(m);
                }
            }

            if (SortCombo.SelectedIndex == 0)
            {
                filtered = filtered.OrderBy(p => p.Title).ToList();
            }
            else if (SortCombo.SelectedIndex == 1)
            {
                filtered = filtered.OrderByDescending(p => p.Rating).ToList();
            }

            MoviesListBox.ItemsSource = filtered;
        }

        private void MoviesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Movie clickedMovie = MoviesListBox.SelectedItem as Movie;
            if (clickedMovie != null)
            {
                NavigationService.Navigate(new MoviePage(clickedMovie));
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMoviesList();
        }
        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMoviesList();
        }
        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AuthPage());
        }
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Core.IsAuthorized == true)
            {
                //NavigationService.Navigate(new ProfilePage());
            }
            else
            {
                MessageBox.Show("Сначала войдите в аккаунт!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //NavigationService.Navigate(new AuthPage());
            }
        }
    }
}
