using Library;
using Xunit;

namespace unitTest
 
{
    public class TestPasswordLibrary
    {
        [Fact]
        public void TestComparePasswordReturnTrue()
        {
            Assert.True(true == Library.Password.ComparePassword("Albany12#", "STKKRfJdBG6jsvQj+mn6ETO62fY=", "gZVI0Hje/gofzZbf/1vB4w=="));
        }

        [Fact]
        public void TestComparePasswordWrongPassworReturnFalse()
        {
            Assert.True(false == Library.Password.ComparePassword("Albawqeqweqwe", "STKKRfJdBG6jsvQj+mn6ETO62fY=", "gZVI0Hje/gofzZbf/1vB4w=="));
        }

        [Fact]
        public void TestComparePasswordWrongHashPaswordReturnFalse()
        {
            Assert.True(false == Library.Password.ComparePassword("Albany12#", "STKKRfJdBG6jsvQj+masdasdn6ETO62fY=", "gZVI0Hje/gofzZbf/1vB4w=="));
        }
    }
}