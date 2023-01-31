using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Playin.Data;
using Playin.Models;
using System;
using System.Linq;

namespace Playin.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PlayinContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PlayinContext>>()))
            {
                // Look for any movies.
                if (context.Games.Any())
                {
                    return;   // DB has been seeded
                }

                context.Games.AddRange(
                    new Game
                    {
                        Name = "Witcher 3",
                        ReleaseDate = DateTime.Parse("2015-5-19"),
                        Genre = "RPG",
                    },

                    new Game
                    {
                        Name = "Dying Light 2",
                        ReleaseDate = DateTime.Parse("2022-2-4"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Cyberpunk 2077",
                        ReleaseDate = DateTime.Parse("2020-12-10"),
                        Genre = "RPG",
                    },

                    new Game
                    {
                        Name = "Grand Theft Auto V",
                        ReleaseDate = DateTime.Parse("2013-9-17"),
                        Genre = "Action",
                    },


                    new Game
                    {
                        Name = "Gothic 2",
                        ReleaseDate = DateTime.Parse("2002-11-29"),
                        Genre = "RPG",
                    },

                    new Game
                    {
                        Name = "Gothic 3",
                        ReleaseDate = DateTime.Parse("2006-10-13"),
                        Genre = "RPG",
                    },

                    new Game
                    {
                        Name = "Portal 2",
                        ReleaseDate = DateTime.Parse("2011-4-19"),
                        Genre = "Logic",
                    },

                    new Game
                    {
                        Name = "Battle Brothers",
                        ReleaseDate = DateTime.Parse("2017-3-24"),
                        Genre = "Strategy",
                    },

                    new Game
                    {
                        Name = "Thief: The Dark Project",
                        ReleaseDate = DateTime.Parse("1998-12-2"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Thief 2: The Metal Age",
                        ReleaseDate = DateTime.Parse("2000-3-23"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "American Truck Simulator: Colorado",
                        ReleaseDate = DateTime.Parse("2020-11-12"),
                        Genre = "Simulator",
                    },

                    new Game
                    {
                        Name = "World of Warcraft",
                        ReleaseDate = DateTime.Parse("2004-11-23"),
                        Genre = "MMORPG",
                    },

                    new Game
                    {
                        Name = "Witcher 2",
                        ReleaseDate = DateTime.Parse("2011-5-17"),
                        Genre = "RPG",
                    },

                    new Game
                    {
                        Name = "Dishonored",
                        ReleaseDate = DateTime.Parse("2012-10-9"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Hollow Knight",
                        ReleaseDate = DateTime.Parse("2017-2-24"),
                        Genre = "Arcade",
                    },

                    new Game
                    {
                        Name = "BioShock Infinite",
                        ReleaseDate = DateTime.Parse("2013-03-26"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Tomb Raider",
                        ReleaseDate = DateTime.Parse("2013-3-5"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Heroes of Might and Magic III: The Restoration of Erathia",
                        ReleaseDate = DateTime.Parse("1999-2-28"),
                        Genre = "Strategy",
                    },

                    new Game
                    {
                        Name = "Assassin's Creed II",
                        ReleaseDate = DateTime.Parse("2009-11-17"),
                        Genre = "Action",
                    },
                    
                    new Game
                    {
                        Name = "UnReal World",
                        ReleaseDate = DateTime.Parse("2016-2-26"),
                        Genre = "RPG",
                    },

                    new Game
                    {
                        Name = "Space Engineers",
                        ReleaseDate = DateTime.Parse("2019-2-28"),
                        Genre = "Simulator",
                    },

                    new Game
                    {
                        Name = "Kentucky Route Zero",
                        ReleaseDate = DateTime.Parse("2013-1-7"),
                        Genre = "Adventure",
                    },

                    new Game
                    {
                        Name = "BirdGut",
                        ReleaseDate = DateTime.Parse("2019-5-9"),
                        Genre = "Arcade",
                    },

                    new Game
                    {
                        Name = "Rez Infinite",
                        ReleaseDate = DateTime.Parse("2016-10-13"),
                        Genre = "Arcade",
                    },

                    new Game
                    {
                        Name = "Super Mario Galaxy",
                        ReleaseDate = DateTime.Parse("2007-11-12"),
                        Genre = "Arcade",
                    },

                    new Game
                    {
                        Name = "Beat Saber",
                        ReleaseDate = DateTime.Parse("2018-11-20"),
                        Genre = "Arcade",
                    },

                    new Game
                    {
                        Name = "Age of Empires IV",
                        ReleaseDate = DateTime.Parse("2021-10-28"),
                        Genre = "Strategy",
                    },

                    new Game
                    {
                        Name = "Democracy 4",
                        ReleaseDate = DateTime.Parse("2022-1-13"),
                        Genre = "Strategy",
                    },

                    new Game
                    {
                        Name = "Red Dead Redemption 2",
                        ReleaseDate = DateTime.Parse("2018-10-26"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Battlefield 2042",
                        ReleaseDate = DateTime.Parse("2021-11-19"),
                        Genre = "Action",
                    },

                    new Game
                    {
                        Name = "Minecraft",
                        ReleaseDate = DateTime.Parse("2011-11-18"),
                        Genre = "Adventure",
                    },

                    new Game
                    {
                        Name = "Euro Truck Simulator 2",
                        ReleaseDate = DateTime.Parse("2012-10-19"),
                        Genre = "Simulator",
                    },

                    new Game
                    {
                        Name = "The Sims 4",
                        ReleaseDate = DateTime.Parse("2014-9-2"),
                        Genre = "Simulator",
                    },

                    new Game
                    {
                        Name = "Farming Simulator 22",
                        ReleaseDate = DateTime.Parse("2021-11-22"),
                        Genre = "Simulator",
                    },

                    new Game
                    {
                        Name = "Uncharted: Legacy of Thieves Collection",
                        ReleaseDate = DateTime.Parse("2022-1-28"),
                        Genre = "Adventure",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}