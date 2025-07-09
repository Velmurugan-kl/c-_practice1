//THis is the main program to get user input for choice

using ContactManager;
using System.Numerics;




SortedList<string, ContactsInfo> contactsList = new SortedList<string, ContactsInfo>();


string userInput;
do
{
    Console.WriteLine("Enter Your choice!!!");
    Console.WriteLine("S - To View/Search contact(s)");
    Console.WriteLine("A - To Add a contact");
    Console.WriteLine("U - To Update a contact");
    Console.WriteLine("D - To Delete a contact");
    Console.WriteLine("E - To Exit");
    userInput = Console.ReadLine().ToUpper();
    HandleChoice(userInput);
}
while (userInput != "E");

void HandleChoice(string choice)
{
    Console.Clear();
    switch (choice)
    {
        case "S":
            new Functionalities().ViewOrSearchContacts(contactsList);
            break;
        case "A":
            new Functionalities().AddContact(contactsList);
            break;
        case "U":
            new Functionalities().UpdateContact(contactsList);
            break;
        case "D":
            new Functionalities().DeleteContact(contactsList);
            break;
    }
    //Console.Clear();
}


