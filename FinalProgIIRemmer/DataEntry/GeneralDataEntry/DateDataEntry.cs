using System;
using AcceptedDataFormat;

namespace TPFinalProgII.DataEntry.GeneralDataEntry
{
    class DateDataEntry : RestrictionsDataEntry
    {
        public string DatesDataEntry()
        {
            string date, date1;

            date1 = Console.ReadLine();
            date = DateFormat(date1);
            return date;
        }
    }
}
