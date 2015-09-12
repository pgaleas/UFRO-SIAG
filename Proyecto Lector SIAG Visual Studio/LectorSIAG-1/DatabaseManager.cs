using System;
using System.Xml;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using WindowsFormsApplication1.Properties;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    class DatabaseManager
    {

        //private OleDbConnection diagnosticoConn;
        private OleDbCommand oleDbCmd = new OleDbCommand();
        //private String connParam;

        //        private SqlConnection sqlConnection;
        //      private String connetion;
        private String connectionStringMysql;
        private String table;


        public DatabaseManager()
        {

            //Variables de conexión a base de datos leidas desde el archivo
            //.config leido desde el directorio "bin/release"

            string server = ConfigurationManager.AppSettings["server"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string uid = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            this.table = ConfigurationManager.AppSettings["table"].ToString();
           
            this.connectionStringMysql = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }

        //Revisa en la base de datos si se encuentra el registro
        private bool verifyData(String rut, String folio, Visualizador visualizador)
        {
            bool salida = true;
            string query1 = "select rut, folio from " + this.table + " where rut='" + rut + "';";
            string query2 = "select rut, folio from " + this.table + " where folio='" + folio + "';";
            string query3 = "select rut, folio from " + this.table + " where rut='" + rut + "' and folio='" + folio + "';";
            Console.WriteLine(query1);
            Console.WriteLine(query2);
            Console.WriteLine(query3);
            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionStringMysql);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query3, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();

                //Si el rut se encuentra ingresado en la base de datos con el mismo folio
                if (reader.HasRows)
                {
                    visualizador.updateStatus(2, "El RUT " + rut + " ya tiene asignado el FOLIO" + folio);
                    salida = false;
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    cmd.CommandText = query1;
                    reader = cmd.ExecuteReader();
                    cmd.Dispose();

                    //Si el rut se encuentra ingresado en la base de datos con diferente folio
                    if (reader.HasRows)
                    {
                        reader.Read();
                        visualizador.updateStatus(2, "El RUT " + rut + " posee otro FOLIO: " + reader.GetString(1));
                        salida = false;
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();
                        cmd.CommandText = query2;
                        reader = cmd.ExecuteReader();
                        cmd.Dispose();

                        //Si el folio ingresado se encuentra registrado a otro rut en la base de datos
                        if (reader.HasRows)
                        {
                            reader.Read();
                            visualizador.updateStatus(2, "El FOLIO " + folio + " pertenece a otro RUT: " + reader.GetString(0));
                            salida = false;
                            reader.Close();
                        }
                        else
                            //Si esta todo ok al ingresar un nuevo registro
                        {
                            salida = true;
                            reader.Close();
                        }
                    }
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                visualizador.updateStatus(2, "error " + e.Message);
                salida = false;
                MessageBox.Show(e.Message);
            }


            return salida;
        }

        //Guarda el registro en la base de datos
        public bool saveRegisterMySql(BarcodeDataObject bObject, Visualizador visualizador)
        {
            string query = "insert into " + this.table + " (rut, nombre_estudiante, folio, num_serie_lector) values ('" + bObject.Rut + "','" + bObject.StudentName + "','" + bObject.ResponseFormId + "','" + bObject.ReaderSerial + "');";
            if (verifyData(bObject.Rut, bObject.ResponseFormId, visualizador))
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection(this.connectionStringMysql);
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                    visualizador.updateStatus(1, "RUT:" + bObject.Rut + " (" + bObject.StudentName + ") - FOLIO: " + bObject.ResponseFormId + "    .... fueron guardados exitosamente");
                }
                catch (Exception e)
                {
                    visualizador.updateStatus(2, "ERROR: Error al guardar los datos");
                    MessageBox.Show(e.Message);
                }
            }
            return true;
        }


        //Buscar registro por rut en la base de datos
        public String[] buscarPorRut(String rut)
        {
            String[] datos = new String[3];
            string query = "select rut,nombre_estudiante,folio from " + this.table + " where rut='" + rut + "';";
            Console.WriteLine(query);
                     
            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionStringMysql);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        datos[i] = reader.GetValue(i).ToString();
                    }
                    
                }
                reader.Close();
                connection.Close();
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //Si encuentra el registro asociado a un rut
            if (rut == datos[0])
            {
                return datos;
            }
            //Si no encuentra el registro
            else
            {
                String[] datos2={"","",""};
                MessageBox.Show("El rut no se encuentra ingresado");
                return datos2;
            }
            
        }

        //Cristofer
        //Buscar registro por folio en la base de datos
        public String[] buscarPorFolio(String folio)
        {
            String[] datos = new String[3];
            string query = "select rut,nombre_estudiante,folio from " + this.table + " where folio='" + folio + "';";
            Console.WriteLine(query);

            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionStringMysql);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        datos[i] = reader.GetValue(i).ToString();
                    }

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //Si encuentra los datos asociados al folio
            if (folio == datos[2])
            {
                return datos;
            }
            //Si no encuentra los datos asociados al folio
            else 
            {
                String[] datos2 = { "", "", "" };
                MessageBox.Show("El folio no se encuentra ingresado");
                return datos2;
            }

        }

        //Eliminar registro de la base de datos
        public void ElimRegistro(String rut)
        {
            string query = "delete from " + this.table + " where rut='" + rut + "';";
            Console.WriteLine(query);
            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionStringMysql);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                connection.Close();
                MessageBox.Show("Registro eliminado con exito.");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /* Guarda el registro completo de los dos codigos de barra en la base de datos sql server 
        public bool saveRegisterSqlServer(BarcodeDataObject bObject)
        {
            try
            {
                DateTime today = DateTime.Now;
                string todayString = today.ToString();

                SqlCommand identChange = sqlConnection.CreateCommand();
                identChange.CommandText = "SET IDENTITY_INSERT dbo.diagnostico.ID ON";
                sqlConnection.Open();
                string commtext = @"Insert INTO dbo.diagnostico (dataDate, readerSerial, rut, studentName, responseFormId)
                       SELECT @dataDate, @readerSerial, @rut, @studentName, @responseFormId";
                SqlCommand comm = new SqlCommand(commtext, sqlConnection);

                comm.Parameters.AddWithValue("@dataDate", todayString);
                comm.Parameters.AddWithValue("@readerSerial", bObject.ReaderSerial);
                comm.Parameters.AddWithValue("@rut", bObject.Rut);
                comm.Parameters.AddWithValue("@studentName", bObject.StudentName);
                comm.Parameters.AddWithValue("@responseFormId", bObject.ResponseFormId);

                identChange.ExecuteNonQuery();
                comm.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        */

        /* Guarda el registro completo de los dos codigos de barra en la base de datos access 
        public bool saveRegister(BarcodeDataObject bObject)
        {
            diagnosticoConn.Open();
            oleDbCmd.Connection = diagnosticoConn;

            DateTime today = DateTime.Now;
            string todayString = today.ToString();
            string sqlString = "insert into diagnostico (dataDate, readerSerial, rut, studentName, responseFormId) values ('" + todayString + "','" + bObject.ReaderSerial + "','" + bObject.Rut + "','" + bObject.StudentName + "','" + bObject.ResponseFormId + "');";


            oleDbCmd.CommandText = sqlString;
            int temp = oleDbCmd.ExecuteNonQuery();
            if (temp > 0)
            {
                diagnosticoConn.Close();
                return true; //MessageBox.Show("Record Successfuly Added");
            }
            else
            {
                diagnosticoConn.Close();
                return false; // MessageBox.Show("Record Fail to Added");
            }
            
        }
        */

        /* Lee los n-últimos registros ingresados a la base de datos */
        //Actualiza la lista registros en la tabla de la pantalla
        public bool readLastRegisters(DataGridView dataGridView)
        {
            try
            {
                //create the database query
                string query = "SELECT Id, fecha, rut, nombre_estudiante, folio FROM " + this.table + " ORDER BY Id DESC";

                //create an OleDbDataAdapter or MySqlDataAdapter to execute the query
                MySqlDataAdapter dAdapter = new MySqlDataAdapter(query, this.connectionStringMysql);
                
                //create a command builder OleDbCommandBuilder or MySqlCommandBuilder
                MySqlCommandBuilder cBuilder = new MySqlCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();

                //fill the DataTable
                dAdapter.Fill(dTable);

                //the DataGridView
                //DataGridView dgView = new DataGridView();

                //BindingSource to sync DataTable and DataGridView
                BindingSource bSource = new BindingSource();

                //set the BindingSource DataSource
                bSource.DataSource = dTable;

                //set the DataGridView DataSource
                //dataGridView.DataSource = bSource;

                /*Cristofer: Aqui el programa trata de cargar la tabla
                 * en el Visual Studio funciona, pero en el .exe no*/
                try
                {
                    WindowsFormsApplication1.Visualizador.ActiveForm.Invoke((MethodInvoker)delegate { dataGridView.DataSource = bSource; });
                }
                catch (NullReferenceException e)
                {
                    //MessageBox.Show("Error al iniciar la primera copia de la tabla en DatabaseManager, realLastRegister");
                }

                return true;
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Error conexion base de datos. Error: "+e.ToString());
                
                return false;
            }
            
        }




    }
}
