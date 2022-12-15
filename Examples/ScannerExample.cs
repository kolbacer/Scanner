using System;
using System.Collections.Generic;
using System.IO;
using IOutils;

public class ScannerExample
{
    static void Main()
    {
        // Console test

        Scanner consoleScanner = new Scanner();

        Console.WriteLine("Console test\n");

        Console.Write("Enter your name: ");
        string name = consoleScanner.NextToken();
        Console.WriteLine("Your name is " + name);

        Console.Write("Enter a positive integer number N: ");
        int? n = consoleScanner.NextInt();
        Console.Write("Enter N decimal numbers separated by a space: ");
        decimal[] numbers = new decimal[n.Value];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = consoleScanner.NextDecimal().Value;
        }
        Array.Sort(numbers);
        Console.WriteLine("The numbers in ascending order: {0}",
            string.Join(' ', numbers));


        // File test

        Scanner fileScanner = new Scanner(File.OpenRead(
            @"..\..\..\Test\test.txt"));

        Console.WriteLine("\nFile test\n");

        LinkedList<double> nums = new LinkedList<double>();
        double? x = fileScanner.NextDouble();
        while (x != null)
        {
            nums.AddLast(x.Value);
            x = fileScanner.NextDouble();
        }

        Console.WriteLine("Numbers in file:");
        foreach (double num in nums)
        {
            Console.Write(num + " ");
        }
    }
}