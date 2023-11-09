using Contacts.Maui.ViewModel.DepartmentViewModels;

namespace Contacts.Maui.Views.Department;

public partial class CreateDepartmentPage : ContentPage
{
	public CreateDepartmentPage(DepartmentViewModel departmentviewModel)
	{
		InitializeComponent();
		BindingContext = departmentviewModel;
    }

   
}