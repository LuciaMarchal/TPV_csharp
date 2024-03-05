using ProyectoTrimestral.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

            string query = "SELECT correo, nombre, apellidos, fecha, contrasena FROM Empleado";
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("correo", "correo");
            dataGridView.Columns.Add("nombre", "nombre");
            dataGridView.Columns.Add("apellidos", "apellidos");
            dataGridView.Columns.Add("fecha", "fecha");
            dataGridView.Columns.Add("contrasena", "contrasena");

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
                                    reader["contrasena"].ToString());
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
        public static DataSet rellenarDataSet()
        {
            DataSet dataSet = new DataSet();
            using (var cnn = new SqlConnection(construirCadenaConexion()))
            {
                try
                {
                    cnn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Empleado", cnn);
                    dataAdapter.Fill(dataSet);
                    dataAdapter.Dispose();
                    cnn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al recuperar empleados " + e.Message);
                }
            }
            return dataSet;
        }

        public static void actualizar(string columna, object valor, object clave)
        {
            string updateQuery = $"UPDATE Empleado SET {columna} = @newValue WHERE correo = @primaryKeyValue";

            using (SqlConnection connection = new SqlConnection(construirCadenaConexion()))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@newValue", valor);
                    command.Parameters.AddWithValue("@primaryKeyValue", clave);

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

        public static Boolean actualizarDataSet(DataSet dataSet)
        {
            Boolean resultado = true;
            try
            {
                using (var cnn = new SqlConnection(construirCadenaConexion()))
                {
                    cnn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Empleado", cnn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                    builder.GetUpdateCommand();
                    dataAdapter.Update(dataSet);
                    dataAdapter.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                resultado = false;
            }
            return resultado;
        }

        public static Boolean eliminar(string id)
        {
            bool resultado = true;
            try
            {
                using (SqlConnection cnn = new SqlConnection(construirCadenaConexion()))
                {
                    cnn.Open();
                    SqlCommand comando = cnn.CreateCommand();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "DELETE FROM Empleado WHERE correo = @id";
                    comando.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter adaptador = new SqlDataAdapter();
                    adaptador.DeleteCommand = comando;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        resultado = false;
                    }
                    adaptador.Dispose();
                    comando.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar " + e.Message);
                resultado = false;
            }
            return resultado;
        }
    }
}