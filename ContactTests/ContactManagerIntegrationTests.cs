using Xunit;

namespace ContactTests
{
    public class ContactManagerIntegrationTests
    {
        [Fact]
        public void AddContact_ShouldPersistContact()
        {
            // Arrange
            var contactManager = new ContactManager();
            var contact = new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

            // Act
            contactManager.AddContact(contact);

            // Assert
            var retrievedContact = contactManager.GetContactByEmail("john.doe@example.com");
            Assert.NotNull(retrievedContact);
            Assert.Equal("John", retrievedContact.FirstName);
            Assert.Equal("Doe", retrievedContact.LastName);
        }

        [Fact]
        public void RemoveContact_ShouldRemovePersistedContact()
        {
            // Arrange
            var contactManager = new ContactManager();
            var contact = new Contact { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" };
            contactManager.AddContact(contact);

            // Act
            contactManager.RemoveContact("jane.doe@example.com");

            // Assert
            var retrievedContact = contactManager.GetContactByEmail("jane.doe@example.com");

            // Lägg till utskrift för att se vad retrievedContact är
            Console.WriteLine($"Retrieved Contact: {retrievedContact}");

            // Kontrollera att kontakten inte längre finns
            Assert.Null(retrievedContact);

            // Kontrollera att listan är tom
            Assert.Empty(contactManager.GetContacts());
        }

    }
}
