namespace Lgym.Services.DTOs
{
    public class LookupItemDto
    {
        public LookupItemDto() { }
        public LookupItemDto(int id, string name) : this(id.ToString(), name)
        {

        }
        public LookupItemDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
