using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class Functionalities
    {
        public void ViewOrSearchContacts(SortedList<string, ContactsInfo> contactsList)//Method to view or search contact
        {
            if (new Utilities().listIsEmpty(contactsList)) return;
            Console.WriteLine();
            string choice;
            do
            {
                Console.WriteLine("Select from the below option\n");
                Console.WriteLine("A - To view all contacts");
                Console.WriteLine("N - To Search Contact by Name");
                Console.WriteLine("P - To Search Contact by Phone Number");
                Console.WriteLine("E - To go Back to Main Menu");
                choice = Console.ReadLine().ToUpper();

            }
            while (!new Utilities().IsValidSearchChoice(choice));
            Console.Clear();
            switch (choice)
            {
                case "A":
                    DisplayAllContacts(contactsList);
                    break;
                case "N":
                    new Services().DisplayUser(new Services().FindByName(Console.ReadLine(), contactsList), contactsList);
                    break;
                case "P":
                    string phone = new Services().GetNumber();
                    new Services().DisplayUser(new Services().FindByPhone(phone, contactsList), contactsList);
                    break;
                default:
                    return;
            }
        }

        

        public void DisplayAllContacts(SortedList<string, ContactsInfo> contactsList)//Method to display all contacts
        {
            
            for (int i = 0; i < contactsList.Count; i++)
            {
                new Services().DisplayUserInfo(contactsList.Values[i]);

            }
            Console.WriteLine();
 
        }
        public void AddContact(SortedList<string, ContactsInfo> contactsList)
        {
            string name;
            string phone;
            string mail;
            string notes;
            name = new Services().GetName(contactsList);
            phone = new Services().GetNumber();
            mail = new Services().GetMailId();
            Console.WriteLine("Write any notes about the contact(optional)");
            notes = Console.ReadLine();

            ContactsInfo obj = new ContactsInfo(name, mail, phone, notes);
            contactsList.Add(name,obj);
            Console.Clear();
        }

        public void UpdateContact(SortedList<string, ContactsInfo> contactsList)//Method to update contact
        {
            if (new Utilities().listIsEmpty(contactsList)) return;
            DisplayAllContacts(contactsList);
            Console.WriteLine();
            string userInput;
            int index = -1;
            do
            {
                Console.WriteLine("Enter the contact detail that you need to update");
                userInput = Console.ReadLine();
                index = new Services().SearchContacts(contactsList, userInput);
            }
            while (userInput.Length == 0);
            Console.Clear();
            new Services().UpdateContactInfo(index, contactsList);
        }

        public void DeleteContact(SortedList<string, ContactsInfo> contactsList)//Method to delete contact
        {
            if (new Utilities().listIsEmpty(contactsList)) return;
            DisplayAllContacts(contactsList);
            Console.WriteLine();
            string userInput;
            int index = -1;
            do
            {
                Console.WriteLine("Enter the contact detail that you need to delete");
                userInput = Console.ReadLine();
                index = new Services().SearchContacts(contactsList,userInput);
            }
            while (userInput.Length == 0);
            Console.Clear();
            new Services().DeleteUser(index, contactsList);

        }
    }
}
