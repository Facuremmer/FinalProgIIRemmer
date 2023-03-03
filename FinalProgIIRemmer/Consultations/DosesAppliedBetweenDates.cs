using ConnectionBD;
using System;
using System.Data.SqlClient;
using TPFinalProgII.DataEntry.GeneralDataEntry;

namespace TPFinalProgII.Consultations
{
    class DosesAppliedBetweenDates
    {
        public void DosesAppliedBetweenTowDates()
        {
            string date1, date2;
            int hola;

            Console.Clear();
            Console.WriteLine("Ingrese la primer fecha con el formato YYYY/MM/DD: ");
            DateDataEntry dates = new DateDataEntry();
            date1 = dates.DatesDataEntry();
            Console.WriteLine("Ingrese la segunda fecha con el formato YYYY/MM/DD: ");
            date2 = dates.DatesDataEntry();

            Connection connect = new Connection();
            connect.Open();
            string SQL = "SELECT count(VaccinationRecord.date) " +
                         "FROM VaccinationRecord " +
                         $"WHERE VaccinationRecord.date BETWEEN '{date1}' and '{date2}'";
            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("La cantidad de dosis aplicadas entre esas dos fechas es: " + reader.GetValue(0).ToString());
                    Console.WriteLine("");
                }
                connect.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }

            Console.WriteLine("Presione cualquier tecla para volver al menu anterior");
            Console.ReadKey();
        }
    }
}
