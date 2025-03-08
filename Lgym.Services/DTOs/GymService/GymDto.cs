namespace Lgym.Services.DTOs.GymService
{
    public class GymDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IdDto Owner { get; set; }
    }
}
