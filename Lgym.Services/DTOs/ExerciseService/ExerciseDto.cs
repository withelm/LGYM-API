namespace Lgym.Services.DTOs.ExerciseService
{

    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlobal { get; set; }
        public LookupItemDto BodyPart { get; set; }

        public IdDto Owner { get; set; }
    }
}
