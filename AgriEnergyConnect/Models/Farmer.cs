namespace AgriEnergyConnect.Models
{
    public class Farmer
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

        public ICollection<Product> Products { get; set; } // Navigation property for the products added by the farmer
    }
}
