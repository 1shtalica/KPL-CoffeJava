using System;

namespace hospitalManagenetSystemAPI.TableDriven
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
            if (Enum.IsDefined(typeof(Username), user))
            {
                Username username = (Username)Enum.Parse(typeof(Username), user);
                if ((int)username < Password.Length)
                {
                    return Password[(int)username];
                }
                else
                {
                    throw new IndexOutOfRangeException("Password index out of range.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid username.");
            }

            /* Username username = (Username)System.Enum.Parse(typeof(Username), user);
             return Password[(int)username];
            */
        }
    }
}
