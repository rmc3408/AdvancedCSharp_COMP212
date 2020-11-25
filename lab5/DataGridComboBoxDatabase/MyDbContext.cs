using System.Data.Entity;

namespace DataGridComboBoxDatabase
{
    public class MyDbContext : DbContext
    {
        //Vegetable is an entity type (see documentation for DbSet)
        public DbSet<Element> FruitDbSet { get; set; }
        public DbSet<Element> PlanetDbSet { get; set; }

        public MyDbContext() : base() { }
    }
}
