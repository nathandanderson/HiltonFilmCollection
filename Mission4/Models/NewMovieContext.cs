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
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
            //Categories to seed
                new Category { CategoryID = 1, CategoryName = "Science Fiction" },
                new Category { CategoryID = 2, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 3, CategoryName = "Comedy" },
                new Category { CategoryID = 4, CategoryName = "Drama" },
                new Category { CategoryID = 5, CategoryName = "Family" },
                new Category { CategoryID = 6, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 7, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 8, CategoryName = "Television" },
                new Category { CategoryID = 9, CategoryName = "VHS" }
                );

            mb.Entity<MovieResponse>().HasData(

                //Movies to seed

                    new MovieResponse
                    {
                        MovieID = 1,
                        CategoryID = 1,
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
                        CategoryID = 1,
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
                        CategoryID = 1,
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