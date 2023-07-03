using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace To_chuc_dai_hoi.DTO
{
    public class PeopleChooseProductDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string Contact { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

