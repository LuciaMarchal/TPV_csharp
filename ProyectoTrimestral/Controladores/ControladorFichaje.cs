using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTrimestral.Clases;

namespace ProyectoTrimestral.Controladores
{
    public class ControladorFichaje
    {
        public static String construirCadenaConexion()
        {
            string databaseFileName = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\PlatanitosBD.mdf"));
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename ={databaseFileName}; Integrated Security = True";

            MessageBox.Show("Cadena de conexión: " + connectionString);
            return connectionString;
        }

        public static void insertar(Empleado e)
        {
            string connectionString = construirCadenaConexion();
            string query = "INSERT INTO Fichaje (correo) " +
                "VALUES(@correo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", e.correo);

                    try
                    {
                        int registrosAfectados = command.ExecuteNonQuery();
                        MessageBox.Show($"Se insertó correctamente el registro. Registros afectados: {registrosAfectados}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar el registro: {ex.Message}");
                    }
                }
            }
        }
        public static void cargarDatosDataGridView(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.Font = new Font("Cascadia Code", 9);
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.Font = new Font("Cascadia Code", 9, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            string connectionString = construirCadenaConexion();

            string query = "SELECT correo, hora FROM Fichaje";
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("correo", "correo");
            dataGridView.Columns.Add("hora", "hora");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar una nueva fila al DataGridView con el código y el nombre del proyecto
                                dataGridView.Rows.Add(reader["correo"].ToString(), reader["hora"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        public static DataSet rellenarDataSet()
        {
            DataSet dataSet = new DataSet();
            using (var cnn = new SqlConnection(construirCadenaConexion()))
            {
                try
                {
                    cnn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Fichaje", cnn);
                    dataAdapter.Fill(dataSet);
                    dataAdapter.Dispose();
                    cnn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al recuperar fichajes " + e.Message);
                }
            }
            return dataSet;
        }

        public static void actualizar(string valor, string clave)
        {
            string updateQuery = $"UPDATE Fichaje SET hora = @valor WHERE correo = @clave";

            using (SqlConnection connection = new SqlConnection(construirCadenaConexion()))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@valor", valor);
                    command.Parameters.AddWithValue("@clave", clave);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Los datos se actualizaron correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar los datos en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar los datos en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}