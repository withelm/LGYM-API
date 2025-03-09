using Lgym.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public class Plan : BaseModel, IOwner
    {
        protected Plan() { }
        public Plan(string name, User owner)
        {
            Name = name;
            Owner = owner;
        }
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public User Owner { get; set; }

        [Required]
        public int Order { get; set; }

        public virtual ICollection<PlanDay> PlanDays { get; set; }
    }
}
