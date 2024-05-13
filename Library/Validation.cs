using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Validation
    {
        public static T checkType<T>(T value, Type expectedType)
        {
            try
            {
                if (value.GetType() != expectedType)
                {
                    throw new ArgumentException($"Error: Input Data Type {value.GetType()}, while the expected data type is {expectedType}.");
                }
                return value;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        
    }
}
