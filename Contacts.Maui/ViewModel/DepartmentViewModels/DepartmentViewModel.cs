
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Database;
using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Contacts.Maui.ViewModel.DepartmentViewModels
{
    public partial class DepartmentViewModel : ObservableObject, INotifyPropertyChanged
    {
        private readonly AppDbContext _context;
        public DepartmentViewModel(AppDbContext context)
        {
            _context = context;
        }

        [ObservableProperty]
        private ObservableCollection<Department> _departments = new();

        [ObservableProperty]
        private Department _operatingDepartment = new();

        [ObservableProperty]
        private bool _name;

        [ObservableProperty]
        private bool _id;


        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;

        [RelayCommand]
        private void SetOperatingProduct(Department? department) => OperatingDepartment = department ?? new();

        // [RelayCommand]
        public async Task LoadDepartments()
        {
            await ExecuteAsync(async () =>
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
            }, "Fetching products...");

        }


        [RelayCommand]
        public async Task SaveDepartment()
        {

            if (OperatingDepartment is null)
                return;


            var busyText = OperatingDepartment.Id == 0 ? "Adding Department..." : "Updating Department...";
            await ExecuteAsync(async () =>
            {
                if (OperatingDepartment.Id == 0)
                {
                    var response = await _context.CreateAsync(OperatingDepartment);
                    if (response > 0)
                    {
                        await Shell.Current.DisplayAlert("Department Added", "Department Added Successfully", "OK");
                        await Shell.Current.GoToAsync("..");
                    }
                }
                else
                {
                    if (await _context.UpdateAsync<Department>(OperatingDepartment))
                    {
                        var departmentCopy = OperatingDepartment.Clone();

                        var index = Departments.IndexOf(OperatingDepartment);
                        Departments.RemoveAt(index);

                        Departments.Insert(index, departmentCopy);
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Product updation error", "Ok");
                        return;
                    }
                }
                SetOperatingProductCommand.Execute(new());
            }, busyText);

        }      

        [RelayCommand]
        private async Task DeleteDepartment(Department department)
        {
            var result = await Shell.Current.DisplayAlert("Delete", $"Are you sure you want to delete {department.Name}?", "Yes", "No");
            if (result is true)
            {
                await ExecuteAsync(async () =>
                {
                    if (await _context.DeleteItemByKeyAsync<Department>(department.Id))
                    {
                        var department1 = Departments.FirstOrDefault(p => p.Id == department.Id);
                        Departments.Remove(department1);
                    }
                    else {
                        await Shell.Current.DisplayAlert("Error", "Department was not deleted", "Ok");
                    } 
                }, "Deleting department...");
            }
        }

        private async Task ExecuteAsync(Func<Task> operation, string busyText)
        {
            IsBusy = true;
            BusyText = busyText;
            try
            {
                await operation?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                IsBusy = false;
                BusyText = "Processing...";
            }
        }

    }
}
