using hospitalManagenetSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
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

        //mengecek 1 pasien 1 mcu
        public static bool reachMax(int idPatient, AppDbContext context)
        {
            var patient = context.patients.Include(p => p.medicalCheckUps).FirstOrDefault(p => p.PatientId == idPatient);

            if (patient == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
