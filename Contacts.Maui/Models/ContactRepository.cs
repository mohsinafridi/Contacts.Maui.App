namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
        new Contact() { Id = 1, Name = "Mohsin Azam" , Email = "mohsin@gmail.com", Phone="123 453 112"},
        new Contact() { Id = 2, Name = "Faeez Tatli" , Email = "faeez@gmail.com", Phone="123 453 112"},
        new Contact() { Id = 3, Name = "Zeeshan Ayyub" , Email = "zeeshan@gmail.com", Phone="123 453 112"},
        new Contact() { Id = 4, Name = "Hazrat" , Email = "Hazrat@gmail.com", Phone="123 453 112"}
        };


        public static List<Contact> GetContacts() => _contacts;


        public static Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == contactId);
            if (contact is not null)
            {
                return new Contact
                {
                    Id = contactId,
                    Name = contact.Name,
                    Address = contact.Address,
                    Phone = contact.Phone,
                    Email = contact.Email,
                };
            }
            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.Id)
                return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.Id == contact.Id);
            if (contactToUpdate is not null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;
            }

        }

        public static void SaveContact(Contact contact)
        {
            var max = _contacts.Max(x => x.Id);
            contact.Id = max + 1;
            _contacts.Add(contact);

        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == contactId);
            if (contact is not null)
            {
                _contacts.Remove(contact);
            }

        }

    }


}
