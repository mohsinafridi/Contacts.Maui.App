using System.Threading.Tasks.Dataflow;

namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public ContactControl()
	{
		InitializeComponent();
	}

   public string Name
    {
        get 
        {
            return EntName.Text;
        }
        set 
        {
         EntName.Text = value;
        }
    }
    public string Email
    {
        get
        {
            return EntEmail.Text;
        }
        set
        {
            EntEmail.Text = value;
        }
    }
    public string Address
    {
        get
        {
            return EntAddress.Text;
        }
        set
        {
            EntAddress.Text = value;
        }
    }
    public string Phone
    {
        get
        {
            return EntPhone.Text;
        }
        set
        {
            EntPhone.Text = value;
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        // Save Logic
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;
        }

        OnSave?.Invoke(sender,e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        // Cancel Logic
        OnCancel?.Invoke(sender, e);
    }
}