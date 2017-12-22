using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_Timetabel
{
    class Movie
    {

        static public List<Movie> movies = new List<Movie>();

        private DateTime date_time;

        public DateTime Date_time
        {
            get { return date_time ; }
            set { date_time = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string duration;

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        private string auditorium;

        public string Auditorium
        {
            get { return auditorium; }
            set { auditorium = value; }
        }

        private string ageRating;

        public string AgeRating
        {
            get { return ageRating; }
            set { ageRating = value; }
        }

        private string cost;

        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public Movie(DateTime date_time, string name, string duration, string auditorium, string ageRating, string cost)
        {

            this.date_time = date_time;
            this.name = name;
            this.duration = duration;
            this.auditorium = auditorium;
            this.ageRating = ageRating;
            this.cost = cost;

        }

        public Movie() { }
        public string ShowMovieCharacters()
        {
            return this.date_time + " " + this.name + " " + this.duration + " " + this.auditorium + " " + this.ageRating + " " + this.cost;
        }

        static public void GetMovie(string path)
        {

            string[] data = File.ReadAllLines(path);

            try
            {

                if (data.Length == 0) { return; }

                foreach (string str in data)
                {

                    string[] movie = str.Split(',');

                    string[] date = movie[0].Split(' ');

                    Movie.movies.Add(new Movie(new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(date[3]), int.Parse(date[4]), int.Parse(date[5])), 
                        movie[1], movie[2], movie[3], movie[4], movie[5]));

                } 
            } catch
            {
                
            }
            
        }
        
        static public void AddMovie(Movie movie, string path)
        {

            movies.Add(movie);

            using (StreamWriter sw = File.AppendText(path))
            {

                sw.WriteLine ("{0} {1} {2} {3} {4} {5},{6},{7},{8},{9},{10}", movie.date_time.Year, movie.date_time.Month, movie.date_time.Day, movie.date_time.Hour, movie.date_time.Minute, 
                    movie.date_time.Second, movie.Name, movie.Duration, movie.Auditorium, movie.AgeRating, movie.Cost);

            }

        } 

    }
}
