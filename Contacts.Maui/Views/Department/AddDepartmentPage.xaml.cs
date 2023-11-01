using Contacts.Maui.Services;

namespace Contacts.Maui.Views.Department;

public partial class AddDepartmentPage : ContentPage
{
	public AddDepartmentPage()
	{
		InitializeComponent();
	}

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EntDeptName.Text))
        {
            await DisplayAlert("", "Name is required", "Cancel");
        }

        var dept = new Models.Department
        {
            Name = EntDeptName.Text
        };


        var response = await DeptService.CreateDepartment(dept);
        if (response)
        {
            await DisplayAlert("", "Department has been created", "Ok");
            await Navigation.PushModalAsync(new DepartmentsPage());
        }
        else
        {
            await DisplayAlert("", "Oops something went wrong", "Cancel");
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {

    }
}