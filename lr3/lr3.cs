using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace lr3
{
    internal class Lr3 : SupportForLr3
    {
        public void task1()
        {
            Console.WriteLine("введите кол-во элементов массива ");
            int arraySize = int.Parse(Console.ReadLine());
            int[] array = new int[arraySize];
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(-30, 46);
            }
            Console.WriteLine("\nсгенерировать массив ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"{array[i],4}");
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("\nположительные элементы массива в обратном порядке");
            for (int i = arraySize - 1; i >= 0; i--)
            {
                if (array[i] > 0)
                {
                    Console.WriteLine($"{array[i],4}.");
                }
            }
            Console.WriteLine();
        }
        public void task2()
        {
            int size = 7;
            int[,] matrix = new int[size, size];
            int counter = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = counter++;
                }
            }
            Console.WriteLine("оригинальный массив");
            PrintMatrix(matrix);
            RotateMatrix90Degrees(matrix);
            Console.WriteLine("\nмассив после поворота на 90 градусов вправо");
            PrintMatrix(matrix);
        }
        public void task3()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("введите кол-во позиций для сдвига влево ");
            int k = int.Parse(Console.ReadLine());
            LeftRotate(array, k);
            Console.WriteLine("массив после циклического сдвига влево");
            Console.WriteLine(string.Join(" ", array));
        }
        public void task4()
        {
            int[,] matrix1 = {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };
            int[,] matrix2 = {
                { 9, 8, 7},
                { 6, 5, 4},
                { 3, 2, 1 }
            };
            double average;
            int[,] sumMatrix = AddMatrices(matrix1, matrix2, out average);
            Console.WriteLine("результат сложения матриц");
            PrintMatrix(sumMatrix);
            Console.WriteLine($"среднее значение всех элементов входных матриц {average:F2}");
            int[,] diffMatrix = SubtractMatrices(matrix1, matrix2, out average);
            Console.WriteLine($"\n результат вычитания матриц ");
            PrintMatrix(diffMatrix);
            Console.WriteLine($"среднее значение всех элементов входных матриц {average:F2}");
        }
        public void task5()
        {
            int[,] matrix1 = {
                { 1, 2, 3, 4, 5},
                { 6, 7, 8, 9, 10},
                { 11, 12, 13, 14,15},
                { 16, 17,18, 19, 20},
                {21, 22, 23, 24, 25}
            };
            int[,] matrix2 = {
                { 25, 24, 23, 22, 21},
                { 20, 19, 18, 17, 16},
                { 15, 14, 13, 12, 11},
                {10, 9, 8, 7, 6},
                {5, 4, 3, 2, 1}
            };
            int[,] resultMatrix = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("результат перемножения матриц");
            PrintMatrix(resultMatrix);
        }
        public void task6()
        {
            int[] array = { 5, 12, -4, 7, 3, -9, 15, 8 };
            Console.WriteLine("массив " + string.Join(", ", array));
            Console.WriteLine("\nсумма элементов массива (интеративно)" + SumIterative(array));
            Console.WriteLine("\nсумма элементов массива (рекурсивно)" + SumRecursive(array, array.Length - 1));
            Console.WriteLine("\nминимальный элемент массива(интеративно)" + MinIterative(array));
            Console.WriteLine("\nминимальный  элемент массива(рекурсивно)" + MinRecursive(array, array.Length - 1));
        }
        public void task7()
        {
            Console.WriteLine("введите номер элем ряда Фибоначчи (n) ");
            int n = int.Parse(Console.ReadLine());
            int result = Fibonacci(n);
            Console.WriteLine($"{n}- й член ряда Фибоначчи  {result}");
        }
        public void task8()
        {
            Console.WriteLine("введите размерность матрицы N (NxN)");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Console.WriteLine("введите элементы матрицы");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"элемент [{i + 1},{j + 1}] ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int determinant = CalculateDeterminant(matrix, n);
            Console.WriteLine($"определить матрицы {determinant}");

        }
        public void task9()
        {
            int size = 9;
            int[,] matrix = new int[size, size];
            Random random = new Random();

            // Заполнение матрицы случайными числами
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(1, 101); // Случайные числа от 1 до 100
                }
            }

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            // Приведение матрицы к симметричной форме относительно главной диагонали
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    matrix[i, j] = matrix[j, i];
                }
            }

            Console.WriteLine("Симметричная матрица:");
            PrintMatrix(matrix);
        }
       
        public void task10()
        {
            int N;
            do
            {
                Console.Write("Введите четное число элементов массива (N): ");
                N = int.Parse(Console.ReadLine());
                if (N > 0 && N % 2 == 0) 
                {
                    Console.WriteLine("Число должно быть четным! Попробуйте снова.");
                }
            }
            while (N % 2 != 0);
            int[] array = new int[N];
            Console.WriteLine($"Введите {N} элементов массива:");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            int leftSum = 0, rightSum = 0;
            for (int i = 0; i < N / 2; i++)
            {
                leftSum += array[i]; 
                rightSum += array[N / 2 + i]; 
            }
            int difference = rightSum - leftSum;
            Console.WriteLine($"\nСумма левой половины: {leftSum}");
            Console.WriteLine($"Сумма правой половины: {rightSum}");
            Console.WriteLine($"Разность (правая - левая): {difference}");
        }
    }
}

