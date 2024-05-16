using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using hospitalManagenetSystemAPI.Data;
using Library;
using hospitalManagenetSystemAPI.Models;

namespace ValidationTest
{
    public class UnitTest1
    {
        //cek klo tipe data benar
        [Fact]
        public void CheckTypeTrue()
        {
            int value = 5;
            Type expectedType = typeof(int);

            var result = Validation.checkType(value, expectedType);

            Assert.Equal(value, result);
        }

        //cek klo tipe data g sesuai
        [Fact]
        public void CheckTypeFalse()
        {
            int value = 5;
            Type expectedType = typeof(string);

            var result = Validation.checkType(value, expectedType);

            Assert.Equal(default(int), result);
        }

        // cek klo sudah mendaftar/limit
        [Fact]
        public void ReachMaxTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            using (var context = new AppDbContext(options))
            {
                context.patients.Add(new Patient
                {
                    PatientId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "password",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St",
                    Salt = "salt",
                    medicalCheckUps = new List<MedicalCheckUp>()
                });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                // Act
                bool result = Validation.reachMax(1, context);

                // Assert
                Assert.False(result);
            }
        }

        //cek klo blm mendaftar
        [Fact]
        public void ReachMaxFalse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            using (var context = new AppDbContext(options))
            {
                // Act
                bool result = Validation.reachMax(2, context);

                // Assert
                Assert.True(result);
            }
        }
    }
}
