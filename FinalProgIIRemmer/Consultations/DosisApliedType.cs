using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.DataEntry.GeneralDataEntry;

namespace TPFinalProgII.Consultations
{
    public class DosisApliedType
    {
        public void TotalDosesAppliedOfEachType()
        {
            int notVaccine = 0;
            int vaccine;
            VaccineDataEntry vaccineSelected = new VaccineDataEntry();
            vaccine = vaccineSelected.TypeVaccineDataEntry();

            Connection connect = new Connection(); 
            connect.Open();

            string SQL = "SELECT Vaccine.vaccine, count(VaccinationRecord.vaccineId) " +
                          "FROM VaccinationRecord " +
                          "INNER JOIN Vaccine ON VaccinationRecord.vaccineId = Vaccine.idVaccine " +
                          $"WHERE VaccinationRecord.vaccineId = '{vaccine}' " +
                          "GROUP BY(Vaccine.vaccine)";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("La cantidad de dosis aplicadas de " + reader.GetValue(0).ToString() + " son: " + reader.GetValue(1).ToString());
                    Console.WriteLine("");
                    Console.WriteLine("Presione cualquier tecla para volver al menu anterior");
                    Console.ReadKey();
                    notVaccine = int.Parse(reader.GetValue(0).ToString());
                }
                connect.Close();

                if (notVaccine == 0)
                {
                    Console.WriteLine("No se aplicaron dosis de esa vacuna.");
                    Thread.Sleep(2000);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }
        }
    }
}
