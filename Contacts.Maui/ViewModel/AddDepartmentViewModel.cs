using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Models;
using Contacts.Maui.Services;

namespace Contacts.Maui.ViewModel
{
    public partial class AddDepartmentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        public AddDepartmentViewModel()
        {
            
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
                    var response =  await DeptService.CreateDepartment(department);

                    if (response)
                    {
                        await Shell.Current.DisplayAlert("Department Added", "Department Added Successfully", "OK");
                        await Shell.Current.GoToAsync("..");
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
