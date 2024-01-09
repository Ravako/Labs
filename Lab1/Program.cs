using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть #1");
            var partOne = new PartOne();

            Console.WriteLine("\nИндекс минимального элемента массива: " + partOne.GetMinElementIndex());
            Console.WriteLine();
            Console.WriteLine("Сумма элементов между первыми двумя отрицательными элементами: " + partOne.GetSumBetweenFirstNegatives());
            Console.WriteLine();
            partOne.ArrayPermutation();
            Console.WriteLine();


            Console.WriteLine("Часть #2");
            var partTwo = new PartTwo();

            Console.WriteLine("\nПерестановка столбцов матрицы, согласно росту характеристик столбцов\n");
            partTwo.AscendingCharateristicsPermutation();
            Console.WriteLine();
            Console.WriteLine("Суммы элементов столбцов, содержащих хотя бы один отрицательный элемент:");
            partTwo.SumOfColsWithNegativeElement();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
