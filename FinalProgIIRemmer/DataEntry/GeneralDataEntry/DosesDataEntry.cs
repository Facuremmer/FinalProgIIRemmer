using AcceptedDataFormat;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TPFinalProgII.DataEntry.GeneralDataEntry
{
    class DosesDataEntry
    {
        public int DoseDataEntry()
        {
            int vaccine = -1;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Presione el número que muestre la dosis que desea: ");
                Console.WriteLine($"1- {NumberDose.Primera}");
                Console.WriteLine($"2- {NumberDose.Segunda}");
                Console.WriteLine($"3- {NumberDose.Tercera}");
                Console.WriteLine($"4- {NumberDose.Cuarta}");
                Console.WriteLine($"5- {NumberDose.Quinta}");
                Console.WriteLine($"6- {NumberDose.Sexta}");

                try
                {
                    PossibleNumbers option = new PossibleNumbers();
                    vaccine = option.ReadPossibleOptions(new List<int>() { 1, 2, 3, 4, 5, 6});
                    switch (vaccine)
                    {
                        case 1:
                            vaccine = (int)VaccineTypes.AstraZeneca;
                            break;

                        case 2:
                            vaccine = (int)VaccineTypes.Moderna;
                            break;

                        case 3:
                            vaccine = (int)VaccineTypes.Pfizer;
                            break;

                        case 4:
                            vaccine = (int)VaccineTypes.Sinopharm;
                            break;

                        case 5:
                            vaccine = (int)VaccineTypes.Sputnik;
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No se pueden ingresar letras, solo número del 1 al 5, por favor vuelva a intentarlo en unos segundos.");
                    Thread.Sleep(2000);
                }
                break;
            }

            return vaccine;
        }
    }
}
