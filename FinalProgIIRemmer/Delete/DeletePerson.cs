using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.ExistencePersonValidation;
using TPFinalProgII.Menus;

namespace TPFinalProgII.Delete
{
    class DeletePerson
    {
        public void PersonDelete()
        {
            long numberDoc;
            ValidationPerson person = new ValidationPerson();
            numberDoc = person.PersonValidation();

            Console.WriteLine($"¿Esta seguro que desea eliminar la persona con el documento: {numberDoc}?");
            Console.WriteLine("Si lo hace se eliminaran todos los datos relacionados a esa persona, incluidas las vacunas registradas a su nombre.");
            Console.WriteLine("Para confirmar la operacion presione  cualquier tecla, para cancelar precione ESC.");

            ConsoleKeyInfo esc;
            esc = Console.ReadKey();
            //Si la tecla presionada es escape el if es afirmativo.
            if (esc.Key == ConsoleKey.Escape)
            {
                MainMenu menu = new MainMenu();
                menu.MainMenuNavegation();
            }

            Connection connect = new Connection();
            connect.Open();
            //El numero de documento es el id de la tabla persona, direccion y contacto.
            string sql = $"DELETE FROM VaccinationRecord WHERE personId = '{numberDoc}' " +
                         $"DELETE FROM Person WHERE  idPersonDoc = '{numberDoc}' " +
                         $"DELETE FROM Direction WHERE  idDirectionDoc = '{numberDoc}' " +
                         $"DELETE FROM Contact WHERE  idContactDoc = '{numberDoc}'";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(sql, connect.connectBD);
                command.ExecuteNonQuery();
                connect.Close();

                Console.WriteLine("Persona eliminada con exito.");
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
        
