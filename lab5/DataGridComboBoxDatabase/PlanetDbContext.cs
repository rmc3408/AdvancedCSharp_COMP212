﻿using System.Data.Entity;

namespace DataGridComboBoxDatabase
{
    public class PlanetDbContext : DbContext
    {
               
        public DbSet<Element> PlanetDbSet { get; set; }

        public PlanetDbContext() : base() { }
    }
}