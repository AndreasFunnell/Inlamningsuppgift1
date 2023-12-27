// ContactManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ContactManager : IContactRepository
{
    private List<Contact> contacts;

    public ContactManager()
    {
        contacts = new List<Contact>();
        LoadContacts();
    }

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

    public void AddContact()
    {
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

    public void ListContacts()
    {
        Console.WriteLine("Lista över kontakter:\n");

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} - {contact.Email}");
        }

        Console.WriteLine();
    }

    public void ShowContactDetails()
    {
        Console.WriteLine("Ange e-postadress för kontakten du vill visa detaljer för:");
        string email = Console.ReadLine() ?? "";

        Contact selectedContact = GetContactByEmail(email);

        if (selectedContact != null)
        {
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

    public void RemoveContact()
    {
        Console.WriteLine("Ange e-postadress för kontakten du vill ta bort:");
        string email = Console.ReadLine() ?? "";

        Contact contactToRemove = GetContactByEmail(email);

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            Console.WriteLine($"Kontakt {contactToRemove.FirstName} {contactToRemove.LastName} har tagits bort.\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }
    }

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



