using System;



namespace Lab1_Dmytruk
{
    class Program
    {
        
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Task1();
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
    }
}
