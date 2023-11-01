using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Models.Contact contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public int ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(value);
            if (contact is not null)
            {
                ContactCtrl.Name = contact.Name;
                ContactCtrl.Email = contact.Email;
                ContactCtrl.Phone= contact.Phone;
                ContactCtrl.Address = contact.Address;
            }
        }

    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        //if (nameValidator.IsNotValid)
        //{
        //    DisplayAlert("Error", "Name is required", "Ok");
        //    return;
        //}

        //if (emailValidator.IsNotValid)
        //{
        //    foreach (var error in emailValidator.Errors)
        //    {
        //        DisplayAlert("Error", error.ToString(), "Ok");
        //    }
        //    return;
        //}


        contact.Name = ContactCtrl.Name;
        contact.Email = ContactCtrl.Email;
        contact.Phone = ContactCtrl.Phone;
        contact.Address = ContactCtrl.Address;


        ContactRepository.UpdateContact(contact.Id, contact);
        Shell.Current.GoToAsync("..");
    }

    private void ContactCtrl_OnError(object sender,string e)
    {
        DisplayAlert("Error",e,"Ok");

    }
}