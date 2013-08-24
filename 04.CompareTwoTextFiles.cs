// Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. 
// Assume the files have equal number of lines.
// In order to make the program work, put two files named as in the declaration of file1 and file2 in the folder of the program.

using System;
using System.Text;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("This program reads two files and compares them line by line.");
        string file1 = @"..\..\TextFile1.txt";
        string file2 = @"..\..\TextFile2.txt";

        try
        {
            StreamReader reader1 = new StreamReader(file1, Encoding.GetEncoding("Windows-1251"));
            StreamReader reader2 = new StreamReader(file2, Encoding.GetEncoding("Windows-1251"));
            using (reader1)
            {
                using (reader2)
                {
                    int sameLines = 0;
                    int differentLines = 0;
                    string line1 = reader1.ReadLine();
                    string line2 = reader2.ReadLine();
                    while (line1 != null && line2 != null)
                    {
                        if (line1 == line2)
                        {
                            sameLines++;
                        }
                        else
                        {
                            differentLines++;
                        }
                        line1 = reader1.ReadLine();
                        line2 = reader2.ReadLine();
                        if ((line1 == null && line2 != null) || (line1 != null && line2 == null))
                        {
                            throw new Exception("The two textfiles are with different number of lines.");
                        }
                    }

                    Console.WriteLine("The number of same lines is {0}.", sameLines);
                    Console.WriteLine("The number of different lines is {0}.\n", differentLines);
                }
            }
            StreamReader reader11 = new StreamReader(file1, Encoding.GetEncoding("Windows-1251"));
            StreamReader reader12 = new StreamReader(file2, Encoding.GetEncoding("Windows-1251"));
            using (reader11)
            {
                using (reader12)
                {
                    Console.WriteLine("The first file is:\n\n");
                    Console.WriteLine(reader11.ReadToEnd());
                    Console.WriteLine();
                    Console.WriteLine("The second file is:\n\n");
                    Console.WriteLine(reader12.ReadToEnd());
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
}

