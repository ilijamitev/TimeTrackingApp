namespace TimeTracking.Models
{
    public class Reading : IActivity
    {
        public int Id { get; set; }
        public static int IdGenerator { get; set; } = 0;
        public int NumberOfPages { get; set; }
        public double TimeSpentOnActivity { get; set; }
        public BookGenre BookGenre { get; set; }

        public Reading(int pages, BookGenre bookGenre)
        {
            Id = ++IdGenerator;
            NumberOfPages = pages;
            BookGenre = bookGenre;
        }

    }

    public enum BookGenre
    {
        Romance = 1,
        Comedy,
        Professional
    }
}
