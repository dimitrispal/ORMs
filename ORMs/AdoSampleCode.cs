using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ORMs.Example1
{
    public class AdoSampleCode
    {
        public void SaveMovie()
        {
            using (var connection = new SqlConnection("connection"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO Movie (Name, Director, DateReleased) VALUES(@Name, @Director, @DateReleased)";

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = "Shape of Water";
                command.Parameters.Add("@Director", System.Data.SqlDbType.VarChar).Value = "Guillermo del Toro";
                command.Parameters.Add("@DateReleased", System.Data.SqlDbType.DateTime).Value = new DateTime(2017, 12, 1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void GetMovies()
        {
            using (var connection = new SqlConnection("connection"))
            using (var command = new SqlCommand())
            using (var adapter = new SqlDataAdapter(command))
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Movie";

                var table = new DataTable();
                adapter.Fill(table);

                var movies = new List<Movie>();

                foreach(var row in table.Rows.Cast<DataRow>())
                {
                    var movie = new Movie();
                    movie.Id = Convert.ToInt32(row["Id"]);
                    movie.Name = row["Name"].ToString();
                    movie.DateReleased = Convert.ToDateTime(row["DateReleased"]);
                    movie.Director = row["Director"].ToString();

                    movies.Add(movie);
                }
            }
        }
    }
}
