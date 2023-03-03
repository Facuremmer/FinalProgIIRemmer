using ConnectionBD;
using Entities;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.DataEntry.AddDataEntry;
using TPFinalProgII.Menus;

namespace TPFinalProgII.Add
{
   public  class AddVaccine
   {
        public void RegisteredVaccine()
        {

            RecordVaccineDataEntry dataVaccine = new RecordVaccineDataEntry();
            Vaccination vaccination;
            vaccination = dataVaccine.EnterVaccinationRecordData();

            Connection connect = new Connection();
            connect.Open();

            string SQL2 = $"INSERT INTO VaccinationRecord (PersonId, vaccineId, doseId, date) VALUES ('{vaccination.NumberDoc}','{vaccination.VaccineId}','{vaccination.DoseId}','{vaccination.Date}')";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(SQL2, connect.connectBD);
                command.ExecuteNonQuery();
                connect.Close();

                Console.WriteLine("Vacunación registrada con exito");
                Thread.Sleep(2000);

                MainMenu menu = new MainMenu();
                menu.MainMenuNavegation();
            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }
        }
    }
}
