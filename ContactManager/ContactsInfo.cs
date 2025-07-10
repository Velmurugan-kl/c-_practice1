using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class ContactsInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }

        public ContactsInfo(string name, string email, string phone, string notes)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Notes = notes;
        }
    }
}
