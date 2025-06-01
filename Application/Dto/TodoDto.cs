namespace Application.Dto
{
    public class TodoDto(long Id, string? Name, bool IsComplete)
    {
        public long Id { get; set; } = Id;
        public string? Name { get; set; } = Name;
        public bool IsComplete { get; set; } = IsComplete;
    }
}