using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_chuc_dai_hoi.Data
{
    public class PeopleChooseProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string Contact { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
