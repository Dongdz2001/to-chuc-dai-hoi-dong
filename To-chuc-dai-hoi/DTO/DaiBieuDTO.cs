using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace To_chuc_dai_hoi.DTO
{
    public class DaiBieuDTO
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string WorkPlace { get; set; }
        [Required]
        public string Contact { get; set; }

        public string Status { get; set; }
    }
}
