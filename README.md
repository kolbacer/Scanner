Java-like Scanner for C#
==========================================================

`Scanner` is an input reader for C#, which reads numbers and text in the Java's Scanner style. \
Original idea belongs to Svetlin Nakov - https://github.com/nakov/Nakov.io.cin \
I only added reading from file and renamed to Scanner. 

Install the NuGet Package
-------------------------

You can install the NuGet package [`IOutils.Scanner`](https://www.nuget.org/packages/IOutils.Scanner/):

```
Install-Package IOutils.Scanner
```


Sample Java Code
---------------

```java
public class Main {

   public static void main(String[] args) {

       Scanner sc = new Scanner(System.in);
       System.out.println("Enter a number:");

       int number = sc.nextInt();

       System.out.println("Thanks! You entered a number " + number);

   }
}
```

Corresponsing C# Code
---------------------

```cs
using System;
using IOutils;

public class EnteringNumbers
{
    static void Main()
    {
        Scanner sc = new Scanner();
        Console.WriteLine("Enter a number:");
        
        int? number = sc.nextInt();
        
        Console.WriteLine("Thanks! You entered a number " + number.Value);
    }
}
```
More Detailed Example
---------------------

```cs
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
```
test.txt contents:
```
  7  
 12  5.6  32.1      54.44   531,2    909.0001     0.0001   
     
  234,345  0,222 3.54 5
  
 5    6.4
  
   
```
This is a sample **input and output** from the above example:
```
Console test

Enter your name: Victor
Your name is Victor
Enter a positive integer number N: 5
Enter N decimal numbers separated by a space: 10.4  12.001 123   4  32,02
The numbers in ascending order: 4 10,4 12,001 32,02 123

File test

Numbers in file:
7 12 5,6 32,1 54,44 531,2 909,0001 0,0001 234,345 0,222 3,54 5 5 6,4
```
