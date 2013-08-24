//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


class DeleteOddLines
{
    static void Main()
    {
        Console.WriteLine("This program deletes from given text file all odd lines.\nThe result is in the same file.\nEnter file directory: ");
        Console.WriteLine("It is a good idea to put "+"..\\..\\StartFile.txt"+" to make sure that you have this file in the folder.");
        string file = Console.ReadLine();
        List<string> list = new List<string>();
        try
        {
            StreamReader reader = new StreamReader(file);
            StreamReader readAll = new StreamReader(file);
            Console.WriteLine("File {0} successfully opened.\nIt contains:\n", file);
            using (readAll)
            {
                Console.WriteLine(readAll.ReadToEnd());
            }

            using (reader)
            {
                string line = reader.ReadLine();
                int curLine = 1;
                while (line != null)
                {
                    if ((curLine % 2 == 0))
                    {
                        list.Add(line);
                    }
                    line = reader.ReadLine();
                    curLine++;
                }
            }
            Console.WriteLine("The even lines which have left are:");
            StreamWriter writer = new StreamWriter(file, false);
            using (writer)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(list[i]);
                }
            }
            StreamReader readFinal = new StreamReader(file);
            using (readFinal)
            {
                Console.WriteLine(readFinal.ReadToEnd());
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
