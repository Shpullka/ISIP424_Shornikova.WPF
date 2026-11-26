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
using System.Data.Entity;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISIP424_Shornikova.WPF.Pages
{
    public partial class MoviePage : Page
    {
        public Movie CurrentMovie { get; set; }
        public MoviePage(Movie movie)
        {
            InitializeComponent();
            CurrentMovie = movie;
            this.DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            TitleText.Text = CurrentMovie.Title;
            DescText.Text = CurrentMovie.Description;
            RatingText.Text = "Рейтинг: " + CurrentMovie.Rating.ToString();
            AgeText.Text = "Возраст: " + CurrentMovie.AgeRating.ToString() + "+";

            var session = Core.Context.Session.Include(p => p.Hall).Where(p => p.MovieID == CurrentMovie.MovieID).ToList();
            SessionsList.ItemsSource = session;
        }

        private void SessionsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Session selected = SessionsList.SelectedItem as Session;
            if (selected != null)
            {
                if (Core.IsAuthorized == false)
                {
                    MessageBox.Show("Для покупки билета нужно авторизоваться!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    //NavigationService.Navigate(new AuthPage());
                }
                else
                {
                    //NavigationService.Navigate(new SessionPage(selected));
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
