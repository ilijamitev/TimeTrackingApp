namespace TimeTracking.Models
{
    public class Exercising : IActivity
    {
        public int Id { get; set; }
        public static int IdGenerator { get; set; } = 0;
        public double TimeSpentOnActivity { get; set; }
        public ExercisingType ExercisingType { get; set; }

        public Exercising(ExercisingType exercisingType)
        {
            Id = ++IdGenerator;
            ExercisingType = exercisingType;
        }

    }

    public enum ExercisingType
    {
        General = 1,
        Running,
        Sports
    }
}
