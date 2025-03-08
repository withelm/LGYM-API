using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public class Gym : BaseModel
    {
        protected Gym()
        {

        }
        public Gym(string name, User owner)
        {
            Name = name;
            Owner = owner;
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public User Owner { get; set; }


    }
}
