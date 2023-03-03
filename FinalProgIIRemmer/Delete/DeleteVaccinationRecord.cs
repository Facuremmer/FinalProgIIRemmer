using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.DataEntry.GeneralDataEntry;
using TPFinalProgII.ExistencePersonValidation;
using TPFinalProgII.ExistenceVaccinationValidation;
using TPFinalProgII.Menus;

namespace TPFinalProgII.Delete
{
    class DeleteVaccinationRecord
    {
        public void VaccinationRecordDelete()
        {
            int deleteDose;
            long numberDoc;
            ValidationPerson person = new ValidationPerson();
            numberDoc = person.PersonValidation();

            DosesDataEntry deleteDose1 = new DosesDataEntry();
            deleteDose = deleteDose1.DoseDataEntry();

            DoseValidationNoExist validationDose = new DoseValidationNoExist();
            validationDose.DoseNoExistBd(numberDoc, deleteDose);

            Console.WriteLine($"¿Esta seguro que desea borrar la dosis número: {deleteDose} de la persona con el documento: {numberDoc}?");
            Console.WriteLine("Para confirmar la operacion presione cualquier tecla, para cancelar precione ESC.");

            ConsoleKeyInfo esc;
            esc = Console.ReadKey();
            if (esc.Key == ConsoleKey.Escape)
            {
                MainMenu menu = new MainMenu();
                menu.MainMenuNavegation();
            }

            Connection connect = new Connection();
            connect.Open();

            string sql = $"DELETE FROM VaccinationRecord WHERE personId = '{numberDoc}' AND vaccineId = '{deleteDose}'";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(sql, connect.connectBD);
                command.ExecuteNonQuery();
                connect.Close();

                Console.WriteLine("Registro de vacunación borrado con exito.");
                Thread.Sleep(2000);

                MainMenu menu = new MainMenu();
                menu.MainMenuNavegation();

            }

            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar.");
            }
        }
    }
}
