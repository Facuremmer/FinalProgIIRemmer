using AcceptedDataFormat;
using System;
using System.Collections.Generic;
using System.Threading;
using TPFinalProgII.Delete;

namespace TPFinalProgII.Menus
{
    class DeleteMenu
    {
        public void MenuDelete()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("MENU DE REGISTRO:");
                Console.WriteLine("");
                Console.WriteLine("1- Borrar persona.");
                Console.WriteLine("2- Borrar un registro de vacunación.");
                Console.WriteLine("0- Atras.");
                try
                {
                    PossibleNumbers option = new PossibleNumbers();
                    int SelectedNumber = option.ReadPossibleOptions(new List<int>() { 1, 2, 0 });
                    switch (SelectedNumber)
                    {
                        case 1:
                            {
                                DeletePerson personDelete = new DeletePerson();
                                personDelete.PersonDelete();
                                exit = true;
                                break;
                            }
                        case 2:
                            {
                                DeleteVaccinationRecord vaccinationRecordDelete = new DeleteVaccinationRecord();
                                vaccinationRecordDelete.VaccinationRecordDelete();
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
