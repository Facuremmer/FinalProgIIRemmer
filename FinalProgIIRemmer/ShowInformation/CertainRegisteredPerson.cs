using ConnectionBD;
using System;
using System.Data.SqlClient;
using TPFinalProgII.ExistencePersonValidation;

namespace TPFinalProgII.ShowInformation
{
    public class CertainRegisteredPerson
    {
        public void SpecifyPersonList()
        {
            ValidationPerson person = new ValidationPerson();
            long numberDoc = person.PersonValidation();


            Connection connect = new Connection();
            connect.Open();

            string SQL = "SELECT Person.name, Person.surname, Person.typeDNI, Person.idPersonDoc, Person.nationality, Person.birthDate, " +
                         "Direction.province, Direction.city, Direction.postalCode, Direction.street, Direction.number, Direction.clarifications, " +
                         "Contact.personalPhone, Contact.emergencyPhone, Contact.email " +
                         "FROM Direction " +
                         "INNER JOIN Person ON Direction.idDirectionDoc = Person.directionDocId " +
                         "INNER JOIN Contact ON Person.contactDocId = Contact.idContactDoc " +
                         $"WHERE Direction.idDirectionDoc = '{numberDoc}'";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(SQL, connect.connectBD);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Nombre: " + reader.GetValue(0).ToString());
                    Console.WriteLine("Apellido: " + reader.GetValue(1).ToString());
                    Console.WriteLine("Tipo doc: " + reader.GetValue(2).ToString());
                    Console.WriteLine("Número DNI: " + reader.GetValue(3).ToString());
                    Console.WriteLine("Nacionalidad: " + reader.GetValue(4).ToString());
                    Console.WriteLine("Fecha de nacimiento: " + reader.GetValue(5).ToString());
                    Console.WriteLine("");
                    Console.WriteLine("Dirección: ");
                    Console.WriteLine("Provincia: " + reader.GetValue(6).ToString());
                    Console.WriteLine("Ciudad de residencia: " + reader.GetValue(7).ToString());
                    Console.WriteLine("Código postal: " + reader.GetValue(8).ToString());
                    Console.WriteLine("Calle: " + reader.GetValue(9).ToString());
                    Console.WriteLine("Número: " + reader.GetValue(10).ToString());
                    Console.WriteLine("Aclaraciones: " + reader.GetValue(11).ToString());
                    Console.WriteLine("");
                    Console.WriteLine("Datos de contacto: ");
                    Console.WriteLine("Número de telefono personal: " + reader.GetValue(12).ToString());
                    Console.WriteLine("Número de telefono de emergencia: " + reader.GetValue(13).ToString());
                    Console.WriteLine("Email: " + reader.GetValue(14).ToString());
                    Console.WriteLine("");
                }
                connect.Close();
                Console.WriteLine("Presione cualquier tecla para volver al menu anterior.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Error al ejecutar");
            }
        }
    }
}
