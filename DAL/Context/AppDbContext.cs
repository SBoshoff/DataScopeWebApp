using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    /// <summary>
    /// The DB Context for the system
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
