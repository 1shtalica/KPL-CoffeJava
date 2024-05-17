using System;

namespace Frontend.TableDriven
{
    internal class TableDrivenNeurology
    {
        public enum Username { neuro1, neuro2 };
        public static string[] Passwords = { "neuro123", "doctor123" };

        
        public static Username GetUsername(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentException("Username cannot be blank or whitespace.", nameof(user));
            }

            if (!Enum.TryParse<Username>(user, out var username))
            {
                throw new ArgumentException("Invalid username.", nameof(user));
            }
            return username;
        }


        public static string GetPassword(string user)
        {
            var username = GetUsername(user);

            try
            {
                var password = Passwords[(int)username];
                if (password != null)
                {
                    return password;
                }
                else
                {
                    throw new InvalidOperationException("Password cannot be null.");
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Password index out of range.");
            }

        }
    }
}
