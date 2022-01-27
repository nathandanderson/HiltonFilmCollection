using Microsoft.EntityFrameworkCore;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class NewMovieContext : DbContext
    {
        //Constructor   
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options)
        {
            //Leave blank for now
        }
        public DbSet<MovieResponse> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(

                    new MovieResponse
                    {
                        MovieID = 1,
                        Category = "Science Fiction",
                        Title = "Tron Legacy",
                        Year = 2012,
                        Director = "Joseph Kosinski",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "Nathan Anderson",
                        Notes = "Favorite Movie"
                    },
                    new MovieResponse
                    {
                        MovieID = 2,
                        Category = "Science Fiction",
                        Title = "Tenet",
                        Year = 2020,
                        Director = "Christopher Nolan",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "Joey Tate",
                        Notes = "Mind Blowing"
                    },
                    new MovieResponse
                    {
                        MovieID = 3,
                        Category = "Science Fiction",
                        Title = "Interstellar",
                        Year = 2012,
                        Director = "Christopher Nolan",
                        Rating = "PG-13",
                        Edited = true,
                        LentTo = "Tyler Nelson",
                        Notes = "Best Space Movie"
                    }
                );
        }
    }
}