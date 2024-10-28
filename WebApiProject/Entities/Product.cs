namespace TestWebApplication.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}
