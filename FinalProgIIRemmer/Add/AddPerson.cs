using System;
using Entities;
using ConnectionBD;
using System.Data.SqlClient;
using System.Threading;
using TPFinalProgII.Menus;
using TPFinalProgII.DataEntry.AddDataEntry;
using TPFinalProgII.DataEntry.GeneralDataEntry;

namespace TPFinalProgII.Add
{
    public class AddPerson
    {
        public void RegisteredPersons()
        {

            long numberDoc;
            DocEntry numberDoc1 = new DocEntry();
            RecordPersonDataEntry dataPerson = new RecordPersonDataEntry();
            numberDoc = numberDoc1.EntryDNI();
            Person person;
            person = dataPerson.EnterPersonRecordData(numberDoc);

            Connection connect = new Connection();
            connect.Open();
            //El numero de documento es el id de la tabla persona, direccion y contacto.
            string sql = $"INSERT INTO Direction (idDirectionDoc,city,province,postalCode,street,number,clarifications) VALUES ('{numberDoc}','{person.Address.City}','{person.Address.Province}','{person.Address.PostalCode}','{person.Address.Street}','{person.Address.Number}','{person.Address.Clarifications}');" +
                         $"INSERT INTO Contact (idContactDoc,personalPhone,emergencyPhone,email) VALUES ('{numberDoc}','{person.ContactInformation.PersonalPhone}','{person.ContactInformation.EmergencyPhone}','{person.ContactInformation.Email}');" +
                         $"INSERT INTO Person (idPersonDoc,ContactDocId,DirectionDocId,name,surname,typeDNI,nationality,birthDate) VALUES ('{numberDoc}','{numberDoc}','{numberDoc}','{person.Name}','{person.Surname}','{person.TypeDoc}','{person.Nationality}','{person.BirthDate}');";

            try
            {
                Console.Clear();
                SqlCommand command = new SqlCommand(sql, connect.connectBD);
                command.ExecuteNonQuery();
                connect.Close();

                Console.WriteLine("Persona registrada con exito");
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
