
namespace Entities
{
    public class Person
    {
        public long NumberDoc { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TypeDoc { get; set; }
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public Address Address { get; set; }
        public ContactInformation ContactInformation { get; set; }

        public Person(long numberDoc, string name, string surname, string typeDoc, string nationality, string birthDate,
               Address address,
               ContactInformation contactInformation)
        {
            NumberDoc = numberDoc;
            Name = name;
            Surname = surname;
            TypeDoc = typeDoc;
            Nationality = nationality;
            BirthDate = birthDate;
            ContactInformation = contactInformation;
            Address = address;
        }
    }
}
