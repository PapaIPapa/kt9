using System;
using System.Collections.Generic;

public class Stack<T> where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Push(T item)
    {
        elements.Add(item);
    }

    public T Pop()
    {
        if (elements.Count == 0)
            throw new InvalidOperationException("Стек пуст.");
        T item = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        return item;
    }

    public T Max()
    {
        if (elements.Count == 0)
            throw new InvalidOperationException("Стек пуст.");
        T max = elements[0];
        foreach (var element in elements)
        {
            if (element.CompareTo(max) > 0)
            {
                max = element;
            }
        }
        return max;
    }

    public int Count => elements.Count;
}

public class Pair<T, U> where T : class where U : class
{
    public T First { get; set; }
    public U Second { get; set; }

    public Pair(T first, U second)
    {
        First = first;
        Second = second;
    }

    public void Swap()
    {
        var temp = First;
        First = Second as T;
        Second = temp as U;
    }
}


public class Calculator<T> where T : new()
{
    public static T Add(T x, T y)
    {
        dynamic a = x;
        dynamic b = y;
        return a + b;
    }

    public static T Zero()
    {
        return new T();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(9);
        stack.Push(2);
        Console.WriteLine("Максимальный элемент в стеке: " + stack.Max());

        var pair = new Pair<string, string>("Первый", "Второй");
        Console.WriteLine($"До Swap: {pair.First}, {pair.Second}");
        pair.Swap();
        Console.WriteLine($"После Swap: {pair.First}, {pair.Second}");

        var sum = Calculator<int>.Add(3, 4);
        Console.WriteLine("Сумма: " + sum);

        var zeroValue = Calculator<int>.Zero();
        Console.WriteLine("Нулевое значение: " + zeroValue);


    }
}