using Contacts.Maui.Services;

namespace Contacts.Maui.Views.Department;

public partial class DepartmentsPage : ContentPage
{
    public DepartmentsPage()
    {
        InitializeComponent();

        LoadDepartments();  // get fresh copy to list
    }


    private void listDepartments_ItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (listDepartments.SelectedItem != null)
        {
            Shell.Current.GoToAsync($"{nameof(EditDepartmentPage)}?Id={((Models.Department)listDepartments.SelectedItem).Id}");
        }


    }
    private void listDepartments_ItemTapped(object sender, SelectionChangedEventArgs e)
    {
        listDepartments.SelectedItem = null;
    }


    private async void LoadDepartments()
    {
        var departments = await DeptService.GetDepartments();
        if (departments.Any())
            listDepartments.ItemsSource = departments.Take(5)
                             .OrderByDescending(x => x.Id)
                             .ToList();
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var department = menuItem.CommandParameter as Models.Department;

        // delete
        await DeptService.DeleteDepartment(department.Id);

        LoadDepartments();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddDepartmentPage));
    }
}