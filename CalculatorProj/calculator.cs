using System;

namespace calculator
{
    internal class Program
    {
        static float memory = 0; 

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в калькулятор!");
            Console.WriteLine("Поддерживаемые операции:");
            Console.WriteLine("  - Бинарные: +, -, *, /");
            Console.WriteLine("  - Унарные: s (квадрат), q (квадратный корень), i (обратное число)");
            Console.WriteLine("  - Память: M+ (добавить в память), M- (вычесть из памяти), MR (восстановить из памяти)");
            Console.WriteLine("Для унарных операций необходимо одно число, для бинарных - два");

            while (true)
            {
                Console.Write("Введите первое число (или 'exit' для выхода, 'MR' для просмотра памяти): ");
                string input = Console.ReadLine();
                
                if (input.ToLower() == "exit")
                    break;

                if (input.ToLower() == "mr")
                {
                    Console.WriteLine($"Текущее значение в памяти: {memory}");
                    continue;
                }

                if (!float.TryParse(input, out float one))
                {
                    Console.WriteLine("Ошибка: введите число или 'MR' для просмотра памяти!");
                    continue;
                }

                Console.Write("Введите знак действия: ");
                string sign = Console.ReadLine();

                float result = 0;
                bool requiresTwoOperands = true;
                bool errorOccurred = false;
                bool memoryOperation = false; 

                switch (sign)
                {
                    case "s": // Квадрат числа
                        result = one * one;
                        Console.WriteLine($"Квадрат числа {one} равен: {result}");
                        requiresTwoOperands = false;
                        break;

                    case "q": // Квадратный корень
                        if (one < 0)
                        {
                            Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа!");
                            errorOccurred = true;
                        }
                        else
                        {
                            result = (float)Math.Sqrt(one);
                            Console.WriteLine($"Квадратный корень из {one} равен: {result}");
                        }
                        requiresTwoOperands = false;
                        break;

                    case "i": // Обратное число
                        if (one == 0)
                        {
                            Console.WriteLine("Ошибка: деление на ноль!");
                            errorOccurred = true;
                        }
                        else
                        {
                            result = 1 / one;
                            Console.WriteLine($"Обратное число к {one} равно: {result}");
                        }
                        requiresTwoOperands = false;
                        break;

                    case "M+": // Добавить в память
                        memory += one;
                        Console.WriteLine($"Значение {one} добавлено в память. Текущая память: {memory}");
                        requiresTwoOperands = false;
                        memoryOperation = true;
                        break;

                    case "M-": // Вычесть из памяти
                        memory -= one;
                        Console.WriteLine($"Значение {one} вычтено из памяти. Текущая память: {memory}");
                        requiresTwoOperands = false;
                        memoryOperation = true;
                        break;

                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        requiresTwoOperands = true;
                        break;

                    default:
                        Console.WriteLine("Ошибка: неверный знак операции!");
                        errorOccurred = true;
                        requiresTwoOperands = false;
                        break;
                }

                if (requiresTwoOperands && !errorOccurred)
                {
                    Console.Write("Введите второе число: ");
                    if (!float.TryParse(Console.ReadLine(), out float two))
                    {
                        Console.WriteLine("Ошибка: введите число!");
                        errorOccurred = true;
                    }
                    else
                    {
                        switch (sign)
                        {
                            case "+":
                                result = one + two;
                                Console.WriteLine($"Сумма чисел равна: {result}");
                                break;

                            case "-":
                                result = one - two;
                                Console.WriteLine($"Разность чисел равна: {result}");
                                break;

                            case "*":
                                result = one * two;
                                Console.WriteLine($"Произведение чисел равно: {result}");
                                break;

                            case "/":
                                if (two == 0)
                                {
                                    Console.WriteLine("Ошибка: деление на ноль!");
                                    errorOccurred = true;
                                }
                                else
                                {
                                    result = one / two;
                                    Console.WriteLine($"Частное чисел равно: {result}");
                                }
                                break;
                        }
                    }
                }

                if (!errorOccurred && !memoryOperation)
                {
                    Console.WriteLine($"Результат: {result}");
                    
                    Console.Write("Хотите сохранить результат в память? (Y/N): ");
                    string saveToMemory = Console.ReadLine();
                    
                    if (saveToMemory.ToLower() == "y" || saveToMemory.ToLower() == "yes")
                    {
                        memory += result;
                        Console.WriteLine($"Результат {result} добавлен в память. Текущая память: {memory}");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Работа калькулятора завершена. Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}