using System;



namespace Lab1_Dmytruk
{
    class Program
    {
        
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Task1();
            //Task2();
            //Task3();
            Console.ReadLine();
        }

        static void Task1()
        {
            Console.Write("Введіть вісімкове число (дробова частина через кому): ");
            string input = Console.ReadLine();
            string[] split = input.Split(',');
            bool InputIsCorrect = true;
            bool IsNegative = (input[0] == '-') ? true : false;
            int ConvertedInt = ConvertIntPart(split[0], ref InputIsCorrect);
            double ConvertedDecimal = ConvertDecimalPart(split[1]);
            double total = (IsNegative) ? ConvertedInt - ConvertedDecimal : ConvertedInt + ConvertedDecimal;
            if (InputIsCorrect)
            {
                if (IsNegative)
                {
                    Console.WriteLine($"Число {input} у вісімковiй рівне -{Convert.ToDouble((input.Substring(1), 8))} у десятковій");
                }
                else
                {
                    Console.WriteLine($"Число {input} у вісімковiй рівне {Convert.ToDouble((input, 8))} у десятковій");
                }
                
                Console.WriteLine($"Число {input} у вісімковiй рівне {total} у десятковій");
            }
            else
            {
                Console.WriteLine($"{input} не є вісімковим числом!");
            }
        }
        static void Task2()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            Console.Write("Введіть x: ");
            bool ACheck = double.TryParse(Console.ReadLine(), out x);
            Console.Write("Введіть y: ");
            bool BCheck = double.TryParse(Console.ReadLine(), out y);
            Console.Write("Введіть z: ");
            bool CCheck = double.TryParse(Console.ReadLine(), out z);
            if (ACheck && BCheck && CCheck)
            {
                if (x == 0 || y == 0 || z == 0)
                {
                    Console.WriteLine("Помилка! Ділення на 0 неможливе.");
                }
                else
                {
                    double XByYDivByz = x * y / z;
                    double a = XByYDivByz + 1 / XByYDivByz;
                    double b = Math.Sin(XByYDivByz + 1.0) - Math.Cos(1 / XByYDivByz + 1.0) + 0.5;
                    double c = 2 - Math.Sqrt(a * a + 5.0);

                    double min = (b < c) ? ((a < b) ? a : b) : ((a < c) ? a : c);
                    Console.WriteLine($"Ви ввели: x = {x}, y = {y}, z = {z}.");
                    Console.WriteLine($"Обчислено, що: a = {a}, b={b}, c = {c}");
                    Console.WriteLine($"Звідси min(a, b, c) = {min}");
                }
            }
            else
            {
                Console.WriteLine("Введено нечислові дані");
            }
        }
        static void Task3()
        {
            const int rows = 7;
            const int cols = 6;
            int[,] matrix = new int[rows, cols] {
                {-1,   2,  4,  5,   7, -2},
                {-2,   2, -7, -8,  12, -9},
                {-2,  -1,  2,  4,   6,  7},
                {-1,   1, -1, -1,   1,  1},
                {-22, 11,  8,  9,   4,  3},
                {-3,   5,  6,  0,   4,  2},
                {-7,   2, -5, -7,  23,  2}
            };
            uint[] a = new uint[cols];
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                uint quantity = 0;
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    if (matrix[i, j] > 0) { quantity++; }
                }
                a[j] = quantity;
            }

            Console.WriteLine("Введена матриця: ");
            PrintIntMatrix(matrix);
            Console.WriteLine("\n\nВектор А - кількості додатніх елементів у стовпцях: ");
            PrintUintArray(a);
            uint MaxElemOfA = MaxOFArr(a);
            Console.WriteLine($"\nНайбільший елемент вектора А: {MaxElemOfA}"); 
        }

        static void PrintUintArray(uint[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write($"{arr[i]}|");
            }
            Console.Write('\n');
        }

        static uint MaxOFArr(uint[] arr)
        {
            uint MaxEl = arr[0];
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] > MaxEl)
                {
                    MaxEl = arr[i];
                }
            }
            return MaxEl;
        }

        static void PrintIntMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    Console.Write($"{arr[i,j]}|".PadLeft(5)); //форматування виводу матриці
                }
                Console.Write('\n');
            }
        }

        static int ConvertIntPart(string input, ref bool InputIsCorrect)
        {
            int result = 0;
            int PowVariable = 1;
            int LastIterIndex = ('-' == input[0]) ? 1 : 0;
            for (int i = input.Length - 1; i >= LastIterIndex; --i)
            {
                if (input[i] >= '0' && input[i] <= '7')
                {
                    result += PowVariable * Convert.ToInt32(input[i] - '0'); //або можна input[i].ToString()
                    PowVariable *= 8;
                }
                else
                {
                    InputIsCorrect = false;
                    break;
                }
            }
            if (LastIterIndex == 1)
            {
                return -result; 
            }
            return result;
        }

        static double ConvertDecimalPart(string DecInput)
        {
            double result = 0.0;
            double PowValue = 1.0 / 8.0;
            for (int i = 0; i < DecInput.Length; ++i)
            {
                result += (double)Convert.ToInt32(DecInput[i] - '0') * PowValue;
                PowValue /= 8.0;
            }
            return result;
        }
    }
}
