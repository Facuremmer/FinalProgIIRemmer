using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.Menus;

namespace TPFinalProgII.ExistenceVaccinationValidation
{
    class DoseVaccinationExist
    {
        public void DoseExistBd(long numberDoc, int dose)
        {
            Connection connect = new Connection();
            connect.Open();

            string SQL = "SELECT count(VaccinationRecord.doseId) " +
                         "FROM VaccinationRecord " +
                         $"WHERE VaccinationRecord.personId = '{numberDoc}' AND VaccinationRecord.doseId = {dose} ";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (int.Parse(reader.GetValue(0).ToString()) == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"La persona con el DNI {numberDoc} ya tiene una dosis {dose} registrada en el sistema.");
                        connect.Close();
                        Thread.Sleep(4000);

                        MainMenu menu = new MainMenu();
                        menu.MainMenuNavegation();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }
        }
    }
}
