using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public class PlanDayExercise : BaseModel
    {
        protected PlanDayExercise() { }
        public PlanDayExercise(PlanDay planDay, int order, Exercise exercise)
        {
            PlanDay = planDay;
            Order = order;
            Exercise = exercise;
        }
        [Required]
        public PlanDay PlanDay { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public Exercise Exercise { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public double MinReps { get; set; }
        [Required]
        public double MaxReps { get; set; }
    }
}
