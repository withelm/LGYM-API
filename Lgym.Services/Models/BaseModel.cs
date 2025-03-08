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
        [ConcurrencyCheck]
        public int Version { get; set; } = 0;

        public User? CreatedBy { get; set; }

        public User? ModifiedBy { get; set; }


        public void SetDeleted(bool isDeleted = true)
        {
            IsDeleted = isDeleted;
        }
    }
}
