using System.Data.Entity;

namespace DataGridComboBoxDatabase
{
    public class MyDbContext : DbContext
    {
        //Vegetable is an entity type (see documentation for DbSet)
        public DbSet<Vegetable> VegetableDbSet { get; set; }

        public MyDbContext() : base() { }
    }
}
