namespace To_chuc_dai_hoi.Data
{
    public class ProductCategory
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
