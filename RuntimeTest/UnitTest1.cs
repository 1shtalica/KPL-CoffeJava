using Newtonsoft.Json;
using hospitalManagenetSystemAPI.Runtime;
using System;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RuntimeTest
{
    public class SystemMessagesTests
    {

        [Fact]
        public void Error_Properties_AreAccessible()
        {
            var data = new StatusConfig().readData();

            var error = data.error;
            // Assert
            Assert.NotNull(data);
            Assert.NotNull(error.overload_patient); 
            Assert.NotNull(error.wrong_password);
            Assert.NotNull(error.wrong_username);
            Assert.NotNull(error.bad_request);
            Assert.NotNull(error.access_denied);
            Assert.NotNull(error.resource_not_found);
        }

        [Fact]
        public void Success_Properties_AreAccessible()
        {
            // Arrange
            var statusConfig = new StatusConfig().readData();

            // Act
            var success = statusConfig.success;

            // Assert
            Assert.NotNull(success);
            Assert.NotNull(success.login_successful); 
            Assert.NotNull(success.logout_successful);
            Assert.NotNull(success.record_created);
            Assert.NotNull(success.record_updated);
            Assert.NotNull(success.record_deleted);
        }

        [Fact]
        public void Setting_Error_Properties_WorksCorrectly()
        {
            // Arrange
            var statusConfig = new StatusConfig();
            var error = new StatusConfig.Error();

            // Act
            error.overload_patient = "Overload patient error";
            error.wrong_password = "Wrong password error";
            statusConfig.error = error;

            // Assert
            Assert.Equal("Overload patient error", statusConfig.error.overload_patient);
            Assert.Equal("Wrong password error", statusConfig.error.wrong_password);
        }

        [Fact]
        public void Setting_Success_Properties_WorksCorrectly()
        {
            // Arrange
            var statusConfig = new StatusConfig();
            var success = new StatusConfig.Success();

            // Act
            success.login_successful = "Login successful message";
            success.record_created = "Record created message";
            statusConfig.success = success;

            // Assert
            Assert.Equal("Login successful message", statusConfig.success.login_successful);
            Assert.Equal("Record created message", statusConfig.success.record_created);
        }

    }
}
