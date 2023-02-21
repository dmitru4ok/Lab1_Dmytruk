using System;



namespace Lab1_Dmytruk
{
    class Program
    {
        
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Task1();
            Task2();
            Console.ReadLine();
        }

        static void Task1()
        {
            Console.Write("Введіть вісімкове число: ");
            string input = Console.ReadLine();
            
            uint result = 0;
            uint PowVariable = 1;
            bool InputIsCorrect = true;
            for (int i = input.Length - 1; i>=0; --i)
            {
                if (input[i] >= '0' && input[i] <= '7')
                {
                    result += PowVariable * Convert.ToUInt32(input[i] - '0'); //або можна input[i].ToString()
                    PowVariable *= 8;
                } 
                else
                {
                    InputIsCorrect = false;
                    break; 
                }
            }

            if (InputIsCorrect)
            {
                Console.WriteLine($"Число {input} у вісімковiй рівне {Convert.ToUInt32(input, 8)} у десятковій");
                Console.WriteLine($"Число {input} у вісімковiй рівне {result} у десятковій");
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
    }
}
