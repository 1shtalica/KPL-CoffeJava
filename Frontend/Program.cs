using hospitalManagenetSystemAPI.TableDriven;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var username1 = TableDrivenAdmin.getUsername("admin1");
                var password1 = TableDrivenAdmin.getPassword("admin1");
                Debug.Assert(username1.ToString() == "admin1", "Username is not admin1");
                Debug.Assert(password1 == "pass123", "Password is not pass123");
                Console.WriteLine($"Username: {username1}, Password: {password1}");

                var username2 = TableDrivenAdmin.getUsername("admin2");
                var password2 = TableDrivenAdmin.getPassword("admin2");
                Debug.Assert(username2.ToString() == "admin2", "Username is not admin2");
                Debug.Assert(password2 == "admin123", "Password is not admin123");
                Console.WriteLine($"Username: {username2}, Password: {password2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
