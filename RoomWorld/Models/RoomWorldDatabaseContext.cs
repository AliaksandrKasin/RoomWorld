﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RoomWorld.Models
{
    public class RoomWorldDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public RoomWorldDatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Data Source=WS-018-41\SQLEXPRESS;Initial Catalog=RoomWorld;Integrated Security=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
