public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    // Konstruktor för att säkerställa att icke-nullable egenskaper har ett värde.
    public Contact()
    {
        FirstName = "";
        LastName = "";
        PhoneNumber = "";
        Email = "";
        Address = "";
    }
}

