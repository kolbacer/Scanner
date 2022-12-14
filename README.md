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


Sample C++ Code
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
        
        int number = sc.nextInt();
        
        Console.WriteLine("Thanks! You entered a number " + number);
    }
}
```
More Detailed Example
---------------------

```cs
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
```
test.txt contents:
```
  7  
 12  5.6  32.1      54.44   531.2    909.0001     0.0001   
   
 
```
This is a sample **input and output** from the above example:
```
Console test

Enter your name: Victor
Your name is Victor
Enter a positive integer number N: 3
Enter N decimal numbers separated by a space: 10.4  999     3.645
The numbers in ascending order: 3,645 10,4 999

File test

The numbers in ascending order: 0,0001 5,6 12 32,1 54,44 531,2 909,0001
```
