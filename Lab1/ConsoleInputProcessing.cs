using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ConsoleInputProcessing
    {
        /*
         * Считывание значения с консоли и проверка на 
         * конвертируемость его в целое положительное число
         */
        public int ReadInt()
        {
            Console.Write(">>");
            string temp = Console.ReadLine();

            if (!int.TryParse(temp, out int value) || value < 1)
            {
                return -1;
            }

            return value;
        } 
    }
}
