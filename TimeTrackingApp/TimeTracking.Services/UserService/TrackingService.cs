using System.Diagnostics;
using TimeTracking.Models;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services.UserService
{
    public class TrackingService : ITrackingService
    {
        public double TrackTime()
        {
            Stopwatch stopwatch = new();
            HelperService.ShowTime($"Activity started tracking at {DateTime.Now.TimeOfDay}");
            while (true)
            {
                stopwatch.Start();
                HelperService.ApplicationMessage("Press Enter to stop tracking...");
                Console.ReadLine();
                stopwatch.Stop();
                break;
            }
            HelperService.ShowTime($"Activity finished tracking at {DateTime.Now.TimeOfDay}");
            double totalMinutes = Math.Round(stopwatch.Elapsed.TotalMinutes, 5, MidpointRounding.ToEven);
            HelperService.ApprovalMessage($"TOTAL TIME: {totalMinutes} minutes.");
            double totalHours = Math.Round(stopwatch.Elapsed.TotalHours, 5, MidpointRounding.ToEven);
            return totalHours;
        }

        public void TrackReading(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n   == Track Reading ==");
            int pages = GetBookPages();
            BookGenre bookGenre = GetBookGenre();
            Reading readingActivity = new(pages, bookGenre);
            readingActivity.TimeSpentOnActivity = TrackTime();
            user.ReadingList.Add(readingActivity);
            Console.ReadLine();
        }

        public int GetBookPages()
        {
            while (true)
            {
                try
                {
                    HelperService.ApplicationMessage("\nEnter number of Pages");
                    string inputPages = Console.ReadLine();
                    bool isValid = int.TryParse(inputPages, out int pages);
                    if (string.IsNullOrWhiteSpace(inputPages))
                    {
                        HelperService.ThrowException("ENTER VALUE!");
                    }
                    if (!isValid || pages < 0 || pages > 10000)
                    {
                        HelperService.ThrowException("ENTER VALID NUMBER!");
                    }
                    return pages;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public BookGenre GetBookGenre()
        {
            BookGenre bookGenre = new();
            HelperService.ApplicationMessage("Select Book Genre");
            Console.WriteLine($"1.{BookGenre.Romance}\n2.{BookGenre.Comedy}\n3.{BookGenre.Professional}");
            int inputGenre = ValidationService.ValidInputChoice(1, 3);
            if (inputGenre == 1) bookGenre = BookGenre.Romance;
            if (inputGenre == 2) bookGenre = BookGenre.Comedy;
            if (inputGenre == 3) bookGenre = BookGenre.Professional;
            return bookGenre;
        }

        public void TrackExercising(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n   == Track Exercising ==\n");
            HelperService.ApplicationMessage("Select Type of Exercise:");
            Console.WriteLine($"1.{ExercisingType.General}\n2.{ExercisingType.Running}\n3.{ExercisingType.Sports}");
            ExercisingType type = new();
            int inputChoice = ValidationService.ValidInputChoice(1, 3);
            if (inputChoice == 1) type = ExercisingType.General;
            if (inputChoice == 2) type = ExercisingType.Running;
            if (inputChoice == 3) type = ExercisingType.Sports;
            Exercising exerciseActivity = new(type);
            exerciseActivity.TimeSpentOnActivity = TrackTime();
            user.ExercisingList.Add(exerciseActivity);
            Console.ReadLine();
        }

        public void TrackWorking(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n   == Track Working ==\n");
            HelperService.ApplicationMessage("Select Place of Working:");
            Console.WriteLine($"1.{WorkingPlace.AtOffice}\n2.{WorkingPlace.AtHome}");
            WorkingPlace workingPlace = new();
            int inputChoice = ValidationService.ValidInputChoice(1, 2);
            if (inputChoice == 1) workingPlace = WorkingPlace.AtOffice;
            if (inputChoice == 2) workingPlace = WorkingPlace.AtHome;
            Working workingActivity = new(workingPlace);
            workingActivity.TimeSpentOnActivity = TrackTime();
            user.WorkingList.Add(workingActivity);
            Console.ReadLine();
        }

        public void TrackOtherHobby(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n   == Track Other Hobbies ==\n");
            HelperService.ApplicationMessage("Enter Name of Hobby:");
            string nameOfHobby = string.Empty;
            while (true)
            {
                try
                {
                    nameOfHobby = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nameOfHobby))
                    {
                        HelperService.ThrowException("ENTER VALUE!");
                    }
                    if (!nameOfHobby.ToCharArray().Any(x => char.IsLetter(x)))
                    {
                        HelperService.ThrowException("ENTER VALID HOBBY!");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
            Hobby hobby = new(nameOfHobby);
            hobby.TimeSpentOnActivity = TrackTime();
            user.HobbysList.Add(hobby);
            Console.ReadLine();
        }

    }

}
