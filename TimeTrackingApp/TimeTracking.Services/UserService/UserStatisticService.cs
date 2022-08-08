using TimeTracking.Models;

namespace TimeTracking.Services.UserService
{
    public class UserStatisticService : IUserStatsService
    {
        public double GetTotalTime<T>(List<T> activities) where T : IActivity
        {
            double result = activities.Select(x => x.TimeSpentOnActivity).ToList().Sum();
            return Math.Round(result, 5, MidpointRounding.ToEven);
        }

        public double GetAverageTime<T>(List<T> activities) where T : IActivity
        {
            if (GetTotalTime(activities) == 0) return 0;
            double result = GetTotalTime(activities) / activities.Count * 60;
            return Math.Round(result, 5, MidpointRounding.ToEven);
        }

        public int GetNumberOfPages(List<Reading> readingList)
        {
            return readingList.Select(x => x.NumberOfPages).ToList().Sum();
        }

        public string GetFavouriteBookGenre(List<Reading> readings)
        {
            if (readings.Count == 0) return null;
            List<BookGenre> bookGenre = readings.Select(x => x.BookGenre).ToList();
            int romance = bookGenre.Where(x => x == BookGenre.Romance).ToList().Count;
            int comedy = bookGenre.Where(x => x == BookGenre.Comedy).ToList().Count;
            int professional = bookGenre.Where(x => x == BookGenre.Professional).ToList().Count;
            List<int> bookTypesCount = new() { professional, romance, comedy };
            int result = bookTypesCount.Max();
            if (result == romance && result == comedy && result == professional)
            {
                return "Romance, Comedy and Professional";
            }
            if (result == romance && result == comedy)
            {
                return "Romance and Comedy";
            }
            if (result == romance && result == professional)
            {
                return "Romance and Professional";
            }
            if (result == comedy && result == professional)
            {
                return "Comedy and Professional";
            }
            if (result == romance) return "Romance";
            if (result == comedy) return "Comedy";
            if (result == professional) return "Professional";
            return null;
        }

        public string GetFavouriteExercisingType(List<Exercising> exerciseList)
        {
            if (exerciseList.Count == 0) return null;
            List<ExercisingType> exerciseType = exerciseList.Select(x => x.ExercisingType).ToList();
            int general = exerciseType.Where(x => x == ExercisingType.General).ToList().Count();
            int running = exerciseType.Where(x => x == ExercisingType.Running).ToList().Count();
            int sports = exerciseType.Where(x => x == ExercisingType.Sports).ToList().Count();
            List<int> exercisingTypeCount = new() { general, running, sports };
            int result = exercisingTypeCount.Max();
            if (result == general && result == running && result == sports)
            {
                return "General, Running and Sports";
            }
            if (result == general && result == running)
            {
                return "General and Running";
            }
            if (result == general && result == sports)
            {
                return "General and Sports";
            }
            if (result == running && result == sports)
            {
                return "Running and Sports";
            }
            if (result == general) return "General";
            if (result == running) return "Running";
            if (result == sports) return "Sports";
            return null;
        }

        public string GetHomeVsOfficeWorking(List<Working> workingList)
        {
            var home = workingList.Where(x => x.WorkingPlace == WorkingPlace.AtHome).ToList();
            var office = workingList.Where(x => x.WorkingPlace == WorkingPlace.AtOffice).ToList();
            double homeHours = home.Select(x => x.TimeSpentOnActivity).ToArray().Sum();
            double officeHours = office.Select(x => x.TimeSpentOnActivity).ToArray().Sum();
            homeHours = Math.Round(homeHours, 5, MidpointRounding.ToEven);
            officeHours = Math.Round(officeHours, 5, MidpointRounding.ToEven);
            return $"Working at Home: {homeHours} hours.\nWorking at Office: {officeHours} hours.";
        }

        public void ShowHobbies(List<Hobby> hobbiesList)
        {
            int counter = 0;
            var hobbies = hobbiesList.DistinctBy(x => x.HobbyName.ToLower()).ToList();
            HelperService.ApplicationMessage("===> Hobbies List:");
            hobbies.ForEach(x => HelperService.ApprovalMessage($"{++counter}. {x.HobbyName.ToUpper()}"));
        }

        public string GetTotalTimeOfAllActivities(User user)
        {
            double readingTotal = GetTotalTime(user.ReadingList);
            double exerciseTotal = GetTotalTime(user.ExercisingList);
            double workingTotal = GetTotalTime(user.WorkingList);
            double hobbiesTotal = GetTotalTime(user.HobbysList);
            double globalTotal = readingTotal + exerciseTotal + workingTotal + hobbiesTotal;
            globalTotal = Math.Round(globalTotal, 5, MidpointRounding.ToEven);
            return $"Your total time spent on Activities is {globalTotal} hours.";
        }

        public string GetFavouriteActivity(User user)
        {
            string greatestTimeActivity = GetActivityWithGreatestTime(user).ToUpper();
            string mostRepeatedActivity = GetMostRepeatedActivity(user).ToUpper();
            return $"Your Activity with greatest total time is {greatestTimeActivity}.\n" +
                   $"Your most repeated Activity is {mostRepeatedActivity}.";
        }

        public string GetMostRepeatedActivity(User user)
        {
            string mostRepeated = string.Empty;
            int readingTotal = user.ReadingList.Count;
            int exerciseTotal = user.ExercisingList.Count;
            int workingTotal = user.WorkingList.Count;
            int hobbiesTotal = user.HobbysList.Count;
            List<int> favouriteActivitiesByTime = new() { readingTotal, exerciseTotal, workingTotal, hobbiesTotal };
            double favourite = favouriteActivitiesByTime.Max();
            mostRepeated = favourite == readingTotal ? "Reading" : favourite == exerciseTotal ? "Exercising" : favourite == workingTotal ? "Working" : "doing Hobbies";
            return mostRepeated;
        }

        public string GetActivityWithGreatestTime(User user)
        {
            string totalTime = string.Empty;
            double readingTotal = GetTotalTime(user.ReadingList);
            double exerciseTotal = GetTotalTime(user.ExercisingList);
            double workingTotal = GetTotalTime(user.WorkingList);
            double hobbiesTotal = GetTotalTime(user.HobbysList);
            List<double> favouriteActivitiesByTime = new() { readingTotal, exerciseTotal, workingTotal, hobbiesTotal };
            double favourite = favouriteActivitiesByTime.Max();
            totalTime = favourite == readingTotal ? "Reading" : favourite == exerciseTotal ? "Exercising" : favourite == workingTotal ? "Working" : "doing Hobbies";
            return totalTime;
        }
    }
}
