namespace To_chuc_dai_hoi.Data
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> CategoryProducts { get; set; }
    }
}
