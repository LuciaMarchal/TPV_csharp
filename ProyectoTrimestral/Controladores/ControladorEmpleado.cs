using ProyectoTrimestral.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProyectoTrimestral.Controladores
{
    public static class ControladorEmpleado
    {
        public static List<Empleado> listaEmpleado = new List<Empleado>();

        public static void leer()
        {
            try
            {
                string xml = File.ReadAllText("empleados.xml");
                using (var reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(listaEmpleado.GetType());
                    listaEmpleado = (List<Empleado>)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error leyendo xml " + e.Message);
            }
        }

        public static void escribir()
        {
            try
            {
                using (var writer = new StreamWriter("empleados.xml"))
                {
                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    var serializer = new XmlSerializer(listaEmpleado.GetType());
                    serializer.Serialize(writer, listaEmpleado, namespaces);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error escribiendo xml " + e.Message);
            }
        }

        public static void leerAccesos()
        {
            try
            {
                Stream OpenFileStream = File.OpenRead("accesos.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                listaEmpleado = (List<Empleado>)deserializer.Deserialize(OpenFileStream);
                OpenFileStream.Close();

                // Mostrar por consola el contenido de la lista
                Console.WriteLine("Contenido del archivo accesos.bin:");
                foreach (Empleado empleado in listaEmpleado)
                {
                    Console.WriteLine("Leyendo del fichero....");
                    Console.WriteLine($"Nombre: {empleado.nombre}, Apellidos: {empleado.apellidos}, Correo: {empleado.correo}");
                    Console.WriteLine($"Fecha de nacimiento: {empleado.fecha}");
                    Console.WriteLine($"Contraseña: {empleado.contrasena}");
                    Console.WriteLine($"Fecha de inicio: {empleado.inicio}");
                    Console.WriteLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer accesos.bin " + e.Message);
            }
        }

        public static void escribirAccesos()
        {
            try
            {
                Stream SaveFileStream = File.Create("accesos.bin");
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, listaEmpleado);
                SaveFileStream.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine("Error al escribir accesos.bin " + e.Message);
            }
        }

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
            string query = "INSERT INTO Empleado (correo, nombre, apellidos, fecha, contrasena) " +
                "VALUES(@correo, @nombre, @apellidos, @fecha, @contrasena)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", e.correo);
                    command.Parameters.AddWithValue("@nombre", e.nombre);
                    command.Parameters.AddWithValue("@apellidos", e.apellidos);
                    command.Parameters.AddWithValue("@fecha", e.fecha.ToString());
                    command.Parameters.AddWithValue("@contrasena", e.contrasena);
                    
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

            string query = "SELECT correo, nombre, apellidos, fecha, contrasena, inicio FROM Empleado";
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("correo", "correo");
            dataGridView.Columns.Add("nombre", "nombre");
            dataGridView.Columns.Add("apellidos", "apellidos");
            dataGridView.Columns.Add("fecha", "fecha");
            dataGridView.Columns.Add("contrasena", "contrasena");
            dataGridView.Columns.Add("inicio", "inicio");

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
                                dataGridView.Rows.Add(reader["correo"].ToString(), reader["nombre"].ToString(),
                                    reader["apellidos"].ToString(), reader["fecha"].ToString(),
                                    reader["contrasena"].ToString(), reader["inicio"].ToString());
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

        public static bool usuarioExiste(string correo)
        {
            string connectionString = construirCadenaConexion();
            string query = "SELECT COUNT(*) FROM Empleado WHERE correo = @correo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}