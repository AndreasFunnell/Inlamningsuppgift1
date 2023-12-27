using System.Collections.Generic;

public interface IContactRepository
{
    void AddContact(Contact contact);
    List<Contact> GetContacts();
    Contact GetContactByEmail(string email);
    void RemoveContact(string email);
    void SaveContacts();
}
