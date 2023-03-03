using System;
using AcceptedDataFormat;

namespace TPFinalProgII.DataEntry.GeneralDataEntry
{
    class DocEntry : RestrictionsDataEntry
    {
        public long EntryDNI()
        {
            long numberDoc;
            Console.Clear();
            Console.Write("Ingrese el DNI de la persona: ");
            long.TryParse(Console.ReadLine(), out long numberDoc1);
            numberDoc = CancelLettersLong(numberDoc1);
            return numberDoc;
        }
    }
}
