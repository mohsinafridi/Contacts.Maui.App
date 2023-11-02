using Contacts.Maui.ViewModel;

namespace Contacts.Maui.Views.Department;

public partial class CreateDepartmentPage : ContentPage
{
	public CreateDepartmentPage(AddDepartmentViewModel addDepartmentviewModel)
	{
		InitializeComponent();
		BindingContext = addDepartmentviewModel;

    }

   
}