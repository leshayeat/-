using System;
using System.Collections.Generic;

class Calculator
{
    static void Main()
    {
        bool continueCalculations = true;
        Queue<string> history = new Queue<string>();

        Console.WriteLine("Калькулятор");
        Console.WriteLine("===========\n");

        while (continueCalculations)
        {
            try
            {
                // Ввод чисел
                Console.Write("Введите первое число: ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите второе число: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                bool sameNumbers = true;

                while (sameNumbers)
                {
                    // Показать меню
                    ShowMenu();

                    Console.Write("Выберите операцию (1-5): ");
                    string choice = Console.ReadLine();

                    int result = 0;
                    string operation = "";
                    bool validOperation = true;

                    // Обработка выбора
                    switch (choice)
                    {
                        case "1": // Сложение
                            result = num1 + num2;
                            operation = "+";
                            break;

                        case "2": // Вычитание
                            result = num1 - num2;
                            operation = "-";
                            break;

                        case "3": // Умножение
                            result = num1 * num2;
                            operation = "*";
                            break;

                        case "4": // Деление
                            if (num2 == 0)
                            {
                                Console.WriteLine("\nОшибка: Деление на ноль невозможно!");
                                validOperation = false;
                            }
                            else
                            {
                                result = num1 / num2;
                                operation = "/";
                            }
                            break;

                        case "5": // Выход
                            continueCalculations = false;
                            sameNumbers = false;
                            Console.WriteLine("\nВыход из программы. До свидания!");
                            break;

                        default:
                            Console.WriteLine("\nНеверный выбор! Пожалуйста, выберите от 1 до 5.");
                            validOperation = false;
                            break;
                    }

                    // Если операция успешна
                    if (validOperation && choice != "5")
                    {
                        // Вывод результата
                        Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}");

                        // Добавление в историю
                        string historyEntry = $"{num1} {operation} {num2} = {result}";
                        AddToHistory(history, historyEntry);

                        // Показать историю
                        ShowHistory(history);
                    }

                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка: Введите корректные целые числа!\n");
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nОшибка: Число слишком большое или слишком маленькое!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка: {ex.Message}\n");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nВыберите операцию:");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");
        Console.WriteLine("5. Выход");
    }

    static void AddToHistory(Queue<string> history, string operation)
    {
        // Добавляем операцию в историю
        history.Enqueue(operation);

        // Ограничиваем историю 5 последними операциями
        if (history.Count > 5)
        {
            history.Dequeue();
        }
    }

    static void ShowHistory(Queue<string> history)
    {
        if (history.Count > 0)
        {
            Console.WriteLine("История операций:");
            foreach (string operation in history)
            {
                Console.WriteLine($"  {operation}");
            }
        }
    }
}