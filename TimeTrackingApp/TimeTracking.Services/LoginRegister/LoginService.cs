using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data;
using TimeTracking.Models;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Menu;

namespace TimeTracking.Services.LoginRegister
{
    public class LoginService
    {
        public string EnterUsername()
        {
            string inputUsername = string.Empty;
            int triesCounter = 0;
            while (true)
            {
                try
                {
                    if (triesCounter == 3)
                    {
                        InvalidCredentials();
                    }
                    Console.WriteLine("\nEnter Username:");
                    inputUsername = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputUsername))
                    {
                        triesCounter++;
                        HelperService.ThrowException("ENTER VALUE!");
                    }
                    if (!CheckUsername(inputUsername))
                    {
                        triesCounter++;
                        HelperService.ThrowException("NO USER FOUND!");
                    }
                    return inputUsername;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public User EnterPassword(string username)
        {
            string inputPassword = string.Empty;
            int triesCounter = 0;
            while (true)
            {
                try
                {
                    if (triesCounter == 3)
                    {
                        InvalidCredentials();
                    }
                    Console.WriteLine("Enter Password:");
                    inputPassword = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputPassword))
                    {
                        triesCounter++;
                        HelperService.ThrowException("ENTER VALUE!");
                    }
                    if (!CheckPassword(inputPassword))
                    {
                        triesCounter++;
                        HelperService.ThrowException("INCORRECT PASSWORD!");
                    }
                    return ModelsDatabase.UsersList.First(x => x.Password == inputPassword && x.Username == username);
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        internal Func<string, bool> CheckUsername = username => ModelsDatabase.UsersList.Any(x => x.Username == username);
        internal Func<string, bool> CheckActiveStatus = username => ModelsDatabase.UsersList.Any(x => x.Username == username && x.IsActive);
        internal Func<string, bool> CheckPassword = password => ModelsDatabase.UsersList.Any(x => x.Password == password);

        public void InvalidCredentials()
        {
            HelperService.ErrorMessage("\n\n\n      SORRY YOU'VE MISSED 3 TIMES. BYE BYE!");
            Console.ReadLine();
            MenuService exitApp = new();
            exitApp.ExitApp();
        }

    }
}
