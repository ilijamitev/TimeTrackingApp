namespace TimeTracking.Models
{
    public interface IActivity
    {
        public int Id { get; set; }
        public double TimeSpentOnActivity { get; set; }
    }
}
