using System;
using System.IO;
using System.Diagnostics;
using System.Linq;


//place sorting algorithms here. Only need decimal ones. 
public class QuickSortDec
{
    public static void QuickSort(decimal[] data)
    {
        // pre: 0 <= n <= data.length
        // post: values in data[0 … n-1] are in ascending order

        Quick_Sort(data, 0, data.Length - 1);
    }

    public static void Quick_Sort(decimal[] data, int left, int right)
    {
        int i, j;
        decimal pivot, temp;
        i = left;
        j = right;
        pivot = data[(left + right) / 2];
        do
        {
            while ((data[i] < pivot) && (i < right)) i++;
            while ((pivot < data[j]) && (j > left)) j--;
            if (i <= j)
            {
                temp = data[i];
                data[i] = data[j];
                data[j] = temp;
                i++;
                j--;
            }
        } while (i <= j);
        if (left < j) Quick_Sort(data, left, j);
        if (i < right) Quick_Sort(data, i, right);
    }


}

//decimal heap sort.
public class HeapSortDec
{
    public static void HeapSort(decimal[] Heap)
    {
        // pre: 0 <= n <= Heap.length             
        // post: values in Heap[0 … n-1] are in ascending order  
        int HeapSize = Heap.Length;
        int i;
        for (i = (HeapSize - 1) / 2; i >= 0; i--)
        {
            Max_Heapify(Heap, HeapSize, i);
        }
        for (i = Heap.Length - 1; i > 0; i--)
        {
            decimal temp = Heap[i];
            Heap[i] = Heap[0];
            Heap[0] = temp;
            HeapSize--;
            Max_Heapify(Heap, HeapSize, 0);
        }
    }

    private static void Max_Heapify(decimal[] Heap, int HeapSize, int Index)
    {
        int Left = (Index + 1) * 2 - 1;
        int Right = (Index + 1) * 2;
        int largest = 0;
        if (Left < HeapSize && Heap[Left] > Heap[Index])
        {
            largest = Left;
        }
        else
        {
            largest = Index;
        }
        if (Right < HeapSize && Heap[Right] > Heap[largest])
        {
            largest = Right;
        }
        if (largest != Index)
        {
            decimal temp = Heap[Index];
            Heap[Index] = Heap[largest];
            Heap[largest] = temp;
            Max_Heapify(Heap, HeapSize, largest);
        }
    }
}

//insertion sort dec
public class DecInsertionSort
{
    public static void InsertionSort(decimal[] insertArray)
    {

        for (int i = 1; i < insertArray.Length; i++)
        {
            int j = i;
            while (j > 0)
            {
                if (insertArray[j - 1] > insertArray[j])
                {
                    decimal temp = insertArray[j - 1];
                    insertArray[j - 1] = insertArray[j];
                    insertArray[j] = temp;
                    j--;
                }
                else
                    break;
            }

        }

    }

}

public class main
{

    static void Main(string[] args)
    {
        try
        {
            //counter
            int counter = 0;

            //load in the variables here, in string format to begin with before a loop.             
            string[] lines = System.IO.File.ReadAllLines("files/Close_128.txt");
            string[] lines2 = System.IO.File.ReadAllLines("files/High_128.txt");
            string[] lines3 = System.IO.File.ReadAllLines("files/Low_128.txt");
            string[] lines4 = System.IO.File.ReadAllLines("files/Open_128.txt");
            string[] lines5 = System.IO.File.ReadAllLines("files/Change_128.txt");

            //create a new decimal array to allow it to be sorted. 
            decimal[] Open_128 = new decimal[lines4.Length];
            decimal[] Close_128 = new decimal[lines.Length];
            decimal[] High_128 = new decimal[lines2.Length];
            decimal[] Low_128 = new decimal[lines3.Length];
            decimal[] Change_128 = new decimal[lines5.Length];

            //loop through all of the strings and convert them into the decimal array. 
            for (int x = 0; x < lines.Length; x++)
            {
                Open_128[x] = Convert.ToDecimal(lines4[x].ToString());
                Close_128[x] = Convert.ToDecimal(lines[x].ToString());
                High_128[x] = Convert.ToDecimal(lines2[x].ToString());
                Low_128[x] = Convert.ToDecimal(lines3[x].ToString());
                Change_128[x] = Convert.ToDecimal(lines5[x].ToString());
            }
            //stopwatch to measure search time
            Stopwatch stopwatch = new Stopwatch();

            //first menu
            Console.WriteLine("What do you wish to do? 1. Sort arrays in ascending or descending order? 2. Search arrays for specific value?");
            int Choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (Choice)
            {
                case 1:
                    {
                        Console.WriteLine("What array do you wish to sort? 1 = Open, Ascending. 2 = Open, Descending. 3 = High, Ascending. 4 = High, Descending. 5 = Change, Ascending. 6 = Change, Descending. 7 = Close, Ascending. 8 = Close, Descending. 9 = Low, Ascending. 10 = Low, Descending.");
                        int sortCho = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (sortCho == 1)
                        {
                            stopwatch.Start();
                            //display the figures from start to finish for ascending. 
                            QuickSortDec.QuickSort(Open_128);
                            for (int x = 0; x < lines.Length; x++)
                            {
                                Console.WriteLine(Open_128[x]);

                            }

                        }
                        if (sortCho == 2)
                        {
                            stopwatch.Start();
                            //display the figures from finish to start for descending. 
                            QuickSortDec.QuickSort(Open_128);
                            for (int x = lines.Length - 1; x > 0; x--)
                            {
                                Console.WriteLine(Open_128[x]);
                            }

                        }
                        if (sortCho == 3)
                        {
                            stopwatch.Start();
                            //display the figures from start to finish for ascending. 
                            QuickSortDec.QuickSort(High_128);
                            for (int x = 0; x < lines.Length; x++)
                            {
                                Console.WriteLine(High_128[x]);

                            }

                        }
                        if (sortCho == 4)
                        {
                            stopwatch.Start();
                            //display the figures from finish to start for descending. 
                            QuickSortDec.QuickSort(High_128);
                            for (int x = lines.Length - 1; x > 0; x--)
                            {
                                Console.WriteLine(High_128[x]);
                            }

                        }
                        if (sortCho == 5)
                        {
                            stopwatch.Start();
                            //display the figures from start to finish for ascending. 
                            QuickSortDec.QuickSort(Change_128);
                            for (int x = 0; x < lines.Length; x++)
                            {
                                Console.WriteLine(Change_128[x]);

                            }

                        }
                        if (sortCho == 6)
                        {
                            stopwatch.Start();
                            //display the figures from finish to start for descending. 
                            QuickSortDec.QuickSort(Change_128);
                            for (int x = lines.Length - 1; x > 0; x--)
                            {
                                Console.WriteLine(Change_128[x]);
                            }

                        }
                        if (sortCho == 7)
                        {
                            stopwatch.Start();
                            //display the figures from start to finish for ascending. 
                            QuickSortDec.QuickSort(Close_128);
                            for (int x = 0; x < lines.Length; x++)
                            {
                                Console.WriteLine(Close_128[x]);

                            }

                        }
                        if (sortCho == 8)
                        {
                            stopwatch.Start();
                            //display the figures from finish to start for descending. 
                            QuickSortDec.QuickSort(Close_128);
                            for (int x = lines.Length - 1; x > 0; x--)
                            {
                                Console.WriteLine(Close_128[x]);
                            }

                        }
                        if (sortCho == 9)
                        {
                            stopwatch.Start();
                            //display the figures from start to finish for ascending. 
                            QuickSortDec.QuickSort(Low_128);
                            for (int x = 0; x < lines.Length; x++)
                            {
                                Console.WriteLine(Low_128[x]);

                            }

                        }
                        if (sortCho == 10)
                        {
                            stopwatch.Start();
                            //display the figures from finish to start for descending. 
                            QuickSortDec.QuickSort(Low_128);
                            for (int x = lines.Length - 1; x > 0; x--)
                            {
                                Console.WriteLine(Low_128[x]);
                            }

                        }
                        stopwatch.Stop();
                        Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);
                        Console.ReadKey();
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("What array do you wish to search? 1 = Open. 2 = High. 3 = Change. 4 = Close. 5 = Low.");
                        int sortCho = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (sortCho == 1)
                        {
                            Console.WriteLine("Input value:");

                            decimal inputValue = Convert.ToDecimal(Console.ReadLine());

                            stopwatch.Start();

                            for (int b = 0; b < lines.Length; b++)

                            {

                                if (Open_128[b] == inputValue)
                                    
                                {
                                    Console.WriteLine("{0}", Open_128[b], High_128[b], Change_128[b], Close_128[b], Low_128[b]);
                                    counter++;
                                } else {
                                    continue;
                                }

                            }
                            
                            if (counter == 0)
                            {
                                Console.WriteLine("Value not found.");

                            }

                            stopwatch.Stop();
                            Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);

                           
                        
                        }
                        if (sortCho == 2)
                        {
                            Console.WriteLine("Input value:");

                            decimal inputValue = Convert.ToDecimal(Console.ReadLine());

                            stopwatch.Start();

                            for (int b = 0; b < lines.Length; b++)

                            {

                                if (High_128[b] == inputValue)

                                {
                                    Console.WriteLine("{0}", High_128[b], Open_128[b], Change_128[b], Close_128[b], Low_128[b]);
                                    counter++;
                                }
                                else
                                {
                                    continue;
                                }

                            }

                            if (counter == 0)
                            {
                                Console.WriteLine("Value not found.");

                            }

                            stopwatch.Stop();
                            Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);



                        }
                        if (sortCho == 3)
                        {
                            Console.WriteLine("Input value:");

                            decimal inputValue = Convert.ToDecimal(Console.ReadLine());

                            stopwatch.Start();

                            for (int b = 0; b < lines.Length; b++)

                            {

                                if (Change_128[b] == inputValue)

                                {
                                    Console.WriteLine("{0}", Change_128[b], High_128[b], Open_128[b], Close_128[b], Low_128[b]);
                                    counter++;
                                }
                                else
                                {
                                    continue;
                                }

                            }

                            if (counter == 0)
                            {
                                Console.WriteLine("Value not found.");

                            }

                            stopwatch.Stop();
                            Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);



                        }
                        if (sortCho == 4)
                        {
                            Console.WriteLine("Input value:");

                            decimal inputValue = Convert.ToDecimal(Console.ReadLine());

                            stopwatch.Start();

                            for (int b = 0; b < lines.Length; b++)

                            {

                                if (Close_128[b] == inputValue)

                                {
                                    Console.WriteLine("{0}", Close_128[b], High_128[b], Change_128[b], Open_128[b], Low_128[b]);
                                    counter++;
                                }
                                else
                                {
                                    continue;
                                }

                            }

                            if (counter == 0)
                            {
                                Console.WriteLine("Value not found.");

                            }

                            stopwatch.Stop();
                            Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);



                        }
                        if (sortCho == 5)
                        {
                            Console.WriteLine("Input value:");

                            decimal inputValue = Convert.ToDecimal(Console.ReadLine());

                            stopwatch.Start();

                            for (int b = 0; b < lines.Length; b++)

                            {

                                if (Low_128[b] == inputValue)

                                {
                                    Console.WriteLine("{0}", Low_128[b], High_128[b], Change_128[b], Close_128[b], Open_128[b]);
                                    counter++;
                                }
                                else
                                {
                                    continue;
                                }

                            }

                            if (counter == 0)
                            {
                                Console.WriteLine("Value not found.");

                            }

                            stopwatch.Stop();
                            Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);



                        }
                    }
                    Console.ReadKey();
                    break;

            }

        }
        
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.Read();

        } 
    }
}
