/*Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. 
 * The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
 * The output should be a single number in a separate text file. Example:

 4
2 3 3 4
0 2 3 4	 Result => 17
3 7 1 2
4 3 3 2
*/
//You need a file Matrix.txt and a file MaxResult.txt in the folder of the program to make the things work! Enjoy!

using System;
using System.Text;
using System.IO;

class Matrix
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Matrix.txt");
            StreamWriter writer = new StreamWriter(@"..\...\MaxResult.txt", false);
            using (reader)
            {
                using (writer)
                {
                    int line = int.Parse(reader.ReadLine());
                    string eachRow = reader.ReadLine();
                    int[,] number = new int[line, line];
                    int row = 0;
                    Console.WriteLine("The matrix in this file is:\n");

                    //Create matrix with size lineXline
                    while (eachRow != null)
                    {
                        string[] numbers = eachRow.Split(' ');
                        for (int col = 0; col < numbers.Length; col++)
                        {
                            number[row, col] = int.Parse(numbers[col]);
                            Console.Write(number[row, col]+ " ");
                        }
                        Console.WriteLine();
                        eachRow = reader.ReadLine();
                        row++;
                    }
                    Console.WriteLine();
                    writer.WriteLine(BiggestSum(number, line));
                    Console.WriteLine("This result is written in new file MaxResult.txt in program`s directory.");
                }
            }
        }

        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Can not open the file.");
        }
    }

    static int BiggestSum(int[,] number, int line)
    {
        //Find the biggest sum
        int curSum = 0;
        int maxSum = 0;
        for (int i = 0; i < line - 1; i++)
        {
            for (int j = 0; j < line - 1; j++)
            {
                curSum = number[i, j] + number[i + 1, j] + number[i, j + 1] + number[i + 1, j + 1];
                if (curSum >= maxSum)
                {
                    maxSum = curSum;
                }
            }
        }
        Console.WriteLine("The max sum of 2x2 matrix is {0}.", maxSum);
        return maxSum;
    }
}
