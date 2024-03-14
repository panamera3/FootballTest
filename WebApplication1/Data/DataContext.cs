﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
