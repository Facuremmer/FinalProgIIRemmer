using Entities;
using System;
using TPFinalProgII.DataEntry.GeneralDataEntry;
using TPFinalProgII.ExistencePersonValidation;
using TPFinalProgII.ExistenceVaccinationValidation;

namespace TPFinalProgII.DataEntry.AddDataEntry
{
    class RecordVaccineDataEntry
    {
        public Vaccination EnterVaccinationRecordData()
        {
            int appliedVaccine, appliedDose;
            string date;
            long numberDoc;

            DosesDataEntry dose = new DosesDataEntry();
            appliedDose = dose.DoseDataEntry();

            ValidationPerson person = new ValidationPerson();
            numberDoc = person.PersonValidation();

            DoseVaccinationExist doseValidation = new DoseVaccinationExist();
            doseValidation.DoseExistBd(numberDoc, appliedDose);

            VaccineDataEntry vaccine = new VaccineDataEntry();
            appliedVaccine = vaccine.TypeVaccineDataEntry();

            Console.Clear();
            Console.Write("Fecha de la vacunación con el formato YYYY/MM/DD: ");
            DateDataEntry dates = new DateDataEntry();
            date = dates.DatesDataEntry();

            return new Vaccination(numberDoc, appliedVaccine, appliedDose, date);
        }
    }
}

