﻿namespace Lgym.Services.DTOs.PlanDayExerciseService
{
    public class RegisterPlanDayExerciseDto
    {
        public string Name { get; set; }
        public LookupItemDto PlanDay { get; set; }
        public LookupItemDto Exercise { get; set; }
        public int Order { get; set; }
        public int Reps { get; set; }
        public double MinReps { get; set; }
        public double MaxReps { get; set; }
    }
}
