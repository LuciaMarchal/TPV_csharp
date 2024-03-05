using ProyectoTrimestral.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ProyectoTrimestral.Controladores
{
    public static class ControladorRecibo
    {
        public static List<Recibo> listaRecibos = new List<Recibo>();

        public static void leer()
        {
            if (File.Exists("recibos.txt"))
            {
                using (StreamReader lector = new StreamReader("recibos.txt"))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(',');

                        if (partes.Length == 4)
                        {
                            Recibo recibo = new Recibo(
                                partes[0],
                                partes[1],
                                float.Parse(partes[2]),
                                DateTime.Parse(partes[3])
                            );
                            listaRecibos.Add(recibo);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo recibos.txt no existe.");
            }
        }

        public static void escribir()
        {
            // Usa FileMode.Append para abrir el archivo en modo de añadir (append)
            using (StreamWriter escritor = new StreamWriter("recibos.txt", true))
            {
                foreach (var recibo in listaRecibos)
                {
                    escritor.WriteLine($"{recibo.correo},{recibo.metodoPago},{recibo.total},{recibo.fecha}");
                }
            }

            Console.WriteLine("Recibos escritos en el archivo.");

        }

        public static String construirCadenaConexion()
        {
            string databaseFileName = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\PlatanitosBD.mdf"));
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename ={databaseFileName}; Integrated Security = True";

            MessageBox.Show("Cadena de conexión: " + connectionString);
            return connectionString;
        }

        public static void insertar(Recibo r)
        {
            string query = "INSERT INTO Recibo (correo, metodo_pago, total, fecha) " +
                "VALUES(@correo, @metodo_pago, @total, @fecha)";

            using (SqlConnection connection = new SqlConnection(construirCadenaConexion()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", r.correo);
                    command.Parameters.AddWithValue("@metodo_pago", r.metodoPago);
                    command.Parameters.AddWithValue("@total", r.total);
                    command.Parameters.AddWithValue("@fecha", r.fecha);

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

            string query = "SELECT * FROM Recibo";

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("correo", "Correo");
            dataGridView.Columns.Add("metodo_pago", "Método de Pago");
            dataGridView.Columns.Add("total", "Total");
            dataGridView.Columns.Add("fecha", "Fecha");

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
                                dataGridView.Rows.Add(reader["correo"].ToString(), reader["metodo_pago"].ToString(),
                                    reader["total"].ToString(), reader["fecha"].ToString());
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

                    DateTime hoy = DateTime.Today;
                    DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                    DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

                    string consultaSQL = "SELECT * FROM Recibo WHERE fecha " +
                                         "BETWEEN @primerDiaDelMes AND @ultimoDiaDelMes";

                    SqlCommand cmd = new SqlCommand(consultaSQL, cnn);
                    cmd.Parameters.AddWithValue("@primerDiaDelMes", primerDiaDelMes);
                    cmd.Parameters.AddWithValue("@ultimoDiaDelMes", ultimoDiaDelMes);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataSet);
                    dataAdapter.Dispose();
                    cnn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al recuperar recibos " + e.Message);
                }
            }
            return dataSet;
        }


    }
}

