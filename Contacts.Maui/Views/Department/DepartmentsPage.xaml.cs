using Contacts.Maui.Services;
using Contacts.Maui.ViewModel.DepartmentViewModels;

namespace Contacts.Maui.Views.Department;

public partial class DepartmentsPage : ContentPage
{   
    public DepartmentsPage(GetDepartmentsViewModel getDepartmentListViewModel)
    {
        InitializeComponent();
        BindingContext = getDepartmentListViewModel; 
    }

   
    private void ListDepartments_ItemSelected(object sender, SelectionChangedEventArgs e)
    {
        //if (listDepartments.SelectedItem != null)
        //{
        //    Shell.Current.GoToAsync($"{nameof(EditDepartmentPage)}?Id={((Models.Department)listDepartments.SelectedItem).Id}");
        //}
    }
    private void ListDepartments_ItemTapped(object sender, SelectionChangedEventArgs e)
    {
      //  listDepartments.SelectedItem = null;
    }


    // private  void LoadDepartments()
    // {
    //    // var departments = await DeptService.GetDepartments();
    //    List<Models.Department> departments = _context.GetTableRows<Models.Department>("Department");
    //    if (departments is not null && departments.Any())
    //        listDepartments.ItemsSource = departments.ToList();
    // }

    // private async void Delete_Clicked(object sender, EventArgs e)
    // {
    //    var menuItem = sender as MenuItem;
    //    var department = menuItem.CommandParameter as Models.Department;

    //    // delete dept using API
    //    await DeptService.DeleteDepartment(department.Id);



    //   // LoadDepartments();
    // }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CreateDepartmentPage));
    }
}