using System;
using System.Data.SqlClient;
using System.Windows;

namespace Register
{
    public partial class MainWindow : Window
    {
        private const string connectionString = "Data Source=(localdb)\\yefelson;Initial Catalog=Personas;Integrated Security=True"; // Reemplaza con tu cadena de conexión

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = NameR.Text;
            string email = EmailR.Text;
            string password = PaswordR.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO usuarios (nombre, email, password) VALUES (@Nombre, @Email, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Registro exitoso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }

        private void Loginenter_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
        }
    }
}