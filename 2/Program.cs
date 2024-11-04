using System;

enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Power,
    SquareRoot
}

class Calculator
{
    public double DoOperation(Operation op, double a, double b = 0)
    {
        return op switch
        {
            Operation.Add => a + b,
            Operation.Subtract => a - b,
            Operation.Multiply => a * b,
            Operation.Divide => b != 0 ? a / b : throw new DivideByZeroException("На ноль делить нельзя"),
            Operation.Power => Math.Pow(a, b),
            Operation.SquareRoot => a >= 0 ? Math.Sqrt(a) : throw new ArgumentException("Корень из отрицательного числа не определен"),
            _ => throw new InvalidOperationException("Неверная операция")
        };
    }

    public void Execute()
    {
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("0 - Сложение");
        Console.WriteLine("1 - Вычитание");
        Console.WriteLine("2 - Умножение");
        Console.WriteLine("3 - Деление");
        Console.WriteLine("4 - Возведение в степень");
        Console.WriteLine("5 - Квадратный корень");
        Console.Write("Введите номер операции: ");
        int operationChoice = Convert.ToInt32(Console.ReadLine());

        if (operationChoice < 0 || operationChoice > 5)
        {
            Console.WriteLine("Неверный выбор операции.");
            return;
        }

        Operation operation = (Operation)operationChoice;

        double a, b = 0;

        Console.Write("Введите первое число: ");
        a = Convert.ToDouble(Console.ReadLine());

        if (operation != Operation.SquareRoot)
        {
            Console.Write("Введите второе число: ");
            b = Convert.ToDouble(Console.ReadLine());
        }

        try
        {
            double result = DoOperation(operation, a, b);
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}

class Task1
{
    public void Execute()
    {
        Console.Write("Введите размер массива N: ");
        int N = Convert.ToInt32(Console.ReadLine());

        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = i + 1;
        }

        Console.WriteLine("Массив в обратном порядке:");
        for (int i = N - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

class Task2
{
    public void Execute()
    {
        Console.Write("Введите размер квадратного массива: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (j >= i - 1)
                {
                    array[i, j] = 1;
                }
            }
        }

        Console.WriteLine("Заполненный массив:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Task3
{
    public void Execute()
    {
        Console.Write("Введите размер квадратного массива: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[size, size];
        int value = 1;
        int top = 0, bottom = size - 1, left = 0, right = size - 1;

        while (value <= size * size)
        {
            for (int i = left; i <= right; i++) array[top, i] = value++;
            top++;
            for (int i = top; i <= bottom; i++) array[i, right] = value++;
            right--;
            for (int i = right; i >= left; i--) array[bottom, i] = value++;
            bottom--;
            for (int i = bottom; i >= top; i--) array[i, left] = value++;
            left++;
        }

        Console.WriteLine("Заполненный массив:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Task4
{
    public void Execute()
    {
        Console.Write("Введите количество строк (M): ");
        int M = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов (N): ");
        int N = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[M, N];
        int value = 1;
        int top = 0, bottom = M - 1, left = 0, right = N - 1;

        while (value <= M * N)
        {
            for (int i = left; i <= right; i++) array[top, i] = value++;
            top++;
            for (int i = top; i <= bottom; i++) array[i, right] = value++;
            right--;
            for (int i = right; i >= left; i--) array[bottom, i] = value++;
            bottom--;
            for (int i = bottom; i >= top; i--) array[i, left] = value++;
            left++;
        }

        Console.WriteLine("Заполненный массив:");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание для выполнения:");
            Console.WriteLine("1 - Задание 1 (Массив N в обратном порядке)");
            Console.WriteLine("2 - Задание 2 (Квадратный массив с диагональю)");
            Console.WriteLine("3 - Задание 3 (Квадратный массив по спирали)");
            Console.WriteLine("4 - Задание 4 (M x N массив по спирали)");
            Console.WriteLine("5 - Калькулятор (С использованием перечислений)");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    new Task1().Execute();
                    break;
                case 2:
                    new Task2().Execute();
                    break;
                case 3:
                    new Task3().Execute();
                    break;
                case 4:
                    new Task4().Execute();
                    break;
                case 5:
                    new Calculator().Execute();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите от 0 до 5.");
                    break;
            }
        }
    }
}
