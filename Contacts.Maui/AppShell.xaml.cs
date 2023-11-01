using Contacts.Maui.Views;
using Contacts.Maui.Views.Department;

namespace Contacts.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));


            Routing.RegisterRoute(nameof(DepartmentsPage), typeof(DepartmentsPage));
            Routing.RegisterRoute(nameof(AddDepartmentPage), typeof(AddDepartmentPage));
            Routing.RegisterRoute(nameof(EditDepartmentPage), typeof(EditDepartmentPage));
        }
    }
}