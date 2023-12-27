using Xunit;

namespace ContactTests
{
    public class ContactTests
    {
        [Fact]
        public void ContactProperties_ShouldBeSetCorrectly()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "Andreas",
                LastName = "Funnell",
                PhoneNumber = "123456789",
                Email = "andreas.funnell@example.com",
                Address = "703 orebro"
            };

            // Assert
            Assert.Equal("Andreas", contact.FirstName);
            Assert.Equal("Funnell", contact.LastName);
            Assert.Equal("123456789", contact.PhoneNumber);
            Assert.Equal("andreas.funnell@example.com", contact.Email);
            Assert.Equal("703 orebro", contact.Address);
        }
    }
}



