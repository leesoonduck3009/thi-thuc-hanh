namespace TestWebApplication.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }

    }
}
