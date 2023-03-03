
namespace Entities
{
    public class ContactInformation
    {
        public long NumberDoc { get; set; }
        public long PersonalPhone { get; set; }
        public long EmergencyPhone { get; set; }
        public string Email { get; set; }

        public ContactInformation(long numberDoc, long personalPhone, long emergencyPhone, string email)
        {
            NumberDoc = numberDoc;
            PersonalPhone = personalPhone;
            EmergencyPhone = emergencyPhone;
            Email = email;
        }
    }
}
