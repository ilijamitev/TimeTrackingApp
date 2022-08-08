using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Services
{
    public static class HelperService
    {
        public static Action<string> ApplicationMessage = text =>
       {
           Console.ForegroundColor = ConsoleColor.DarkCyan;
           Console.WriteLine(text);
           Console.ResetColor();
       };

        public static Action<string> ShowTitle = text =>
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        };

        public static Action<string> ShowTime = text =>
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ResetColor();
        };

        public static Action<string> ApprovalMessage = text =>
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        };

        public static Action<string> ErrorMessage = text =>
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        };

        public static Action<string> ThrowException = text => throw new Exception(text);
    }
}
