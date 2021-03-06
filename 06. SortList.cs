/*Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
	Ivan			George
	Peter			Ivan
	Maria			Maria
	George			Peter
*/
// Make sure you have a file "Strings.txt" bin\Debug 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class SortsStrings
{
    static void Main()
    {
        PrintFile(ReadNames());
        Console.WriteLine("The strings are sorted successfully.");
    }
    static List<string> ReadNames()
    {
        List<string> unsorted = new List<string>();
        StreamReader names = new StreamReader("strings.txt", Encoding.GetEncoding("windows-1251"));
        using (names)
        {
            string currentLine;
            while ((currentLine = names.ReadLine()) != null)
            {
                unsorted.Add(currentLine);
            }
        }
        return unsorted;
    }
    static void PrintFile(List<string> sorted)
    {
        sorted.Sort();
        StreamWriter writer = new StreamWriter("output.txt", false, Encoding.GetEncoding("windows-1251"));
        using (writer)
        {
            for (int i = 0; i < sorted.Count; i++)
            {
                writer.WriteLine((sorted[i]));
            }

        }
    }
}
