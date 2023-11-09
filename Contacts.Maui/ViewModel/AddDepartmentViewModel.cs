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

        [ObservableProperty]
        private Department _operatingDepartment = new();

        public AddDepartmentViewModel(AppDbContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task AddDepartment()
        {
            try
            {
                if (OperatingDepartment is null)
                    return;

                if (OperatingDepartment.Id ==0)
                {
                    //Department department = new()
                    //{
                    //    Name = Name,
                    //};
                    //  var response =  await DeptService.CreateDepartment(department); // OLd way without MVVM

                    var response = await _context.CreateAsync<Department>(OperatingDepartment);
                    if (response > 0)
                    {
                        await Shell.Current.DisplayAlert("Department Added", "Department Added Successfully", "OK");
                        await Shell.Current.GoToAsync(nameof(DepartmentsPage));
                    }
                }
                else
                {
                  await _context.UpdateAsync<Department>(OperatingDepartment);
                }
                OperatingDepartment = new();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
