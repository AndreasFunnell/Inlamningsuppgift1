using Xunit;

public class ContactManagerTests
{
    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        // Arrange
        var contactManager = new ContactManager();
        var contact = new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

        // Act
        contactManager.AddContact(contact);

        // Assert
        Assert.Contains(contact, contactManager.GetContacts());
    }

    [Fact]
    public void RemoveContact_ShouldRemoveContactFromList()
    {
        // Arrange
        var contactManager = new ContactManager();
        var contact = new Contact { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" };
        contactManager.AddContact(contact);

        // Act
        contactManager.RemoveContact(contact.Email);

        // Assert
        Assert.DoesNotContain(contact, contactManager.GetContacts());
    }

}


