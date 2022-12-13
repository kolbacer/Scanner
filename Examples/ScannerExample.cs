using System;
using System.IO;
using IOutils;

public class ScannerExample
{
    static void Main()
    {
        Scanner consoleScanner = new Scanner();
        Scanner fileScanner = new Scanner(File.OpenRead(
            @"..\..\..\Test\test.txt"));

        // Console test

        Console.WriteLine("Console test\n");

        Console.Write("Enter your name: ");
        string name = consoleScanner.NextToken();
        Console.WriteLine("Your name is " + name);

        Console.Write("Enter a positive integer number N: ");
        int n = consoleScanner.NextInt();
        Console.Write("Enter N decimal numbers separated by a space: ");
        decimal[] numbers = new decimal[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = consoleScanner.NextDecimal();
        }
        Array.Sort(numbers);
        Console.WriteLine("The numbers in ascending order: {0}",
            string.Join(' ', numbers));


        // File test

        Console.WriteLine("\nFile test\n");

        n = fileScanner.NextInt();
        numbers = new decimal[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = fileScanner.NextDecimal();
        }
        Array.Sort(numbers);
        Console.WriteLine("The numbers in ascending order: {0}",
            string.Join(' ', numbers));
    }
}