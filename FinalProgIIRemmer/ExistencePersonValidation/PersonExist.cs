using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.Menus;

namespace TPFinalProgII.ExistencePersonValidation
{
    class PersonExist
    {
        public long PersonExistBd(long numberDoc)
        {
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
                    if (int.Parse(reader.GetValue(0).ToString()) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("El DNI igresado pertenese a una persona ya registarda en el sistema, en unos segundo será redirigido al menu principal.");
                        Thread.Sleep(4000);
                        connect.Close();
                        MainMenu menu = new MainMenu();
                        menu.MainMenuNavegation();
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
