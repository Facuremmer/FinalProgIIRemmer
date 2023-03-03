using Entities;
using System;
using TPFinalProgII.ExistencePersonValidation;
using AcceptedDataFormat;
using TPFinalProgII.DataEntry.GeneralDataEntry;

namespace TPFinalProgII.DataEntry.AddDataEntry
{
    class RecordPersonDataEntry : RestrictionsDataEntry
    {
        public Person EnterPersonRecordData(long numberDoc)
        {
            string name, nameDataEntry, surname, surnameDataEntry, typeDNI, typeDNIDataEntry, nationality, nationalityDataEntry, birthDate;
            string  city, cityDataEntry, province, provinceDataEntry, street, streetDataEntry, clarifications;
            int postalCode, postalCodeDataEntry, numberDataEntry, number;
            string email, emailDataEntry;
            long personalPhone, personalPhoneDataEntry, emergencyPhoneDataEntry, emergencyPhone;

            Console.Clear();

            Console.WriteLine("SECCIÓN DE REGISTRO DE PERSONAS:");
            PersonExist Person = new PersonExist();
            Person.PersonExistBd(numberDoc);

            Console.Clear();
            Console.WriteLine("SECCIÓN DE REGISTRO DE PERSONAS:");
            Console.WriteLine("Ingrese los datos personales solicitados: ");

            Console.Write("Nombre: ");
            nameDataEntry = Console.ReadLine();
            name = AllowOnlyStringData(nameDataEntry);
            Console.Write("Apellido: ");
            surnameDataEntry = Console.ReadLine();
            surname = AllowOnlyStringData(surnameDataEntry);
            Console.Write("Tipo de documento: ");
            typeDNIDataEntry = Console.ReadLine();
            typeDNI = AllowOnlyStringData(typeDNIDataEntry);
            Console.Write("Nacionalidad: ");
            nationalityDataEntry = Console.ReadLine();
            nationality = AllowOnlyStringData(nationalityDataEntry);
            Console.Write("Fecha de nacimiento con el formato YYYY/MM/DD: ");
            DateDataEntry dates = new DateDataEntry();
            birthDate = dates.DatesDataEntry();

            Console.Clear();
            Console.WriteLine("SECCIÓN DE REGISTRO DE PERSONAS: ");
            Console.WriteLine("Ingrese los datos de dirección solicitados: ");
            Console.Write("Ciudad de residencia: ");
            cityDataEntry = Console.ReadLine();
            city = AllowOnlyStringData(cityDataEntry);
            Console.Write("Provincia: ");
            provinceDataEntry = Console.ReadLine();
            province = AllowOnlyStringData(provinceDataEntry);
            Console.Write("Codigo postal ");
            int.TryParse(Console.ReadLine(), out postalCodeDataEntry);
            postalCode = CancelLettersInt(postalCodeDataEntry);
            Console.Write("Calle: ");
            streetDataEntry = Console.ReadLine();
            street = AllowOnlyStringData(streetDataEntry);
            Console.Write("Numero: ");
            int.TryParse(Console.ReadLine(), out numberDataEntry);
            number =  CancelLettersInt(numberDataEntry);
            Console.Write("Aclaraciones: ");
            clarifications = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("SECCIÓN DE REGISTRO DE PERSONAS: ");
            Console.WriteLine("Ingrese los datos de contacto solicitados: ");
            Console.Write("Numero de telefono personal: ");
            long.TryParse(Console.ReadLine(), out personalPhoneDataEntry);
            personalPhone = CancelLettersLong(personalPhoneDataEntry);
            Console.Write("Numero de contacto de emergencia: ");
            long.TryParse(Console.ReadLine(), out emergencyPhoneDataEntry);
            emergencyPhone = CancelLettersLong(emergencyPhoneDataEntry);
            Console.Write("Email: ");
            emailDataEntry = Console.ReadLine();
            email = MailFormat(emailDataEntry);

            return new Person(numberDoc, name, surname, typeDNI, nationality, birthDate,
                   new Address(numberDoc, city, province, postalCode, street, number, clarifications),
                   new ContactInformation(numberDoc, personalPhone, emergencyPhone, email));
        }
    }
}
