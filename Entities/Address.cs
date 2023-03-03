
namespace Entities
{
    public class Address
    {
        public long NumberDoc { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Clarifications { get; set; }

        public Address(long numberDoc, string city, string province, int postalCode, string street,
                      int number, string clarifications)
        {
            NumberDoc = numberDoc;
            City = city;
            Province = province;
            PostalCode = postalCode;
            Number = number;
            Street = street;
            Number = number;
            Clarifications = clarifications;
        }
    }
}

