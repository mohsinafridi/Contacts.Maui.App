
using Contacts.Maui.Models;
using Contacts.Maui.Services;
using Contacts.Maui.Views.Department;
using System.Data.SqlClient;

namespace Contacts.Maui.Views.Home;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private async void BtnCreateConnection_Clicked(object sender, EventArgs e)
    {

        // Check if local is working with Android Build.

        string ServerName = EntDataSource.Text;
        string DatabaseName = EntDatabase.Text;
        string UserName = EntUsername.Text;
        //string Password = EntPassword.Text;

        if (string.IsNullOrEmpty(ServerName))
        {
            await DisplayAlert("", "Servername is required", "Cancel");
            return;
        }
        if (string.IsNullOrEmpty(DatabaseName))
        {
            await DisplayAlert("", "Database Name is required", "Cancel"); return;
        }
        if (string.IsNullOrEmpty(UserName))
        {
            await DisplayAlert("", "Username is required", "Cancel"); return;
        }
        //if (string.IsNullOrEmpty(Password))
        //{
        //    await DisplayAlert("", "Username is required", "Cancel"); return;
        //}

        var obj = new ConnectionModel
        {
            ServerName =ServerName,
            Catalog = DatabaseName,
            Username = UserName,
            Password = ""
        };

        // call connection api for 
        // http://localhost:5218/ConnectionBuild
        var response = await ApiService.CreateConnection(obj);
        if (response)
        {
            await DisplayAlert("", "Connection Created Successfully", "Ok");
            await Navigation.PushModalAsync(new AddDepartmentPage());
        }
        else
        {
            await DisplayAlert("", "Error occur in creating connection", "Cancel");
        }

    }

private void BtnCancel_Clicked(object sender, EventArgs e)
{

}
}