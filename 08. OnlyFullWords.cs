//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;

class ReplaceStartWithFinish
{
    static void Main()
    {
        Console.WriteLine("This program reads a file and replaces all substrings \"start\" with \"finish\". ");
        try
        {
            StreamReader reader = new StreamReader(@"..\..\StartFile.txt");

            using (reader)
            {
                Console.WriteLine("Original file contains:\n");

                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);

                    line = reader.ReadLine();
                }
                Console.WriteLine();
            }
            StreamReader reader2 = new StreamReader(@"..\..\StartFile.txt");
            using (reader2)
            {
                Console.WriteLine("New file containes:\n");
                string line1 = reader2.ReadLine();
                string word = "start";
                while (line1 != null)
                {
                    bool exist = false;
                    if ((line1.Contains(" start ") == true))
                    {
                        string replaced = line1.Replace(" start ", " finish ");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else if ((line1.Contains(" start,") == true))
                    {
                        string replaced = line1.Replace(" start,", " finish,");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else if ((line1.Contains(" start.") == true))
                    {
                        string replaced = line1.Replace(" start.", " finish.");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else if ((line1.Contains(" start!") == true))
                    {
                        string replaced = line1.Replace(" start!", " finish!");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else if ((line1.Contains(" start?") == true))
                    {
                        string replaced = line1.Replace(" start?", " finish?");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else if (line1.Contains("\"start\"") == true)
                    {
                        string replaced = line1.Replace("\"start\"", "\"finish\"");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else if ((line1.Contains(" start:") == true))
                    {
                        string replaced = line1.Replace(" start:", " finish:");
                        Console.WriteLine(replaced);
                        exist = true;
                    }
                    else
                    {
                        Console.WriteLine(line1);
                    }
                    line1 = reader2.ReadLine();
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
