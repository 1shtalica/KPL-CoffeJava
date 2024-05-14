using hospitalManagenetSystemAPI.Runtime;
using static hospitalManagenetSystemAPI.Runtime.DashboardConfigParse;
namespace RuntimeDashboardTest
{
    public class UnitTest1
    {
        [Fact]
        public void EnglishLanguage()
        {
            var data = new DashboardConfigParse().readData();

            var en = data.en;
            // Assert for en
            Assert.NotNull(data);
            Assert.NotNull(en.dashboard);
            Assert.NotNull(en.patients);
            Assert.NotNull(en.appointments);
            Assert.NotNull(en.medicalRecords);
            Assert.NotNull(en.settings);
            Assert.NotNull(en.logout);

        }

        [Fact]
        public void IndonesiaLanguage()
        {
            // Arrange
            var data = new DashboardConfigParse().readData();

            // Act
            var id = data.id;

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(id.dashboard);
            Assert.NotNull(id.patients);
            Assert.NotNull(id.appointments);
            Assert.NotNull(id.medicalRecords);
            Assert.NotNull(id.settings);
            Assert.NotNull(id.logout);

        }
    }
}