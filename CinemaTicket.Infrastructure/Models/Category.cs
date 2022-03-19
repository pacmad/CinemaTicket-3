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
        [StringLength(100,MinimumLength = 1,ErrorMessage = "{0} must be between {1} and {2} characters!!")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="{0} must be between {1} and {2} only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
