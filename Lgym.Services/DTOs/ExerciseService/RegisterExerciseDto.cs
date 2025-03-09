namespace Lgym.Services.DTOs.ExerciseService
{
    public class RegisterExerciseDto
    {
        public string Name { get; set; }
        public bool IsGlobal { get; set; }
        public LookupItemDto BodyPart { get; set; }
    }
}
