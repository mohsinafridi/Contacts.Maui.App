
using System.Data.SqlClient;

namespace Contacts.Maui.Views.Home;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private void btnCreateConnection_Clicked(object sender, EventArgs e)
    {

        // Ado .net code for creating connection and 

        string DataSource = EntDataSource.Text;
        string DataBaseName = EntDatabase.Text;
        string username = "";
        string password = "";
        // Connection
        string ConnectionString = $"Data Source={DataSource};Initial Catalog={DataBaseName};" +
            $"User Id={username};Password={password}";
        //Integrated Security=SSPI;";
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            
            string sql = "SELECT * FROM Departments WHERE Column = @value";

            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }

            //*
//             * SQL5109.site4now.net

//username : db_aa0b62_realestatedb_admin
//password : Learning@7788
//             * *
             //
            // Call Close when done reading.
            reader.Close();
        }

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {

    }
}