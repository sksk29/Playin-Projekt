#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playin.Models;

namespace Playin.Data
{
    public class PlayinContext : DbContext
    {
        public PlayinContext(DbContextOptions<PlayinContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameComment> GamesComments { get; set; }
        public DbSet<Esport> Esport { get; set; }
    }
}