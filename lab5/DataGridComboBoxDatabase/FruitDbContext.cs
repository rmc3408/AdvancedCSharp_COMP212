using System.Data.Entity;

namespace DataGridComboBoxDatabase
{
    public class FruitDbContext : DbContext
    {
        
        public DbSet<Element> FruitDbSet { get; set; }
        

        public FruitDbContext() : base() { }
    }
}
