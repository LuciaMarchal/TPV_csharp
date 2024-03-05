using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ProyectoTrimestral.Controladores
{
    public static class ControladorFruta
    {
        public static List<Fruta> listaFrutas = new List<Fruta>();

        public static void leer()
        {
            try
            {
                if (File.Exists("frutas.json"))
                {
                    string jsonString = File.ReadAllText("frutas.json");
                    listaFrutas = JsonSerializer.Deserialize<List<Fruta>>(jsonString);
                }
            }
            catch (Exception e) 
            { 
                Console.WriteLine("Error leyendo en frutas.json" + e);
            }
        }

        public static List<Fruta> escribir()
        {
            try
            {
                if (File.Exists("frutas.json"))
                {
                    string jsonString = JsonSerializer.Serialize(listaFrutas);
                    File.WriteAllText("frutas.json", jsonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error escribiendo en frutas.json" + e);
            }

            return listaFrutas;
        }

        public static String construirCadenaConexion()
        {
            string databaseFileName = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\PlatanitosBD.mdf"));
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename ={databaseFileName}; Integrated Security = True";

            MessageBox.Show("Cadena de conexión: " + connectionString);
            return connectionString;
        }

        public static void insertar(Fruta f)
        {
            string query = "INSERT INTO Fruta (codigo, nombre, sabor, tipo, precio, fecha) " +
                "VALUES(@codigo, @nombre, @sabor, @tipo, @precio, @fecha)";

            using (SqlConnection connection = new SqlConnection(construirCadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", f.codigo);
                    command.Parameters.AddWithValue("@nombre", f.nombre);
                    command.Parameters.AddWithValue("@sabor", f.sabor);
                    command.Parameters.AddWithValue("@tipo", f.tipo);
                    command.Parameters.AddWithValue("@precio", f.precio);
                    command.Parameters.AddWithValue("@fecha", f.fecha.ToString());

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


            string query = "SELECT codigo, nombre, sabor, tipo, precio, fecha FROM Fruta";
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("codigo", "codigo");
            dataGridView.Columns.Add("nombre", "nombre");
            dataGridView.Columns.Add("sabor", "sabor");
            dataGridView.Columns.Add("tipo", "tipo");
            dataGridView.Columns.Add("precio", "precio");
            dataGridView.Columns.Add("fecha", "fecha");
            
            using (SqlConnection connection = new SqlConnection(construirCadenaConexion()))
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
                                dataGridView.Rows.Add(reader["codigo"].ToString(), reader["nombre"].ToString(),
                                    reader["sabor"].ToString(), reader["tipo"].ToString(),
                                    reader["precio"].ToString(), reader["fecha"].ToString());
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
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM fruta", cnn);
                    dataAdapter.Fill(dataSet);
                    dataAdapter.Dispose();
                    cnn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al recuperar frutas " + e.Message);
                }
            }
            return dataSet;
        }

        public static void actualizar(string columna, object valor, object clave)
        {
            string updateQuery = $"UPDATE Fruta SET {columna} = @newValue WHERE codigo = @primaryKeyValue";

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
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM fruta", cnn);
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
                    comando.CommandText = "DELETE FROM fruta WHERE codigo = @codigo";
                    comando.Parameters.AddWithValue("@codigo", id);

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