using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicket.Infrastructure.Models
{
    public class Category
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
