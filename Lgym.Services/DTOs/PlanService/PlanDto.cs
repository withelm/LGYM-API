namespace Lgym.Services.DTOs.PlanService
{
    public class PlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public IdDto Owner { get; set; }
    }
}
