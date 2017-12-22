﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace Movies_Timetabel
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {

        private string doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GrozniCinemaData\data.txt";

        public MainAdminPage()
        {
            InitializeComponent();

            List<Movie> items = Movie.movies;

            listView.ItemsSource = items;

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            var add = new AddWindow();

            add.Closed += (s, eventarg) =>
            {
                listView.Items.Refresh();
            };

            add.Show();


        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            int i = listView.SelectedIndex;
            try
            {

            Movie removing = Movie.movies[i];

            Movie.movies.Remove(removing);
        } catch
            { 
        MessageBox.Show("Выберите фильм для удаления");
                   
        }
            try
            {


                string[] data = File.ReadAllLines(doc);

                File.WriteAllLines(doc, File.ReadLines(doc).Where(l => l != data[i]).ToList());

                listView.Items.Refresh();
            }
            catch {
            }
            
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {

            var find = new SearchWindow();
            find.Show();

        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
