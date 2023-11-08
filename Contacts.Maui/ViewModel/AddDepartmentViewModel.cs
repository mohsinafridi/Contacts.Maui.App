using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Database;
using Contacts.Maui.Models;
using Contacts.Maui.Views.Department;

namespace Contacts.Maui.ViewModel
{
    public partial class AddDepartmentViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        [ObservableProperty]
        private string _name;

        public AddDepartmentViewModel(AppDbContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task AddDepartment()
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    Department department = new()
                    {
                        Name = Name,
                    };
                    //  var response =  await DeptService.CreateDepartment(department); // OLd way without MVVM

                    var response = await _context.CreateAsync(department);
                    if (response > 0)
                    {
                        await Shell.Current.DisplayAlert("Department Added", "Department Added Successfully", "OK");
                        await Shell.Current.GoToAsync(nameof(DepartmentsPage));
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Name is required.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
