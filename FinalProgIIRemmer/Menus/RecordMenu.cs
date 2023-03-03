using System;
using System.Collections.Generic;
using System.Threading;
using TPFinalProgII.Add;
using AcceptedDataFormat;

namespace TPFinalProgII.Menus
{
    class RecordMenu
    {
        public void MenuRecord()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("MENU DE REGISTRO:");
                Console.WriteLine("");
                Console.WriteLine("1- Registrar nueva persona.");
                Console.WriteLine("2- Registrar nueva vacuna.");
                Console.WriteLine("0- Atras.");
                try
                {
                    PossibleNumbers option = new PossibleNumbers();
                    int SelectedNumber = option.ReadPossibleOptions(new List<int>() { 1, 2, 3, 4, 0 });
                    switch (SelectedNumber)
                    {
                        case 1:
                            {
                                AddPerson Person = new AddPerson();
                                Person.RegisteredPersons();
                                exit = true;
                                break;
                            }
                        case 2:
                            {
                                AddVaccine newVaccine = new AddVaccine();
                                newVaccine.RegisteredVaccine();
                                exit = true;
                                break;
                            }
                        case 0:
                            {
                                MainMenu menu = new MainMenu();
                                menu.MainMenuNavegation();
                                exit = true;
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
