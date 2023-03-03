using ConnectionBD;
using System;
using System.Data.SqlClient;

namespace TPFinalProgII.ShowInformation
{
    public class AllAppliedVaccines
    {
        public void VaccinatedPersonList()
        {
            string noPeopleVaccinated = "";
            Connection connect = new Connection();
            connect.Open();
            string SQL = "SELECT Person.name, Person.surname, Dose.dose, Vaccine.vaccine, VaccinationRecord.date " +
                         "FROM Vaccine " +
                         "INNER JOIN VaccinationRecord ON VaccinationRecord.vaccineId = Vaccine.idVaccine " +
                         "INNER JOIN Dose ON Dose.idDose = VaccinationRecord.doseId " +
                         "INNER JOIN Person ON VaccinationRecord.personId = Person.idPersonDoc";
            try
            {
                Console.Clear();

                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Nombre: " + reader.GetValue(0).ToString());
                    Console.WriteLine("Apellido: " + reader.GetValue(1).ToString());
                    Console.WriteLine("Dosis: " + reader.GetValue(2).ToString());
                    Console.WriteLine("Vacuna: " + reader.GetValue(3).ToString());
                    Console.WriteLine("Fecha de aplicación: " + reader.GetValue(4).ToString());
                    Console.WriteLine("");
                    noPeopleVaccinated = reader.GetValue(0).ToString();
                }
                connect.Close();

                if (string.IsNullOrEmpty(noPeopleVaccinated))
                {
                    Console.WriteLine("No hay ninguna persona vacunada registrada en el sistema.");
                    Console.WriteLine("");
                }
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
