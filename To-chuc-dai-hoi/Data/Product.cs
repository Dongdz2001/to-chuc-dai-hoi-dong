namespace To_chuc_dai_hoi.Data
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategorys { get; set; }
    }
}
