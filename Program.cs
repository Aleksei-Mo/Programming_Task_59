// Task 59. Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, 
//на пересечении которых расположен наименьший элемент массива.
Console.Clear();
Console.WriteLine("This program finds the minimum element of the entered array and deletes the Row and Column which contains this element.");
Console.WriteLine();
int numberRow = EnterUserData("Enter number of rows:");
int numberCol = EnterUserData("Enter number of columns:");
int lowerLim = EnterUserData("Enter lower limit for random range:");
int upperLim = EnterUserData("Enter upper limit for random range:");
int[,] randomArray = new int[numberRow, numberCol];

FillArray(randomArray, numberRow, numberCol, lowerLim, upperLim);
Console.WriteLine();
Console.WriteLine("You entered the following array:");
Console.WriteLine();
PrintArray(randomArray);
Console.WriteLine();
int[] minElementAddress = MinElementArray(randomArray);
Console.WriteLine($"The minimum element of the entered array = {randomArray[minElementAddress[0], minElementAddress[1]]} [{minElementAddress[0]}],[{minElementAddress[1]}]");
Console.WriteLine();
DeleteArrayElements(randomArray, minElementAddress[0], minElementAddress[1]);

int[,] FillArray(int[,] array, int numberRow, int numberCol, int lowerLim, int upperLim)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(lowerLim, upperLim + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int EnterUserData(string nameUserData)
{
    Console.Write($"{nameUserData}");
    return Convert.ToInt32(Console.ReadLine());
}

int[] MinElementArray(int[,] array)
{
    int minElementVolue = array[0, 0];
    int[] minElementAddress = new int[2];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minElementVolue)
            {
                minElementVolue = array[i, j];
                minElementAddress[0] = i;
                minElementAddress[1] = j;
            }
        }
    }
    return minElementAddress;
}

void DeleteArrayElements(int[,] arrayOriginal, int rowIndex, int colIndex)
{
    int[,] arrayResult = new int[arrayOriginal.GetLength(0) - 1, arrayOriginal.GetLength(1) - 1];
    int k = 0, n = 0;
    for (int i = 0; i < arrayResult.GetLength(0); i++)
    {
        if (i >= rowIndex)
        {
            k = i + 1;
        }
        else
        {
            k = i;
        }

        for (int j = 0; j < arrayResult.GetLength(1); j++)
        {
            if (j >= colIndex)
            {
                n = j + 1;
            }
            else
            {
                n = j;
            }
            arrayResult[i, j] = arrayOriginal[k, n];
        }
    }
    Console.WriteLine("The Row and Column of the original array which contains the minimum element were deleted. See the changed array below.");
    Console.WriteLine();
    PrintArray(arrayResult);
}