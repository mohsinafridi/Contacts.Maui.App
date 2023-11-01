using Contacts.Maui.Services;

namespace Contacts.Maui.Views.Department;

public partial class DepartmentsPage : ContentPage
{
	public DepartmentsPage()
	{
		InitializeComponent();
       
        LoadDepartmentsAsync();  // get fresh copy to list
    }


    private void CvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Contacts.Maui.Models.Department;

        if (currentSelection == null) return;

        //   Navigation.PushModalAsync(new DepartmentDetailView(currentSelection.Id));

        ((CollectionView)sender).SelectedItem = null;
    }

    private async void LoadDepartmentsAsync()
    {
        var departments = await DeptService.GetDepartments();
        if (departments.Any())
            CvDepartments.ItemsSource = departments;
    }


}