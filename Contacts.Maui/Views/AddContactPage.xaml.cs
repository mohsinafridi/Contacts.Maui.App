using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {

        ContactRepository.SaveContact(new Models.Contact
        {
            Name = ContactCtrl.Name, 
            Email = ContactCtrl.Email,
            Phone = ContactCtrl.Phone,
            Address = ContactCtrl.Address
        });
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
    
}