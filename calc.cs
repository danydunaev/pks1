using System;

namespace ClassicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            double result = 0.0;
            double memory = 0.0;

            while (!exit)
            {
                Console.WriteLine("\nВведите операцию: +, -, *, /, %, 1/x, x^2, sqrt(x), M+, M-, MR или exit");
                string op = Console.ReadLine();

                try
                {
                    if (op == "exit")
                    {
                        exit = true;
                        continue;
                    }

                    if (op == "MR")
                    {
                        Console.WriteLine($"Значение из памяти: {memory}");
                        continue;
                    }
                    else if (op == "M+")
                    {
                        memory += result;
                        Console.WriteLine($"{result} добавлено в память. Текущее значение памяти: {memory}");
                        continue;
                    }
                    else if (op == "M-")
                    {
                        memory -= result;
                        Console.WriteLine($"{result} вычтено из памяти. Текущее значение памяти: {memory}");
                        continue;
                    }

                    Console.Write("Введите первое число: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    if (op == "+" || op == "-" || op == "*" || op == "/" || op == "%")
                    {
                        Console.Write("Введите второе число: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        switch (op)
                        {
                            case "+":
                                result = num1 + num2;
                                break;
                            case "-":
                                result = num1 - num2;
                                break;
                            case "*":
                                result = num1 * num2;
                                break;
                            case "/":
                                if (num2 == 0) throw new DivideByZeroException();
                                result = num1 / num2;
                                break;
                            case "%":
                                if (num2 == 0) throw new DivideByZeroException();
                                result = num1 % num2;
                                break;
                        }
                    }
                    else if (op == "1/x")
                    {
                        if (num1 == 0) throw new DivideByZeroException();
                        result = 1 / num1;
                    }
                    else if (op == "x^2")
                    {
                        result = num1 * num1;
                    }
                    else if (op == "sqrt(x)")
                    {
                        if (num1 < 0) throw new ArgumentException("Нельзя извлечь квадратный корень из отрицательного числа");
                        result = Math.Sqrt(num1);
                    }
                    else
                    {
                        Console.WriteLine("Неизвестная операция.");
                        continue;
                    }

                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }
    }
}