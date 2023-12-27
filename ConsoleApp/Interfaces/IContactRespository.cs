// IContactRepository.cs
using System.Collections.Generic;

// Ett gränssnitt som definierar operationer för att hantera kontakter.
public interface IContactRepository
{
    // Lägger till en ny kontakt.
    void AddContact(Contact contact);

    // Hämtar en lista med alla kontakter.
    List<Contact> GetContacts();

    // Hämtar en kontakt baserat på e-postadress.
    Contact GetContactByEmail(string email);

    // Tar bort en kontakt baserat på e-postadress.
    void RemoveContact(string email);

    // Sparar kontakter till en extern lagringsplats (till exempel en fil eller databas).
    void SaveContacts();
}

