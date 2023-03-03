
namespace Entities
{
    public class Vaccination
    {
        public long NumberDoc { get; set; }
        public int VaccineId { get; set; }
        public int DoseId { get; set; }
        public string Date { get; set; }

        public Vaccination(long numberDoc, int vaccineId, int doseId, string date)
        {
            NumberDoc = numberDoc;
            VaccineId = vaccineId;
            DoseId = doseId;
            Date = date;
        }
    }
}
