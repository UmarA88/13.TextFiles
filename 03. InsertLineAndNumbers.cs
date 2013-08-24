/*Write a program that reads a text file and inserts line numbers in front of each of its lines.
The result should be written to another text file.
In order to make the program working, please prepare a file named TextFile1.txt in the folder "Bin>Debug"*/

using System;
using System.Text;
using System.IO;

namespace _03.InsertLineAndNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This program reads file and inserts line numbers in front of each of it`s\nlines in new file.\nThe new file is in program`s folder.\nThe result is:\n\n");
            string file = @"TextFile1.txt";
            string newFile = @"..\..\TextFile2.txt";
            try
            {
                StreamReader reader = new StreamReader(file, Encoding.GetEncoding("Windows-1251"));
                StreamWriter writer = new StreamWriter(newFile, false, Encoding.GetEncoding("Windows-1251"));

                using (reader)
                {
                    using (writer)
                    {
                        int linesNumber = 1;
                        string read = reader.ReadLine();
                        while (read != null)
                        {
                            writer.WriteLine("{" + linesNumber + "} " + read);
                            read = reader.ReadLine();
                            linesNumber++;
                        }
                    }
                }
                StreamReader readNew = new StreamReader(newFile, Encoding.GetEncoding("Windows-1251"));
                using (readNew)
                {
                    Console.WriteLine(readNew.ReadToEnd());
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
}
