using Lgym.Services.Enums;
using Lgym.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public class Exercise : BaseModel, IOwner
    {
        protected Exercise()
        {

        }
        public Exercise(string name, User owner, BodyPart bodyPart) :
            this(name, owner, bodyPart, false)
        {
        }

        public Exercise(string name, User owner, BodyPart bodyPart, bool isGlobal)
        {
            Name = name;
            Owner = owner;
            BodyPart = bodyPart;
            IsGlobal = isGlobal;
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public User Owner { get; set; }

        [Required]
        public BodyPart BodyPart { get; set; }

        public bool IsGlobal { get; set; } = false;

        public string DisplayName => IsGlobal ? Resources.Resources.Exercise.ResourceManager.GetString(Name) : Name;

    }
}
