//Write a program that reads a text file and prints on the console its odd lines.
//In order to make sure that the program works, you should create a file named "TextFile.txt" in the file "Debug". Then write at least two lines inside and run the program.

using System;
using System.IO;
using System.Text;

class PrintOddLin
{
    static void Main()
    {

        Console.WriteLine("This program opens a file and prints it`s odd lines.");
        string file = @"TextFile.txt"; //Here you may change the name of the file!
        try
        {
            StreamReader reader = new StreamReader(file, Encoding.GetEncoding("Windows-1251"));
            Console.WriteLine("File {0} successfully opened.", file);
            Console.WriteLine("File`s odd lines content:\n");
            using (reader)
            {
                string line = reader.ReadLine();
                int curLine = 1;
                while (line != null)
                {
                    if (curLine % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    curLine++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine(
            "Can not find file {0}.", file);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine(
            "Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine(
            "Can not open the file {0}", file);
        }
    }
}
