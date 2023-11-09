using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Database;
using Contacts.Maui.Models;
using Contacts.Maui.Views.Department;
using System.Collections.ObjectModel;

namespace Contacts.Maui.ViewModel.DepartmentViewModels
{

    public partial class GetDepartmentsViewModel : ObservableObject
    {
        private readonly AppDbContext _context;        
        public GetDepartmentsViewModel(AppDbContext context)
        {
             _context = context;
            LoadDepartments();

        }

        [ObservableProperty]
        private bool _isBusy;


        [ObservableProperty]
        private string _busyText;

        [ObservableProperty]
        private ObservableCollection<Department> _departments = new();

     //   [ObservableProperty]
       // private Department _operatingDepartment = new();

        [RelayCommand]
        public async Task LoadDepartments()
        {
            
            Departments.Clear();

             var departments = await _context.GetAllAsync<Department>();
            //  var departments = await _context.GetAllAsync<Department>();
            // var departments = await App.Database.GetAllAsync<Department>();

            if (departments is not null && departments.Any())
            {
                Departments ??= new ObservableCollection<Department>();
                foreach (var department in departments)
                {
                    Departments.Add(department);
                }
            }
        }

        [RelayCommand]
        private async Task DeleteDepartment(Department department)
        {
            var result = await Shell.Current.DisplayAlert("Delete", $"Are you sure you want to delete {department.Name}?", "Yes", "No");
            if (result is true)
            {
                try
                {
                    await _context.DeleteAsysnc(department);
                     LoadDepartments();
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        [RelayCommand]
        private async Task AddDepartment() => await Shell.Current.GoToAsync(nameof(CreateDepartmentPage));
    }
}
