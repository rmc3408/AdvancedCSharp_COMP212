namespace DataGridComboBoxDatabase
{
    public class Element
    {
        public int elementID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return Name + " " + Color;
        }
    }
}