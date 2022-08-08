using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.UserService;

namespace TimeTracking.Services.Menu
{
    public class StatsMenuService : IStatsMenu
    {
        UserStatisticService statsService = new();

        public void ReadingStats(User user)
        {
            double totalTime = statsService.GetTotalTime(user.ReadingList);
            double averageTime = statsService.GetAverageTime(user.ReadingList);
            int numberOfPages = statsService.GetNumberOfPages(user.ReadingList);
            string favouriteGenre = statsService.GetFavouriteBookGenre(user.ReadingList);
            string errorMessage = "You haven't started Reading yet.";
            while (true)
            {
                if (user.ReadingList.Count == 0)
                {
                    HelperService.ErrorMessage(errorMessage);
                    Console.ReadLine();
                    break;
                }
                Console.ReadLine();
                Console.Clear();
                HelperService.ShowTitle("\n   == Reading Stats ==\n");
                HelperService.ApplicationMessage("1.Total Time (hours)\n2.Average Time (minutes)\n3.Total Number of Pages\n4.Favourite Genre\n5.Back to User Statistics");
                int inputChoice = ValidationService.ValidInputChoice(1, 5);
                if (inputChoice == 1) HelperService.ApprovalMessage($"Your total Reading time is {totalTime} hours. Good job.");
                if (inputChoice == 2) HelperService.ApprovalMessage($"Your average Reading time per record is {averageTime} minutes.");
                if (inputChoice == 3) HelperService.ApprovalMessage($"You have read {numberOfPages} pages. Bravo!");
                if (inputChoice == 4) HelperService.ApprovalMessage($"Your favourite Genre is {favouriteGenre}.");
                if (inputChoice == 5) break;
            }
        }

        public void ExercisingStats(User user)
        {
            double totalTime = statsService.GetTotalTime(user.ExercisingList);
            double averageTime = statsService.GetAverageTime(user.ExercisingList);
            string favouriteExercise = statsService.GetFavouriteExercisingType(user.ExercisingList);
            string errorMessage = "You haven't started Exercising yet.";
            while (true)
            {
                if (user.ExercisingList.Count == 0)
                {
                    HelperService.ErrorMessage(errorMessage);
                    Console.ReadLine();
                    break;
                }
                Console.ReadLine();
                Console.Clear();
                HelperService.ShowTitle("\n   == Exercising Stats ==\n");
                HelperService.ApplicationMessage("1.Total Time (hours)\n2.Average Time (minutes)\n3.Favourite Type of Exercise\n4.Back to User Statistics");
                int inputChoice = ValidationService.ValidInputChoice(1, 4);
                if (inputChoice == 1) HelperService.ApprovalMessage($"Your total Exercising time is {totalTime} hours. Good job.");
                if (inputChoice == 2) HelperService.ApprovalMessage($"Your average Exercising time per record is {averageTime} minutes.");
                if (inputChoice == 3) HelperService.ApprovalMessage($"Your favourite Exercise type is {favouriteExercise}.");
                if (inputChoice == 4) break;
            }
        }

        public void WorkingStats(User user)
        {
            double totalTime = statsService.GetTotalTime(user.WorkingList);
            double averageTime = statsService.GetAverageTime(user.WorkingList);
            string homeVsOffice = statsService.GetHomeVsOfficeWorking(user.WorkingList);
            string errorMessage = "You haven't started Working yet.";
            while (true)
            {
                if (user.WorkingList.Count == 0)
                {
                    HelperService.ErrorMessage(errorMessage);
                    Console.ReadLine();
                    break;
                }
                Console.ReadLine();
                Console.Clear();
                HelperService.ShowTitle("\n   == Working Stats ==\n");
                HelperService.ApplicationMessage("1.Total Time (hours)\n2.Average Time (minutes)\n3.Home vs Office Working\n4.Back to User Statistics");
                int inputChoice = ValidationService.ValidInputChoice(1, 4);
                if (inputChoice == 1) HelperService.ApprovalMessage($"Your total Working time is {totalTime} hours. Good job.");
                if (inputChoice == 2) HelperService.ApprovalMessage($"Your average Working time per record is {averageTime} minutes.");
                if (inputChoice == 3) HelperService.ApprovalMessage(homeVsOffice);
                if (inputChoice == 4) break;
            }
        }

        public void HobbiesStats(User user)
        {
            double totalTime = statsService.GetTotalTime(user.HobbysList);
            string errorMessage = "You haven't started a Hobby yet.";
            while (true)
            {
                if (user.HobbysList.Count == 0)
                {
                    HelperService.ErrorMessage(errorMessage);
                    Console.ReadLine();
                    break;
                }
                Console.ReadLine();
                Console.Clear();
                HelperService.ShowTitle("\n   == Hobbies Stats ==\n");
                HelperService.ApplicationMessage("1.Total Time (hours)\n2.Show Hobbies\n3.Back to User Statistics");
                int inputChoice = ValidationService.ValidInputChoice(1, 3);
                if (inputChoice == 1) HelperService.ApprovalMessage($"Your total Hobby time is {totalTime} hours. Good job.");
                if (inputChoice == 2) statsService.ShowHobbies(user.HobbysList);
                if (inputChoice == 3) break;
            }
        }

        public void GlobalStats(User user)
        {
            while (true)
            {
                if (user.ReadingList.Count == 0 && user.HobbysList.Count == 0 && user.ExercisingList.Count == 0 && user.WorkingList.Count == 0)
                {
                    HelperService.ErrorMessage("You haven't started any activity yet.");
                    Console.ReadLine();
                    break;
                }
                Console.ReadLine();
                Console.Clear();
                string totalTime = statsService.GetTotalTimeOfAllActivities(user);
                string favouriteActivities = statsService.GetFavouriteActivity(user);
                HelperService.ShowTitle("\n   == Global Stats ==\n");
                HelperService.ApplicationMessage("1.Total Time of All Activities (hours)\n2.Favourite Activity\n3.Back to User Statistics");
                int inputChoice = ValidationService.ValidInputChoice(1, 3);
                if (inputChoice == 1) HelperService.ApprovalMessage(totalTime);
                if (inputChoice == 2) HelperService.ApprovalMessage(favouriteActivities);
                if (inputChoice == 3) break;
            }
        }

    }
}
