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
        //  NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        public GetDepartmentsViewModel(AppDbContext context)
        {
            // _context = context;
            LoadDepartments();

        }

        [ObservableProperty]
        string name;


        public ObservableCollection<Department> Departments { get; private set; } = new();

        [ObservableProperty]
        private Department _operatingDepartment = new();

        [RelayCommand]
        public void LoadDepartments()
        {
            //if (accessType == NetworkAccess.Internet)
            //{
            //    cars = await carApiService.GetCars();
            //}

            Departments.Clear();

            //  var departments = _context.GetTableRows<Department>("Department");
          //  var departments = await _context.GetAllAsync<Department>();
            var departments = App.Database.GetTableRows<Department>("Department").ToList();

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
