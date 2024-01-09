using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PartTwo
    {
        private int[,] matrix;
        private int rows, cols;
        private int randomUpperBound = 100;

        public PartTwo()
        {
            var input = new ConsoleInputProcessing();

            Console.WriteLine("\nВведите количество строк матрицы");
            rows = input.ReadInt();
            while (rows == -1)
            {
                Console.WriteLine("Введено некорректное значение.Значение должно быть положительным целым числом!");
                rows = input.ReadInt();
            }

            Console.WriteLine("\nВведите количество столбцов матрицы");
            cols = input.ReadInt();
            while (cols == -1)
            {
                Console.WriteLine("Введено некорректное значение.Значение должно быть положительным целым числом!");
                cols = input.ReadInt();
            }

            matrix = new int[rows, cols];

            var random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = random.Next(-randomUpperBound, randomUpperBound);
            }

        }

        /*
         * Подсчет характеристики каждого столбца матрицы,
         * где характеристика это сумма модулей отрицательных нечетных элементов столбца
         */
        private KeyValuePair<int, int>[] GetCharacteristicsOfCols()
        {
            //Ключ - индекс столбца, Значение - характеристика столбца
            KeyValuePair<int, int>[] characterisctics = new KeyValuePair<int, int>[cols];

            for (int j = 0; j < cols; j++)
            {
                int currentCharacteristic = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0 && matrix[i, j] % 2 != 0) 
                        currentCharacteristic += Math.Abs(matrix[i, j]);
                }
                characterisctics[j] = new KeyValuePair<int, int>(j, currentCharacteristic);
            }

            return characterisctics;
        }

        /*Сортировка массива характеристик каждого столбца, с помощью сортировки вставками*/
        private void InsertionSort(KeyValuePair<int, int>[] characterisctics)
        {
            for(int i = 1;  i < cols; i++)
            {
                int j = i - 1;

                while(j>=0 && characterisctics[j].Value > characterisctics[j+1].Value)
                {
                    (characterisctics[j], characterisctics[j + 1]) = (characterisctics[j + 1], characterisctics[j]);
                    j--;
                }
            }
        }

        /*Перестановка столбцов матрицы, согласно росту характеристик*/
        public void AscendingCharateristicsPermutation()
        {
            //Вывод исходной матрицы
            Console.WriteLine("Исходная матрица");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(matrix[i, j] + "\t");

                Console.WriteLine();
            }

            Console.WriteLine();

            //Получение и сортировка характеристик
            KeyValuePair<int, int>[] characterisctics = GetCharacteristicsOfCols();
            InsertionSort(characterisctics);

            //Перестановка столбцов
            int[,] newMatrix = new int[rows, cols];

            for(int j = 0; j < cols; j++)
            {
                int index = j != characterisctics[j].Key ? characterisctics[j].Key : j;

                for (int i = 0; i < rows; i++)  
                    newMatrix[i,j] = matrix[i, index];

            }
            matrix = newMatrix;

            //Вывод преобразованной матрицы
            Console.WriteLine("Преобразованная матрица");
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                    Console.Write(matrix[i, j] + "\t");

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /*
         * Подсчет сумм элементов столбцов, в которых 
         * есть хотя бы один отрицательный элемент
         */
        public void SumOfColsWithNegativeElement()
        {
            
            bool containsNegative = false;

            for(int j = 0; j < cols; j++)
            {
                int sum = 0;
                for(int i = 0; i < rows; i++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < 0) containsNegative = true;
                }

                Console.Write(containsNegative ? sum + " " : "_ ");
                containsNegative = false;
            }
        }
    }
}
