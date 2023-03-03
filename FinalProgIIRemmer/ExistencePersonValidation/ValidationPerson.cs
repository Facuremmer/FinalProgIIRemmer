using ConnectionBD;
using System;
using System.Data.SqlClient;
using TPFinalProgII.Add;
using TPFinalProgII.DataEntry.GeneralDataEntry;
using TPFinalProgII.Menus;

namespace TPFinalProgII.ExistencePersonValidation
{
    public class ValidationPerson
    {
        public long PersonValidation()
        {
            DocEntry docEnter = new DocEntry();
            long numberDoc = docEnter.EntryDNI();

            Connection connect = new Connection();
            connect.Open();

            string SQL = "SELECT count(Person.idPersonDoc) " +
                         "FROM Person " +
                         $"WHERE Person.idPersonDoc = '{numberDoc}'";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (int.Parse(reader.GetValue(0).ToString()) == 0)
                    {
                        Console.WriteLine("La persona que esta buscando nunca fue registrada, toque cualquier letra para registrarla o esc para vovler al menu principal.");
                        //Me da informacion de la tecla presionada.
                        ConsoleKeyInfo esc;
                        esc = Console.ReadKey();
                        //Si la tecla presionada es escape el if es afirmativo.
                        if (esc.Key == ConsoleKey.Escape)
                        {
                            MainMenu menu = new MainMenu();
                            menu.MainMenuNavegation();
                        }
                        else
                        {
                            AddPerson Person = new AddPerson();
                            Person.RegisteredPersons();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }

            return numberDoc;
        }
    }
}
