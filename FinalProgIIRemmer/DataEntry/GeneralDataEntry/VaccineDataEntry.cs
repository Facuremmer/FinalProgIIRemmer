using AcceptedDataFormat;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TPFinalProgII.DataEntry.GeneralDataEntry
{
    class VaccineDataEntry
    {
        public int TypeVaccineDataEntry()
        {
            int dose = -1;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Presione el número del nombre de la vacuna que desea buscar: ");
                Console.WriteLine($"1- {VaccineTypes.AstraZeneca}");
                Console.WriteLine($"2- {VaccineTypes.Moderna}");
                Console.WriteLine($"3- {VaccineTypes.Pfizer}");
                Console.WriteLine($"4- {VaccineTypes.Sinopharm}");
                Console.WriteLine($"5- {VaccineTypes.Sputnik}");

                try
                {
                    PossibleNumbers option = new PossibleNumbers();
                    dose = option.ReadPossibleOptions(new List<int>() { 1, 2, 3, 4, 5 });
                    switch (dose)
                    {
                        case 1:
                            dose = (int)VaccineTypes.AstraZeneca;
                            break;

                        case 2:
                            dose = (int)VaccineTypes.Moderna;
                            break;

                        case 3:
                            dose = (int)VaccineTypes.Pfizer;
                            break;

                        case 4:
                            dose = (int)VaccineTypes.Sinopharm;
                            break;

                        case 5:
                            dose = (int)VaccineTypes.Sputnik;
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

            return dose;
        }
    }
}
