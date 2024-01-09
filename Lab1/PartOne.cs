using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PartOne
    {
        private int[] array;
        private int arraySize;
        private int randomUpperBound = 100;
        
        public PartOne()
        {
            var input = new ConsoleInputProcessing();

            Console.WriteLine("Введите размер массива");
            arraySize = input.ReadInt();
            while (arraySize == -1) {
                Console.WriteLine("Введено некорректное значение. Размер массива должен быть положительным целым числом!");
                arraySize = input.ReadInt();
            }

            array = new int[arraySize];

            var random = new Random();

            for(int i = 0; i < arraySize; i++)          
                array[i] = random.Next(-randomUpperBound, randomUpperBound);
            
        }

        /*Поиск индекса минимального элемента*/
        public int GetMinElementIndex()
        {
            int minIndex = 0;
            for(int i = 1; i < arraySize; i++)
                if (array[i] < array[minIndex]) minIndex = i;

            return minIndex;
        }

        /*
         * Поиск суммы элементов, расположенных между первым 
         * и вторым отрицательными элементами в массиве*/
        public int GetSumBetweenFirstNegatives()
        {
            int sum = 0;
            bool isBetweenNegatives = false;
            for( int i = 0; i < arraySize; i++)
            {
                if (isBetweenNegatives)
                {
                    if (array[i] < 0) break;
                    sum += array[i];
                }

                if (array[i] < 0) isBetweenNegatives = true;       
            }
            return sum;
        }

        /*
         * Перестановка элементов массива, при которой элементы, 
         * модуль которых меньше 1 передвигаются в начало
         */
        public void ArrayPermutation()
        {
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < arraySize; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine();

            //В параметер функции лямбда выражение с тернарным оператором
            array = array.OrderBy(elem => Math.Abs(elem) < 1 ? 0 : 1).ToArray();

            Console.WriteLine("\nПреобразованный массив:");
            for (int i = 0; i < arraySize; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine();
        }

    }
}
