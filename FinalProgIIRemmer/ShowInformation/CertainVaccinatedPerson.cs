using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.ExistencePersonValidation;
using TPFinalProgII.Menus;

namespace TPFinalProgII.ShowInformation
{
    public class CertainVaccinatedPerson
    {
        public void SpecifyVaccinatedPersonList()
        {
            string unvaccinatedPerson = "";

            ValidationPerson person = new ValidationPerson();
            long numberDoc = person.PersonValidation();

            Connection connect = new Connection();
            connect.Open();
            string SQL = "SELECT Person.name, Person.surname, Dose.dose, Vaccine.vaccine, VaccinationRecord.date " +
                         "FROM Vaccine " +
                         "INNER JOIN VaccinationRecord ON VaccinationRecord.vaccineId = Vaccine.idVaccine " +
                         "INNER JOIN Dose ON Dose.idDose = VaccinationRecord.doseId " +
                         "INNER JOIN Person ON VaccinationRecord.personId = Person.idPersonDoc " +
                         $"WHERE Person.idPersonDoc = '{numberDoc}'";

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
                    unvaccinatedPerson = reader.GetValue(0).ToString();
                }
                connect.Close();

                if (string.IsNullOrEmpty(unvaccinatedPerson))
                {
                    Console.WriteLine("La persona que esta buscando nunca fue vacunada, en unos segundo será redirigido al menu principal.");
                    Thread.Sleep(2000);
                    MainMenu menu = new MainMenu();
                    menu.MainMenuNavegation();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }

            Console.WriteLine("");
            Console.WriteLine("Presione cualquier tecla para volver al menu anterior");
            Console.ReadKey();
        }
    }
}
