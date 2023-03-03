using ConnectionBD;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace TPFinalProgII.ShowInformation
{
    public class AllRegisteredPeople
    {
        public void RegisteredPersonsList()
        {
            string noPeopleRegistered = "";
            Connection connect = new Connection();
            connect.Open();
            string SQL = "SELECT Person.name, Person.surname, Person.typeDNI, Person.idPersonDoc, Person.nationality, Person.birthDate, " +
                         "Direction.province, Direction.city, Direction.postalCode, Direction.street, Direction.number, Direction.clarifications, " +
                         "Contact.personalPhone, Contact.emergencyPhone, Contact.email " +
                         "FROM Direction " +
                         "INNER JOIN Person ON Direction.idDirectionDoc = Person.directionDocId " +
                         "INNER JOIN Contact ON Person.contactDocId = Contact.idContactDoc";

            try
            {
                Console.Clear();

                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                //Intrucción que se usa para leer los datos de la base de datos.
                SqlDataReader reader = command.ExecuteReader();
                //El ciclo se hace mientras tenga datos para leer.
                while (reader.Read())
                {
                    Console.WriteLine("DATOS PERSONALES: ");
                    Console.WriteLine("Nombre: " + reader.GetValue(0).ToString());
                    Console.WriteLine("Apellido: " + reader.GetValue(1).ToString());
                    Console.WriteLine("Tipo doc: " + reader.GetValue(2).ToString());
                    Console.WriteLine("Número DNI: " + reader.GetValue(3).ToString());
                    Console.WriteLine("Nacionalidad: " + reader.GetValue(4).ToString());
                    Console.WriteLine("Fecha de nacimiento: " + reader.GetValue(5).ToString());
                    Console.WriteLine("DATOS DE DIRECCIÓN: ");
                    Console.WriteLine("Provincia: " + reader.GetValue(6).ToString());
                    Console.WriteLine("Ciudad de residencia: " + reader.GetValue(7).ToString());
                    Console.WriteLine("Código postal: " + reader.GetValue(8).ToString());
                    Console.WriteLine("Calle: " + reader.GetValue(9).ToString());
                    Console.WriteLine("Número: " + reader.GetValue(10).ToString());
                    Console.WriteLine("Aclaraciones: " + reader.GetValue(11).ToString());
                    Console.WriteLine("DATOS DE CONTACTO: ");
                    Console.WriteLine("Numero de telefono personal: " + reader.GetValue(12).ToString());
                    Console.WriteLine("Numero de telefono de emergencia: " + reader.GetValue(13).ToString());
                    Console.WriteLine("Email: " + reader.GetValue(14).ToString());
                    Console.WriteLine("");
                    noPeopleRegistered = reader.GetValue(0).ToString();
                }
                connect.Close();

                if (string.IsNullOrEmpty(noPeopleRegistered))
                {
                    Console.WriteLine("No hay ninguna persona registrada en el sistema.");
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
