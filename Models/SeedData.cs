using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Models;
using MvcTest.Data;
using System;
using System.Linq;

namespace MvcTest.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if(context.MvcMovieModel.Any())
                {
                    return; // DB has been seeded
                }
                context.MvcMovieModel.AddRange(
                    new MvcMovieModel
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-1"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },
                    new MvcMovieModel
                    {
                        Title = "Ghostbursters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },
                    new MvcMovieModel
                    {
                        Title = "Ghostbursters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },
                    new MvcMovieModel
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
    }

}
