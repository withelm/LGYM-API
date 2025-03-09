namespace Lgym.Services.DTOs.PlanDayService
{
    public class PlanDayDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public LookupItemDto Plan { get; set; }
    }
}
