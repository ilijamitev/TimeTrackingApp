using TimeTracking.Data;
using TimeTracking.Models;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Interfaces;
using TimeTracking.Services.Logger;
using TimeTracking.Services.LoginRegister;

namespace TimeTracking.Services.Menu
{
    public class MenuService : IMenus
    {
        LoggerService initLogger = new();
        DatabaseService databaseService = new();

        public void StartApp()
        {
            try
            {
                StartMenu();
            }
            catch (Exception ex)
            {
                LoggerService.ErrorLog(ex.Message, ex.Source);
            }
        }

        public void StartMenu()
        {
            databaseService.GetFromDatabase();
            while (true)
            {
                Console.Clear();
                HelperService.ApplicationMessage("\n    ***Welcome to TimeTrackingApp***\n\n1.Login\n2.Register\n3.Exit");
                int inputChoice = ValidationService.ValidInputChoice(1, 3);
                if (inputChoice == 1) LoginMenu();
                if (inputChoice == 2) RegisterMenu();
                if (inputChoice == 3) ExitApp();
            }
        }

        public void RegisterMenu()
        {
            Console.Clear();
            HelperService.ApplicationMessage("\n   ***REGISTER MENU***\n\n");
            RegisterService registerService = new();
            User newUser = registerService.CreateNewUser();
            ModelsDatabase.UsersList.Add(newUser);
            HelperService.ApprovalMessage($@"Successfully created new User ""{newUser.FullName}"" with ID ""{newUser.Id}"" and Username ""{newUser.Username}"".");
            Console.ReadLine();
        }

        public void LoginMenu()
        {
            bool isTrue = true;
            while (true)
            {
                if (ModelsDatabase.UsersList.Count == 0)
                {
                    HelperService.ErrorMessage("NO USERS AVAILABLE!");
                    Console.ReadLine();
                    break;
                }
                Console.Clear();
                HelperService.ApplicationMessage("\n   ***LOGIN MENU***");
                LoginService loginService = new();
                string username = loginService.EnterUsername();
                if (!loginService.CheckActiveStatus(username))
                {
                    while (true)
                    {
                        Console.Clear();
                        HelperService.ErrorMessage("\n    YOUR ACCOUNT IS CURRENTLY DEACTIVATED !!!\n\n");
                        Thread.Sleep(2000);
                        HelperService.ApplicationMessage("1.Activate your account\n2.Back to Start Menu.");
                        int inputChoice = ValidationService.ValidInputChoice(1, 2);
                        if (inputChoice == 1)
                        {
                            HelperService.ApprovalMessage("Your account has been reactivated. You can now continue Loging in.");
                            Console.ReadLine();
                            break;
                        }
                        isTrue = !isTrue;
                        break;
                    }
                }
                while (isTrue)
                {
                    User logedUser = loginService.EnterPassword(username);
                    HelperService.ApprovalMessage($"\n\n    Welcome User {logedUser.FullName}.");
                    logedUser.IsActive = true;
                    LoggerService.LoginLog(logedUser);
                    Console.ReadLine();
                    UserMenu(logedUser);
                    #region justToCheck
                    //Console.WriteLine("JUST TO CHECK :)");
                    //Console.WriteLine("READING");
                    //logedUser.ReadingList.ForEach(x => Console.WriteLine($"ID: {x.Id}. Pages: {x.NumberOfPages}. Genre: {x.BookGenre}. Time: {x.TimeSpentOnActivity * 60} min."));
                    //Console.WriteLine("EXERCISE");
                    //logedUser.ExercisingList.ForEach(x => Console.WriteLine($"ID: {x.Id}. Type: {x.ExercisingType}. Time: {x.TimeSpentOnActivity * 60} min."));
                    //Console.WriteLine("WORKING");
                    //logedUser.WorkingList.ForEach(x => Console.WriteLine($"ID: {x.Id}. Name: {x.GetType().Name}. Time: {x.TimeSpentOnActivity * 60} min."));
                    //Console.WriteLine("HOBBIES");
                    //logedUser.HobbysList.ForEach(x => Console.WriteLine($"ID: {x.Id}. Name: {x.HobbyName}. Time: {x.TimeSpentOnActivity * 60} min."));
                    #endregion
                    Console.ReadLine();
                    break;
                }
                break;
            }
        }

        public void UserMenu(User user)
        {
            while (true)
            {
                if (!user.IsActive) break;
                Console.Clear();
                HelperService.ShowTitle("\n   ***USER MENU***\n\n");
                HelperService.ApplicationMessage("1.Track Activity\n2.User Statistics\n3.Account Managment\n4.Logout");
                int inputChoice = ValidationService.ValidInputChoice(1, 4);
                UserMenuService userMenu = new();
                if (inputChoice == 1) userMenu.TrackActivity(user);
                if (inputChoice == 2) userMenu.UserStatistics(user);
                if (inputChoice == 3) userMenu.AccountManagment(user);
                if (inputChoice == 4) break;
            }
            Console.ReadLine();
        }

        public void ExitApp()
        {
            Console.Clear();
            HelperService.ApplicationMessage("\n\n\n\n\n\n             *** THANK YOU FOR USING OUR APP ***");
            if (ModelsDatabase.UsersList is not null)
            {
                databaseService.SaveToDatabase();
            }
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
