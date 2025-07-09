//class with all the methods required for functionalities
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager;

namespace ContactManager
{
    internal class Services
    {
        public void DisplayUserInfo(ContactsInfo obj) //Method to display the contacts detail
        {
            Console.WriteLine($"Name : {obj.name} \tNumber : {obj.phone}\temail : {obj.email}\tnotes : {obj.notes}");
        }
        public void DisplayUser(int index, SortedList<string, ContactsInfo> contactsList)//Method to display the found user
        {
            Console.WriteLine();
            if (index != -1)
            {
                Console.WriteLine("User found");
                DisplayUserInfo(contactsList.Values[index]);
                return;
            }
            Console.WriteLine("User Not Found");
        }
        public void UpdateContactInfo(int index, SortedList<string, ContactsInfo> contactsList)//method todisplay options for updating the user info
        {
            if (index == -1)
            {
                Console.WriteLine("User Not Found");
                return;
            }
            string choice;
            do
            {
                Console.WriteLine("N - To Change Name of the User");
                Console.WriteLine("P - To Change Phone Number of the User");
                Console.WriteLine("NT - To Change Notes of the User");
                Console.WriteLine("M - To Change MailID of the User");
                Console.WriteLine("E - To Exit");
                choice = Console.ReadLine().ToUpper();
            }
            while (!new Utilities().IsValidUpdateChoice(choice));
            Console.WriteLine();
            switch (choice)
            {
                case "N":
                    contactsList.Values[index].name = GetName(contactsList);
                    break;
                case "P":
                    contactsList.Values[index].phone = GetNumber();
                    break;
                case "NT":
                    Console.WriteLine("Enter the Notes");
                    contactsList.Values[index].notes = Console.ReadLine();
                    break;
                case "M":
                    contactsList.Values[index].email = GetMailId();
                    break;
                default:
                    return;
            }
            Console.Clear();
        }

        public void DeleteUser(int index, SortedList<string, ContactsInfo> contactsList)//Method to delete contact
        {
            Console.WriteLine();
            if (index != -1)
            {
                Console.WriteLine("User Deleted");
                DisplayUserInfo(contactsList.Values[index]);
                contactsList.RemoveAt(index);
                return;
            }
            Console.WriteLine("User Not Found");
        }


        public string GetNumber()// Method to verify and get the number in a proper format
        {
            string number;
            do
            {
                Console.WriteLine("Enter the number");
                number = Console.ReadLine();
            }
            while (!long.TryParse(number, out long result)
            );
            //|| number.Length < 10);
            //disabled for testing purpose alone
            return number;
        }

        public string GetMailId()//Method to verify and get the mailid in correct format
        {
            string mailId;
            var emailValid = new EmailAddressAttribute();
            do
            {
                Console.WriteLine("Enter the Mail Address");
                mailId = Console.ReadLine();
            }
            while (!emailValid.IsValid(mailId));
            return mailId;
        }
        public string GetName(SortedList<string, ContactsInfo> contactsList)//Method to check whether the name exists
        {
            string name;
            do
            {
                Console.WriteLine("Enter the Name");
                name = Console.ReadLine();
            } while (!new Utilities().IsValidName(name,contactsList));
            return name;
        }


        public int SearchContacts(SortedList<string, ContactsInfo> contactsList, string userInput)
        {
            int index;
            if (long.TryParse(userInput, out long result))
            {
                index = new Services().FindByPhone(userInput, contactsList);
            }
            else
            {
                index = new Services().FindByName(userInput, contactsList);
            }

            return index;
        }
        public int FindByPhone(string phone, SortedList<string, ContactsInfo> contactsList)//  Method to find contacts by number
        {
            for (int i = 0; i < contactsList.Count; i++)
            {
                if (contactsList.Values[i].phone == phone) return i;
            }
            return -1;
        }

        public int FindByName(string name, SortedList<string, ContactsInfo> contactsList)//Method to find contacts by name
        {
            for (int i = 0; i < contactsList.Count; i++)
            {
                if (contactsList.Values[i].name == name) return i;
            }
            return -1;
        }
    }
}
