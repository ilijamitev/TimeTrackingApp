using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;
using TimeTracking.Services.LoginRegister;
using TimeTracking.Services.Menu;

namespace TimeTracking.Services.UserService
{
    public class AccountService : IAccountManagment
    {
        RegisterService registerService = new();
        public void ChangePassword(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n     == Change Password ==\n");
            while (true)
            {
                try
                {
                    HelperService.ApplicationMessage("Enter old password:");
                    string oldPassword = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(oldPassword)) HelperService.ThrowException("ENTER VALUE!");
                    if (oldPassword != user.Password) HelperService.ThrowException("WRONG PASSWORD!");
                    string newPassword = registerService.GetPassword();
                    if (newPassword == oldPassword) HelperService.ThrowException("TRY CREATING DIFFERENT PASSWORD!");
                    user.Password = newPassword;
                    HelperService.ApprovalMessage("Successfully changed password.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public void ChangeFirstName(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n     == Change First Name ==\n");
            while (true)
            {
                try
                {
                    string newFirstName = registerService.GetName("first");
                    if (newFirstName.ToLower() == user.FirstName.ToLower())
                    {
                        HelperService.ThrowException("YOU'VE ENTERED THE SAME FIRST NAME!");
                    }
                    HelperService.ApprovalMessage($"Successfully changed First Name from {user.FirstName} to {newFirstName}.");
                    user.FirstName = newFirstName;
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public void ChangeLastName(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n     == Change Last Name ==\n");
            while (true)
            {
                try
                {
                    string newLastName = registerService.GetName("last");
                    if (newLastName.ToLower() == user.LastName.ToLower())
                    {
                        HelperService.ThrowException("YOU'VE ENTERED THE SAME LAST NAME!");
                    }
                    HelperService.ApprovalMessage($"Successfully changed Last Name from {user.LastName} to {newLastName}.");
                    user.LastName = newLastName;
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

        public void DeactivateAccount(User user)
        {
            Console.Clear();
            HelperService.ShowTitle("\n     == Deactivate Account ==\n");
            HelperService.ErrorMessage($"ARE YOU SURE YOU WANT TO DEACTIVATE YOUR ACCOUNT ?\n");
            Console.WriteLine($"*Please enter: \"{user.Id} {user.FullName}\" for confirmation*\nEnter \"exit\" to quit.");
            while (true)
            {
                try
                {
                    string deactivateAccount = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(deactivateAccount))
                    {
                        HelperService.ThrowException("ENTER VALUE");
                    }
                    if (deactivateAccount == "exit") break;
                    if (deactivateAccount != $"{user.Id} {user.FullName}")
                    {
                        HelperService.ThrowException("ENTER THE EXACT TEXT!");
                    }
                    user.IsActive = false;
                    HelperService.ApprovalMessage($"Your account has been Deactivated.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    HelperService.ErrorMessage(ex.Message);
                }
            }
        }

    }
}
