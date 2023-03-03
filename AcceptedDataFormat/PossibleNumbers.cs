using System;
using System.Collections.Generic;

namespace AcceptedDataFormat
{
    public class PossibleNumbers
    {
        //Si la opcion elegida no esta en la lista de posibilidades, bloquea todo otro tipo de ingreso.
        public int ReadPossibleOptions(List<int> possibleOptions)
        {
            int selected = -1;
            while (!possibleOptions.Contains(selected))
            {
                selected = int.Parse(Console.ReadKey(true).KeyChar.ToString());
            }
            return selected;
        }
    }
}
