using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Services
{
    public interface IContactService
    {

        IEnumerable<Contact> GetAll();

        Contact GetContact();
        void SaveContact(Contact contact);

        void UpdateContact(int contactId,Contact contact);

        void DeleteContact(int contactId);
    }
}
