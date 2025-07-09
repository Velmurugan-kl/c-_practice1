

using InfoNameSpace;
using HelperClass;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;



SortedList<string, Info> contactInfo = new SortedList<string, Info>();
List<Info> list = new List<Info>();

string userInput;
do
{
    Console.WriteLine("Enter Your choice!!!");
    Console.WriteLine("S - To View the contacts");
    Console.WriteLine("A - To Add contact");
    Console.WriteLine("U - To Update a contact");
    Console.WriteLine("D - To Delete a contact");
    Console.WriteLine("E - To Exit");
    userInput = Console.ReadLine().ToUpper();
    HandleChoice(userInput);
}
while (userInput != "E");

void HandleChoice(string choice)
{
    switch (choice)
    {
        case "S":
            ViewContacts();
            break;
        case "A":
            AddContact();
            break;
        case "U":
            UpdateContact();
            break;
        case "D":
            DeleteContact();
            break;
    }
}


void ViewContacts()
{
    string choice;

    Console.WriteLine("A - To view all contacts");
    Console.WriteLine("N - To view contacts by name");
    Console.WriteLine("P - To view contacts by number");
    Console.WriteLine("E - To go back to Main Menu");
    choice = Console.ReadLine().ToUpper();
    switch (choice)
    {
        case "A":
            DisplayAllContacts();
            break;
        case "N":
            new help().SearchUserDisplay(new help().FindByName(Console.ReadLine(),list),list);
            break;
        case "P":
            uint phone = new help().GetNumber();
            new help().SearchUserDisplay(new help().FindByPhone(phone, list), list);
            break;
        case "E":
            return;
    }
}


void DisplayAllContacts()
{
    for (int i = 0; i < contactInfo.Count; i++)
    {
        Console.WriteLine(contactInfo.Values[i].name);
        
    }
}

void AddContact()
{
    string name;
    string number;
    string mail;
    string notes;

    Console.WriteLine("Enter the name");
    name = Console.ReadLine();
    //Number
    uint phone= new help().GetNumber();
    Console.WriteLine("Enter the mail");
    mail = Console.ReadLine();
    Console.WriteLine("Write any notes about the contact");
    notes = Console.ReadLine();

    Info obj = new Info(name, mail, phone, notes);
    contactInfo.Add(name, obj);
    list.Add(obj);
}

void UpdateContact()
{
    
}

void DeleteContact()
{
    string choice;
    do
    {
        Console.WriteLine("DN - To delete contact by name");
        Console.WriteLine("DP - To delete contact by phone");
        choice = Console.ReadLine().ToUpper();
    } while (choice != "DN" && choice != "DP");
    int index=-1;
    switch(choice)
    {
        case "DN":
            index = new help().FindByName(Console.ReadLine(),list);
            break;
        case "DP":
            uint phone = new help().GetNumber();
            index = new help().FindByPhone(phone,list);
            break;
    }
    new help().DeleteUser(index,list);

}
