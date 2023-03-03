using System;
using System.Data.SqlClient;

namespace ConnectionBD
{
    public class Connection
    {
        //Cadena de Conexion
        string chain = "Server=DESKTOP-OMAF4KB\\SQLEXPRESS;Database=Vaccination;Trusted_Connection= True;User Id=FacuRemmer;Password=123facu";

        public SqlConnection connectBD = new SqlConnection();

        //Constructor
        public Connection()
        {
            connectBD.ConnectionString = chain;
        }

        //Metodo para abrir la conexion
        public void Open()
        {
            try
            {
                connectBD.Open();
                Console.WriteLine("Conexion Abierta ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al abrir BD " + ex.Message);
            }
        }

        //Metodo para cerrar la conexion
        public void Close()
        {
            connectBD.Close();
        }
    }
}
