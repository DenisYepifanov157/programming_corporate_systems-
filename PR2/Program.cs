using System;

namespace AllTasks
{
    class Program
    {
        // Константы для кофемашины
        private const int AMERICANO_WATER = 300;
        private const int LATTE_WATER = 30;
        private const int LATTE_MILK = 270; 
        private const int AMERICANO_PRICE = 150;
        private const int LATTE_PRICE = 170;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МЕНЮ ВЫБОРА ЗАДАЧ ===");
                Console.WriteLine("1. Ряд Маклорена для ln(1+x)");
                Console.WriteLine("2. Счастливый билет");
                Console.WriteLine("3. Сокращение дроби");
                Console.WriteLine("4. Угадывание числа");
                Console.WriteLine("5. Кофемашина");
                Console.WriteLine("6. Бактерии и антибиотик");
                Console.WriteLine("7. Колонизация Марса");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите задачу: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        MaclaurinSeriesTask();
                        break;
                    case "2":
                        LuckyTicketTask();
                        break;
                    case "3":
                        FractionReductionTask();
                        break;
                    case "4":
                        NumberGuessingTask();
                        break;
                    case "5":
                        CoffeeMachineTask();
                        break;
                    case "6":
                        BacteriaTask();
                        break;
                    case "7":
                        MarsColonizationTask();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Задача 1: Ряд Маклорена для ln(1+x)
        static void MaclaurinSeriesTask()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== РЯД МАКЛОРЕНА ДЛЯ ln(1+x) ===");
                Console.WriteLine("1 - Вычислить ln(1 + x) с помощью ряда Маклорена с точностью ε");
                Console.WriteLine("2 - Вычислить n-й член ряда");
                Console.WriteLine("0 - Назад в меню");
                string choice = Console.ReadLine();

                if (choice == "0") break;
                else if (choice == "1") ComputeSeriesSum();
                else if (choice == "2") ComputeNthTerm();
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    Console.ReadKey();
                }
            }
        }

        static void ComputeSeriesSum()
        {
            Console.Write("Введите x (для |x| <= 1): ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите ε (ε < 0.01): ");
            double epsilon = double.Parse(Console.ReadLine());

            if (Math.Abs(x) > 1 || (Math.Abs(x) == 1 && x < 0))
            {
                Console.WriteLine("x должен быть в (-1, 1]");
                Console.ReadKey();
                return;
            }

            double sum = 0;
            double term = x;
            int k = 1;

            while (Math.Abs(term) >= epsilon)
            {
                sum += term;
                term = -term * x / (k + 1);
                k++;
            }

            Console.WriteLine($"Приближённое значение ln(1 + x): {sum}");
            Console.WriteLine($"Встроенная функция Math.Log(1 + x): {Math.Log(1 + x)}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void ComputeNthTerm()
        {
            Console.Write("Введите n (n >= 1): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("n должно быть не менее 1");
                Console.ReadKey();
                return;
            }

            double term = Math.Pow(-1, n + 1) * Math.Pow(x, n) / n;
            Console.WriteLine($"{n}-й член: {term}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        // Задача 2: Счастливый билет
        static void LuckyTicketTask()
        {
            Console.Clear();
            Console.WriteLine("=== СЧАСТЛИВЫЙ БИЛЕТ ===");
            Console.Write("Введите номер билета (6 цифр): ");
            int ticket = int.Parse(Console.ReadLine());
            
            if (ticket < 100000 || ticket > 999999)
            {
                Console.WriteLine("Номер билета должен состоять из 6 цифр!");
                Console.ReadKey();
                return;
            }
            
            int digit1 = ticket / 100000;
            int digit2 = (ticket / 10000) % 10;
            int digit3 = (ticket / 1000) % 10;
            int digit4 = (ticket / 100) % 10;
            int digit5 = (ticket / 10) % 10;
            int digit6 = ticket % 10;
            
            int sumFirstThree = digit1 + digit2 + digit3;
            int sumLastThree = digit4 + digit5 + digit6;
            
            bool isLucky = sumFirstThree == sumLastThree;
            
            Console.WriteLine($"Билет {ticket}: {(isLucky ? "СЧАСТЛИВЫЙ" : "НЕСЧАСТЛИВЫЙ")}");
            Console.WriteLine($"Сумма первых трех цифр: {sumFirstThree}");
            Console.WriteLine($"Сумма последних трех цифр: {sumLastThree}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        // Задача 3: Сокращение дроби
        static void FractionReductionTask()
        {
            Console.Clear();
            Console.WriteLine("=== СОКРАЩЕНИЕ ДРОБИ ===");
            Console.Write("Введите числитель: ");
            int numerator = int.Parse(Console.ReadLine());
            
            Console.Write("Введите знаменатель: ");
            int denominator = int.Parse(Console.ReadLine());
            
            if (denominator == 0)
            {
                Console.WriteLine("Ошибка: знаменатель не может быть равен 0");
                Console.ReadKey();
                return;
            }
            
            int gcd = FindGCD(Math.Abs(numerator), Math.Abs(denominator));
            
            int reducedNumerator = numerator / gcd;
            int reducedDenominator = denominator / gcd;
            
            if (reducedDenominator < 0)
            {
                reducedNumerator = -reducedNumerator;
                reducedDenominator = -reducedDenominator;
            }
            
            Console.WriteLine($"Исходная дробь: {numerator} / {denominator}");
            Console.WriteLine($"Сокращенная дробь: {reducedNumerator} / {reducedDenominator}");
            Console.WriteLine($"НОД: {gcd}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        
        static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Задача 4: Угадывание числа
        static void NumberGuessingTask()
        {
            Console.Clear();
            Console.WriteLine("=== УГАДЫВАНИЕ ЧИСЛА ===");
            Console.WriteLine("Загадайте число от 0 до 63.");
            Console.WriteLine("Отвечайте на вопросы: 1 - да, 0 - нет");
            Console.WriteLine();
            
            int low = 0;
            int high = 63;
            int guess = 0;
            int attempts = 0;
            
            for (int i = 0; i < 6; i++)
            {
                attempts++;
                guess = (low + high) / 2;
                
                Console.Write($"Ваше число больше {guess}? ");
                int answer = int.Parse(Console.ReadLine());
                
                if (answer == 1)
                {
                    low = guess + 1;
                }
                else
                {
                    high = guess;
                }
                
                if (low == high) break;
            }
            
            Console.WriteLine($"Ваше число: {low}");
            Console.WriteLine($"Угадано за {attempts} попыток");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        // Задача 5: Кофемашина
        static void CoffeeMachineTask()
        {
            Console.Clear();
            Console.WriteLine("=== КОФЕМАШИНА ===");
            
            int water, milk, americanoCount = 0, latteCount = 0, earnings = 0;
            
            Console.Write("Введите количество воды (мл): ");
            water = int.Parse(Console.ReadLine());
            Console.Write("Введите количество молока (мл): ");
            milk = int.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("\nВыберите напиток:");
                Console.WriteLine("1 - Американо");
                Console.WriteLine("2 - Латте");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Неверный выбор");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (water >= AMERICANO_WATER)
                        {
                            water -= AMERICANO_WATER;
                            americanoCount++;
                            earnings += AMERICANO_PRICE;
                            Console.WriteLine("Ваш американо готов");
                        }
                        else
                        {
                            Console.WriteLine("Не хватает воды для американо");
                        }
                        break;
                    case 2:
                        if (water >= LATTE_WATER && milk >= LATTE_MILK)
                        {
                            water -= LATTE_WATER;
                            milk -= LATTE_MILK;
                            latteCount++;
                            earnings += LATTE_PRICE;
                            Console.WriteLine("Ваш латте готов");
                        }
                        else if (water < LATTE_WATER)
                        {
                            Console.WriteLine("Не хватает воды для латте");
                        }
                        else
                        {
                            Console.WriteLine("Не хватает молока для латте");
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }

                if (water < AMERICANO_WATER && (water < LATTE_WATER || milk < LATTE_MILK))
                {
                    Console.WriteLine("\nИнгредиенты подошли к концу");
                    Console.WriteLine($"Остаток воды: {water} мл");
                    Console.WriteLine($"Остаток молока: {milk} мл");
                    Console.WriteLine($"Приготовлено чашек американо: {americanoCount}");
                    Console.WriteLine($"Приготовлено чашек латте: {latteCount}");
                    Console.WriteLine($"Итоговый заработок аппарата: {earnings} рублей");
                    break;
                }
            }
            
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        // Задача 6: Бактерии и антибиотик
        static void BacteriaTask()
        {
            Console.Clear();
            Console.WriteLine("=== БАКТЕРИИ И АНТИБИОТИК ===");
            
            Console.Write("Введите количество бактерий (N): ");
            int bacteria = int.Parse(Console.ReadLine());
            Console.Write("Введите количество капель антибиотика (X): ");
            int X = int.Parse(Console.ReadLine());
            
            int killPower = X * 10;
            int hours = 0;
            
            Console.WriteLine("\nДинамика изменения количества бактерий:");
            
            while (bacteria > 0 && killPower > 0)
            {
                hours++;
                bacteria *= 2;
                bacteria -= killPower;
                killPower -= X; 
                
                if (bacteria < 0) bacteria = 0;
                
                Console.WriteLine($"Час {hours}: Бактерий = {bacteria}, Мощность антибиотика = {killPower}");
            }
            
            Console.WriteLine($"\nПроцесс завершен через {hours} часов");
            Console.WriteLine($"Конечное количество бактерий: {bacteria}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        // Задача 7: Колонизация Марса
        static void MarsColonizationTask()
        {
            Console.Clear();
            Console.WriteLine("=== КОЛОНИЗАЦИЯ МАРСА ===");
            
            Console.Write("Введите количество модулей (n): ");
            int n = int.Parse(Console.ReadLine());
            
            Console.Write("Введите размеры модуля (a b): ");
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            
            Console.Write("Введите размеры поля (w h): ");
            input = Console.ReadLine().Split();
            int w = int.Parse(input[0]);
            int h = int.Parse(input[1]);

            int maxD = CalculateMaxProtection(n, a, b, w, h);
            
            if (maxD == -1)
                Console.WriteLine("Невозможно разместить модули даже без защиты");
            else
                Console.WriteLine($"Максимальная толщина защиты: {maxD}");
            
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static int CalculateMaxProtection(int n, int a, int b, int w, int h)
        {
            if (!CanPlaceModules(n, a, b, w, h, 0))
                return -1;

            int left = 0;
            int right = Math.Min(w, h);
            int result = 0;
            
            while (left <= right)
            {
                int mid = (left + right) / 2;
                
                if (CanPlaceModules(n, a, b, w, h, mid))
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
            return result;
        }

        static bool CanPlaceModules(int n, int a, int b, int w, int h, int d)
        {
            int aWithD = a + 2 * d;
            int bWithD = b + 2 * d;

            bool orientation1 = CanFit(n, aWithD, bWithD, w, h);
            bool orientation2 = CanFit(n, bWithD, aWithD, w, h);
            
            return orientation1 || orientation2;
        }

        static bool CanFit(int n, int moduleWidth, int moduleHeight, int fieldWidth, int fieldHeight)
        {
            if (moduleWidth > fieldWidth || moduleHeight > fieldHeight)
                return false;

            int modulesInWidth = fieldWidth / moduleWidth;
            int modulesInHeight = fieldHeight / moduleHeight;
            
            int totalModules = modulesInWidth * modulesInHeight;
            
            return totalModules >= n;
        }
    }
}