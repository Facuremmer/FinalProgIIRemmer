using System;
using System.Collections.Generic;
using System.Threading;
using AcceptedDataFormat;
using TPFinalProgII.Consultations;
using TPFinalProgII.ShowInformation;

namespace TPFinalProgII.Menus
{
    class InformationMenu
    {
        public void MenuInformation()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("MENU DE BUSQUEDA DE INFORMACIÓN:");
                Console.WriteLine("");
                Console.WriteLine("1- Mostrar todas las personas registradas.");
                Console.WriteLine("2- Buscar información de una persona.");
                Console.WriteLine("3- Mostrar todas las vacunas aplicadas.");
                Console.WriteLine("4- Mostrar las dosis aplicadas a una persona.");
                Console.WriteLine("5- Buscar la cantidad de dosis aplicadas entre dos fechas.");
                Console.WriteLine("6- Buscar la cantidad de dosis aplicadas de cada tipo de vacuna.");
                Console.WriteLine("0- Atras.");
                try
                {
                    PossibleNumbers option = new PossibleNumbers();
                    int SelectedNumber = option.ReadPossibleOptions(new List<int>() { 1, 2, 3, 4, 5, 6, 0 });
                    switch (SelectedNumber)
                    {
                        case 1:
                            {
                                AllRegisteredPeople RegisteredPersons = new AllRegisteredPeople();
                                RegisteredPersons.RegisteredPersonsList();
                                break;
                            }
                        case 2:
                            {
                                CertainRegisteredPerson Person = new CertainRegisteredPerson();
                                Person.SpecifyPersonList();
                                break;
                            }
                        case 3:
                            {
                                AllAppliedVaccines VaccinatedPerson = new AllAppliedVaccines();
                                VaccinatedPerson.VaccinatedPersonList();
                                break;
                            }
                        case 4:
                            {
                                CertainVaccinatedPerson Person = new CertainVaccinatedPerson();
                                Person.SpecifyVaccinatedPersonList();
                                break;
                            }
                        case 5:
                            {
                                DosesAppliedBetweenDates DosesApplied = new DosesAppliedBetweenDates();
                                DosesApplied.DosesAppliedBetweenTowDates();
                                break;
                            }
                        case 6:
                            {
                                DosisApliedType TotalDosesApplied = new DosisApliedType();
                                TotalDosesApplied.TotalDosesAppliedOfEachType();
                                break;
                            }
                        case 0:
                            {
                                MainMenu menu = new MainMenu();
                                menu.MainMenuNavegation();
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("La opcion ingresada no es valida, intentelo devuelta en unos segundos.");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
