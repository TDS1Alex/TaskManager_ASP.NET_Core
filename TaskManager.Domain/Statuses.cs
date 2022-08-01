namespace TaskManager.Domain
{
    public class Statuses
    {
        public int Id { get; set; }
        public string? InPlans { get; set; }
        public string? InProcess { get; set; }
        public string? Stopped { get; set; }
        public string? Done { get; set; }
        public string? StatusNoSet { get; set; }
    }
}
