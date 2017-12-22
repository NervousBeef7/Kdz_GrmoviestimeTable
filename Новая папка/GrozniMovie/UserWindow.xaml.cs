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
using System.Windows.Shapes;

namespace Movies_Timetabel
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();

            List<Movie> movie = Movie.movies;

            listView.ItemsSource = movie;

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {

            var findMovie = new SearchWindow();
            findMovie.Show();

        }

        private void main_Click(object sender, RoutedEventArgs e)
        {

            var main = new MainWindow();
            this.Close();
            main.Show();

        }
    }
}
