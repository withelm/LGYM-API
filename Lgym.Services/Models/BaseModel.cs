using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;


        public User? CreatedBy { get; set; }

        public User? ModifiedBy { get; set; }
    }
}
