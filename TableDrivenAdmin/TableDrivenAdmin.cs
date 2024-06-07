using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDrivenAdmin
{
    public class TableDrivenAdmin
    {
        public enum Username { admin1, admin2 };
        public static string[] Password = { "pass123", "admin123" };

        public static Username getUsername(string user)
        {
            Username username = (Username)System.Enum.Parse(typeof(Username), user);
            return username;

        }

        public static string getPassword(string user)
        {
            Username username = (Username)System.Enum.Parse(typeof(Username), user);
            return Password[(int)username];
        }
    }
}
