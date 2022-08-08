namespace TimeTracking.Models
{
    public class Working : IActivity
    {
        public int Id { get; set; }
        public static int IdGenerator { get; set; } = 0;
        public double TimeSpentOnActivity { get; set; }
        public WorkingPlace WorkingPlace { get; set; }
        public Working(WorkingPlace workingPlace)
        {
            Id = ++IdGenerator;
            WorkingPlace = workingPlace;
        }


    }

    public enum WorkingPlace
    {
        AtOffice = 1,
        AtHome
    }
}
