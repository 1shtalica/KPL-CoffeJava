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

        [Fact]
        public void Set_en_property()
        {
            // Arrange
            var enConfig = new DashboardConfigParse();
            var engglish = new DashboardConfigParse.En();

            // Act
            engglish.dashboard = "Welcome to Hospital Dashboard";
            engglish.patients = "Patient Menu";
            engglish.appointments = "Appointment Schedule";
            engglish.medicalRecords = "Disease Record";
            engglish.settings = "Application Setting";
            engglish.logout = "Logout Account";
            enConfig.en = engglish;

            // Assert
            Assert.Equal("Welcome to Hospital Dashboard", enConfig.en.dashboard);
            Assert.Equal("Patient Menu", enConfig.en.patients);
            Assert.Equal("Appointment Schedule", enConfig.en.appointments);
            Assert.Equal("Disease Record", enConfig.en.medicalRecords);
            Assert.Equal("Application Setting", enConfig.en.settings);
            Assert.Equal("Logout Account", enConfig.en.logout);
        }

        [Fact]
        public void Set_id_property()
        {
            // Arrange
            var idConfig = new DashboardConfigParse();
            var indo = new DashboardConfigParse.Id();

            // Act
            indo.dashboard = "Selamat Datang di Dasbor Rumah Sakit";
            indo.patients = "Menu Pasien";
            indo.appointments = "Jadwal Temu";
            indo.medicalRecords = "Catatan Penyakit";
            indo.settings = "Pengaturan Aplikasi";
            indo.logout = "Keluar Akun";
            idConfig.id = indo;

            // Assert
            Assert.Equal("Selamat Datang di Dasbor Rumah Sakit", idConfig.id.dashboard);
            Assert.Equal("Menu Pasien", idConfig.id.patients);
            Assert.Equal("Jadwal Temu", idConfig.id.appointments);
            Assert.Equal("Catatan Penyakit", idConfig.id.medicalRecords);
            Assert.Equal("Pengaturan Aplikasi", idConfig.id.settings);
            Assert.Equal("Keluar Akun", idConfig.id.logout);
        }
    }
}