using System.Collections.Generic;
using InfoNameSpace;

namespace HelperClass
{
    public class help
    {
        public int FindByPhone(uint phone, List<Info> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].phone == phone) return i;
            }
            return -1;
        }

        public int FindByName(string name, List<Info> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == name) return i;
            }
            return -1;
        }
        public void DisplayInfo(Info obj)
        {
            Console.WriteLine($"Name : {obj.name} \tNumber : {obj.phone}\temail : {obj.email}\n");
        }

        public void DeleteUser(int index, List<Info> list)
        {
            if (index != -1)
            {
                Console.WriteLine("User Deleted");
                DisplayInfo(list[index]);
                list.RemoveAt(index);
                return;
            }
            Console.WriteLine("User Not Found");
        }

        public void SearchUserDisplay(int index, List<Info> list)
        {
            if (index != -1)
            {
                Console.WriteLine("User found");
                DisplayInfo(list[index]);
                return;
            }
            Console.WriteLine("User Not Found");
        }

        public uint GetNumber()
        {
            string number;
            uint phone;
            do
            {
                Console.WriteLine("Enter the number");
                number = Console.ReadLine();
            }
            while (!uint.TryParse(number, out uint result));
            phone = uint.Parse(number);
            return phone;
        }

    }
}
