using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public class PlanDay : BaseModel
    {
        protected PlanDay() { }
        public PlanDay(string name, Plan plan, int order)
        {
            Name = name;
            Plan = plan;
            Order = order;
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public Plan Plan { get; set; }
        [Required]
        public int Order { get; set; }

        public IEnumerable<PlanDayExercise> Exercises { get; set; }

    }
}
