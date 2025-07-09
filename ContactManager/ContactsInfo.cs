using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class ContactsInfo
    {
        public string name;
        public string email;
        public string phone;
        public string notes;

        public ContactsInfo(string name, string email, string phone, string notes)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.notes = notes;
        }
    }
}
