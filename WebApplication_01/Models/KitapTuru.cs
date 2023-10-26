using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_01.Models
{
    public class KitapTuru
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Kitap Türü Adı")]
        public string Ad { get; set; }

    }
}
