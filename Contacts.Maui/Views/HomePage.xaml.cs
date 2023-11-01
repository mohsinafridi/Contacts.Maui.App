namespace Contacts.Maui.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void btnStart_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(ContactsPage));
    }
}