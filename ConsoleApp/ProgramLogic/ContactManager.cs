// ContactManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ContactManager : IContactRepository
{
    private List<Contact> contacts;

    // Konstruktor för ContactManager, initierar listan med kontakter och laddar befintliga kontakter från filen.
    public ContactManager()
    {
        contacts = new List<Contact>();
        LoadContacts();
    }

    // Huvudmetod för att köra kontaktprogrammet.
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Välkommen till kontakthanteraren!");
            Console.WriteLine("1. Lägg till kontakt");
            Console.WriteLine("2. Lista alla kontakter");
            Console.WriteLine("3. Visa detaljerad information om en kontakt");
            Console.WriteLine("4. Ta bort kontakt");
            Console.WriteLine("5. Avsluta");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ListContacts();
                    break;
                case "3":
                    ShowContactDetails();
                    break;
                case "4":
                    RemoveContact();
                    break;
                case "5":
                    SaveContacts();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    // Metod för att lägga till en ny kontakt.
    public void AddContact()
    {
        // Användarinteraktion för att ange kontaktinformation.
        Console.WriteLine("Ange förnamn:");
        string firstName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange efternamn:");
        string lastName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange telefonnummer:");
        string phoneNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Ange e-postadress:");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Ange adressinformation:");
        string address = Console.ReadLine() ?? "";

        // Skapa en ny kontakt med angiven information och lägg till i listan.
        Contact newContact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email,
            Address = address
        };

        contacts.Add(newContact);

        Console.WriteLine("Kontakt tillagd!\n");
    }

    // Metod för att lista alla kontakter.
    public void ListContacts()
    {
        Console.WriteLine("Lista över kontakter:\n");

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} - {contact.Email}");
        }

        Console.WriteLine();
    }

    // Metod för att visa detaljerad information om en specifik kontakt.
    public void ShowContactDetails()
    {
        Console.WriteLine("Ange e-postadress för kontakten du vill visa detaljer för:");
        string email = Console.ReadLine() ?? "";

        // Hämta kontakten med angiven e-postadress.
        Contact selectedContact = GetContactByEmail(email);

        if (selectedContact != null)
        {
            // Visa detaljer om kontakten.
            Console.WriteLine($"Detaljer för kontakt {selectedContact.FirstName} {selectedContact.LastName}:\n");
            Console.WriteLine($"Förnamn: {selectedContact.FirstName}");
            Console.WriteLine($"Efternamn: {selectedContact.LastName}");
            Console.WriteLine($"Telefonnummer: {selectedContact.PhoneNumber}");
            Console.WriteLine($"E-postadress: {selectedContact.Email}");
            Console.WriteLine($"Adressinformation: {selectedContact.Address}\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }
    }

    // Metod för att ta bort en kontakt baserat på e-postadress.
    public void RemoveContact()
    {
        Console.WriteLine("Ange e-postadress för kontakten du vill ta bort:");
        string email = Console.ReadLine() ?? "";

        // Hämta kontakten med angiven e-postadress.
        Contact contactToRemove = GetContactByEmail(email);

        if (contactToRemove != null)
        {
            // Ta bort kontakten från listan.
            contacts.Remove(contactToRemove);
            Console.WriteLine($"Kontakt {contactToRemove.FirstName} {contactToRemove.LastName} har tagits bort.\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }
    }

    // Metod för att ladda kontakter från filen.
    public void LoadContacts()
    {
        if (File.Exists("contacts.json"))
        {
            string json = File.ReadAllText("contacts.json");
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
        }
        else
        {
            contacts = new List<Contact>();
        }
    }

    // Metod för att spara kontakter till filen.
    public void SaveContacts()
    {
        string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        File.WriteAllText("contacts.json", json);
    }

    // Implementera alla metoder från IContactRepository
    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public List<Contact> GetContacts()
    {
        return contacts ?? new List<Contact>();
    }

    public Contact GetContactByEmail(string email)
    {
        return contacts?.Find(c => c.Email == email) ?? null;
    }

    public void RemoveContact(string email)
    {
        Contact contactToRemove = contacts?.Find(c => c.Email == email) ?? new Contact();
        if (contactToRemove != null)
        {
            contacts?.Remove(contactToRemove);
        }
    }
}




