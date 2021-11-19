namespace ArtistsApplicationDemo.Migrations
{
    using ArtistsApplicationDemo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArtistsApplicationDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArtistsApplicationDemo.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var artists = new List<Artist>()
            {
                new Artist
                {
                   ID = 1,
                   FirstName = "Daniel",
                   LastName = "Kastro",
                   Albums = new List<Album>()
                   {
                      new Album()
                      {
                          ID = 1,
                          Title = "Dasperate Rain",
                          Songs = new List<Song>()
                          {
                              new Song()
                              {
                                    ID = 1,
                                    Title = "Worried Baby Blues"
                              },
                              new Song()
                              {
                                  ID = 2,
                                  Title = "Mr. Lucky"
                              }
                          }
                      },
                      new Album()
                      {
                          ID = 2,
                          Title = "No Surrender",
                          Songs = new List<Song>()
                          {
                              new Song()
                              {
                                    ID = 3,
                                    Title = "Matchcox Blues"
                              },
                              new Song()
                              {
                                  ID = 4,
                                  Title = "Sweet Little Angel"
                              }
                          }
                      }
                   }
                },
                new Artist()
                {
                    ID = 2,
                    FirstName = "Rory",
                    LastName = "Gallagher",
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            ID = 3,
                            Title = "Blueprint",
                            Songs = new List<Song>()
                            {
                                new Song()
                                {
                                    ID = 5,
                                    Title = "Walk on Hot Coals"
                                },
                                new Song()
                                {
                                    ID = 6,
                                    Title = "Banker's Blues"
                                },
                                new Song()
                                {
                                    ID = 7,
                                    Title = "Race the Breeze"
                                }
                            }
                        }
                    }
                }
            };

            artists.ForEach(a => context.Artists.AddOrUpdate(a));
            context.SaveChanges();

        }
    }
    
}
