using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Address instances
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Vancouver", "BC", "Canada");
        Address address3 = new Address("789 Oak St", "Los Angeles", "CA", "USA");

        // Create Event instances
        Event lecture = new Lecture("Tech Innovations", "A lecture on the latest in tech innovations.", new DateTime(2023, 7, 20), "10:00 AM", address1, "Dr. Smith", 100);
        Event reception = new Reception("Company Annual Meet", "Annual meet for all employees.", new DateTime(2023, 8, 15), "6:00 PM", address2, "rsvp@company.com");
        Event outdoorGathering = new OutdoorGathering("Community Picnic", "An outdoor picnic for the community.", new DateTime(2023, 9, 10), "12:00 PM", address3, "Sunny with a chance of rain");

        // Create a list of events
        Event[] events = { lecture, reception, outdoorGathering };

        // Iterate through the list of events and display marketing messages
        foreach (var evt in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("Full Details:");
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("Short Description:");
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine();
        }
    }
}