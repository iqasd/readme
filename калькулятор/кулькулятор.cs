using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Простой калькулятор на C#");
        Console.Write("Введите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число (или любое число для операций ++ и --): ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Выберите операцию: +, -, *, /, %, ++, --");
        string operation = Console.ReadLine();

        double result = 0;
        bool validOperation = true;

        switch (operation)
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
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно.");
                    validOperation = false;
                }
                else
                {
                    result = num1 / num2;
                }
                break;
            case "%":
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно.");
                    validOperation = false;
                }
                else
                {
                    result = num1 % num2;
                }
                break;
            case "++":
                result = num1 + 1;
                Console.WriteLine($"Инкремент: {num1} -> {result}");
                break;
            case "--":
                result = num1 - 1;
                Console.WriteLine($"Декремент: {num1} -> {result}");
                break;
            default:
                Console.WriteLine("Ошибка: неверная операция.");
                validOperation = false;
                break;
        }

        if (validOperation && operation != "++" && operation != "--")
        {
            Console.WriteLine($"Результат: {result}");
        }
    }
}