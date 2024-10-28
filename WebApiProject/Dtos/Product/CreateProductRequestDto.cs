namespace TestWebApplication.Dtos.Product
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }

    }
}
