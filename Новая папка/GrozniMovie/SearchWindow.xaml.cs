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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {

        static private List<Movie> findResult = new List<Movie>();

        public SearchWindow()
        {
            InitializeComponent();

            listViewFind.ItemsSource = findResult;

        }

        private void find_Click(object sender, RoutedEventArgs e)
        {

            string searchName = this.search.Text;

            Movie search = Movie.movies.Find(x=>x.Name.Contains(searchName));

            if (search == null)
            {
                MessageBox.Show("Ничего не найдено!");
                return;
            }

            findResult.Add(search);

            listViewFind.Items.Refresh();

        }
    }
}
