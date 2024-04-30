using System;



public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {
    }
}

class Programm
{
    static void Main(string[] args)
    {
        List<string> Surnames = new List<string> { "Петров", "Сидоров", "Поляков", "Васильев", "Агеев" };
        Console.WriteLine("Исходный список фамилий:");
        PrintList(Surnames);

        try
        {
            Console.WriteLine("Введите 1 для сортировки фамилий по алфавиту (А-Я) или 2 для сортировки в обратном порядке (Я-А):");
            string input = Console.ReadLine();

            int sortOrder = ParseInput(input); //Проверка на ввод
            SortSurnames(Surnames, sortOrder); //Сортировка

            Console.WriteLine("Отсортированный список фамилий:");
            PrintList(Surnames); //Вывод отсортированных фамилий
        }

        catch (InvalidInputException ex) 
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static int ParseInput(string input)
    {
        if (!int.TryParse(input, out int sortOrder) || (sortOrder != 1 && sortOrder != 2))
        {
            throw new InvalidInputException("Некорректный ввод. Введите 1 или 2.");
        }

        return sortOrder;
    }

    static void SortSurnames(List<string> surnames, int sortOrder)
    {
        if (sortOrder == 1)
        {
            surnames.Sort();
        }
        else if (sortOrder == 2)
        {
            surnames.Sort((a, b) => b.CompareTo(a));
        }
    }

    static void PrintList(List<string> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

}
