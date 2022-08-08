using TimeTracking.Models;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Interfaces;
using TimeTracking.Services.UserService;

namespace TimeTracking.Services.Menu
{
    public class UserMenuService : IUserMenuService
    {
        public void TrackActivity(User user)
        {
            while (true)
            {
                Console.Clear();
                TrackingService trackingService = new();
                HelperService.ShowTitle("\n   === Track Activity ===\n");
                HelperService.ApplicationMessage("1.Reading\n2.Exercising\n3.Working\n4.Other Hobbies\n5.Back to User Menu.");
                int inputChoice = ValidationService.ValidInputChoice(1, 5);
                if (inputChoice == 1) trackingService.TrackReading(user);
                if (inputChoice == 2) trackingService.TrackExercising(user);
                if (inputChoice == 3) trackingService.TrackWorking(user);
                if (inputChoice == 4) trackingService.TrackOtherHobby(user);
                if (inputChoice == 5) break;
            }
        }

        public void UserStatistics(User user)
        {
            while (true)
            {
                Console.Clear();
                StatsMenuService statsMenu = new();
                HelperService.ShowTitle("\n   === User Statistics ===\n");
                HelperService.ApplicationMessage("1.Reading Stats\n2.Exercising Stats\n3.Working Stats\n4.Hobbies Stats\n5.Global Stats\n6.Back to User Menu");
                int inputChoice = ValidationService.ValidInputChoice(1, 6);
                if (inputChoice == 1) statsMenu.ReadingStats(user);
                if (inputChoice == 2) statsMenu.ExercisingStats(user);
                if (inputChoice == 3) statsMenu.WorkingStats(user);
                if (inputChoice == 4) statsMenu.HobbiesStats(user);
                if (inputChoice == 5) statsMenu.GlobalStats(user);
                if (inputChoice == 6) break;
            }
        }

        public void AccountManagment(User user)
        {
            while (true)
            {
                if (!user.IsActive) break;
                Console.Clear();
                AccountService accountService = new();
                HelperService.ShowTitle("\n   === Account Managment ===\n");
                HelperService.ApplicationMessage("1.Change password\n2.Change First Name\n3.Change Last Name\n4.Deactivate account\n5.Back to User Menu");
                int inputChoice = ValidationService.ValidInputChoice(1, 5);
                if (inputChoice == 1) accountService.ChangePassword(user);
                if (inputChoice == 2) accountService.ChangeFirstName(user);
                if (inputChoice == 3) accountService.ChangeLastName(user);
                if (inputChoice == 4) accountService.DeactivateAccount(user);
                if (inputChoice == 5) break;
            }
        }

    }
}
