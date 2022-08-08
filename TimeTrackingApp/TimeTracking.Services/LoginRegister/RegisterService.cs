using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data;
using TimeTracking.Models;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services.LoginRegister
{
    public class RegisterService : IRegisterService
    {
        public User CreateNewUser()
        {
            string firstName = GetName("first");
            string lastName = GetName("last");
            int age = GetAge();
            string username = GetUsername();
            string password = GetPassword();
            return new User(firstName, lastName, age, username, password);
        }

        public string GetName(string firstOrLast = "first")
        {
            string name = string.Empty;
            while (true)
            {
                try
                {
                    if (firstOrLast == "first") Console.WriteLine("Enter First Name:");
                    if (firstOrLast == "last") Console.WriteLine("Enter Last Name:");
                    name = Console.ReadLine();
                    // da probam ova vo nova metoda (bool) i dali ke go fati errorot tuka
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        HelperService.ThrowException("ENTER A VALUE!");
                    }
                    if (name.ToCharArray().Any(x => char.IsDigit(x)))
                    {
                        HelperService.ThrowException("SHOULDN'T HAVE NUMBERS IN NAME!");
                    }
                    if (!name.ToCharArray().All(x => char.IsLetter(x)))
                    {
                        HelperService.ThrowException("SHOULDN'T HAVE SYMBOLS IN NAME!");
                    }
                    if (name.Length < 2)
                    {
                        HelperService.ThrowException("MUST CONTAIN AT LEAST 2 LETTERS!");
                    }
                    // DO TUKA ...
                    return name;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public int GetAge()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Age:");
                    string inputAge = Console.ReadLine();
                    bool isNumber = int.TryParse(inputAge, out int age);
                    if (string.IsNullOrWhiteSpace(inputAge))
                    {
                        HelperService.ThrowException("ENTER A VALUE!");
                    }
                    if (!isNumber)
                    {
                        HelperService.ThrowException("PLEASE ENTER VALID NUMBER!");
                    }
                    if (age < 18 || age > 120)
                    {
                        HelperService.ThrowException("AGE LIMIT IS FROM 18 TO 120 YEARS!");
                    }
                    return age;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public string GetUsername()
        {
            string username = string.Empty;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter new Username:");
                    username = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        HelperService.ThrowException("ENTER A VALUE!");
                    }
                    else if (CheckIfUsernameExists(username))
                    {
                        HelperService.ThrowException("USERNAME ALREADY TAKEN!");
                    }
                    else if (username.Length < 5)
                    {
                        HelperService.ThrowException("USERNAME MUST HAVE MIN 5 CHARACTERS!");
                    }
                    return username;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hi from registerService");
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public bool CheckIfUsernameExists(string username)
        {
            return ModelsDatabase.UsersList.Any(x => x.Username == username);
        }

        public string GetPassword()
        {
            string password = string.Empty;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter new Password:");
                    password = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        HelperService.ThrowException("ENTER A VALUE!");
                    }
                    if (password.Length < 6)
                    {
                        HelperService.ThrowException("PASSWORD MUST HAVE MIN 6 CHARACTERS!");
                    }
                    if (!password.ToCharArray().Any(x => char.IsDigit(x)))
                    {
                        HelperService.ThrowException("MUST CONTAIN NUMBER!");
                    }
                    if (!password.ToCharArray().Any(x => char.IsUpper(x)))
                    {
                        HelperService.ThrowException("MUST CONTAIN UPPERCASED LETTER!");
                    }
                    return password;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

    }
}
