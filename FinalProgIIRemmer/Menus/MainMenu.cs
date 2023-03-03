using System;
using System.Collections.Generic;
using System.Threading;
using AcceptedDataFormat;

namespace TPFinalProgII.Menus
{
    public class MainMenu
    {
        public void MainMenuNavegation()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("MENU PRINCIPAL: ");
                Console.WriteLine("");
                Console.WriteLine("1- Registrar");
                Console.WriteLine("2- Buscar informacón");
                Console.WriteLine("3- Borrar");
                Console.WriteLine("0- Salir.");
                try
                {
                    PossibleNumbers option = new PossibleNumbers();
                    int SelectedNumber = option.ReadPossibleOptions(new List<int>() { 1, 2, 3, 0 });
                    switch (SelectedNumber)
                    {
                        case 1:
                            {

                                RecordMenu menu = new RecordMenu();
                                menu.MenuRecord();
                                break;
                            }
                        case 2:
                            {
                                InformationMenu menu = new InformationMenu();
                                menu.MenuInformation();
                                break;
                            }
                        case 3:
                            {

                                DeleteMenu menu = new DeleteMenu();
                                menu.MenuDelete();
                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine("Cerrando aplicacion... \nGracias por elegirnos.");
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
