using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class TwoInOne
{
    static void Main()
    {
        Console.WriteLine("This program opens 2 files and concatinates them in third. \n");
        
        string file1 = @"FirstFile.txt";
        string file2 = @"SecondFile.txt";
        try
        {
            StreamReader reader1 = new StreamReader(file1, Encoding.GetEncoding("Windows-1251"));
            StreamReader reader2 = new StreamReader(file2, Encoding.GetEncoding("Windows-1251"));
            Console.WriteLine("File {0} and file {1} successfully opened.\n", file1, file2);
            
            string fileConc = @"ThirdFile.txt";
            StreamWriter writer = new StreamWriter(fileConc, false, Encoding.GetEncoding("Windows-1251"));

            using (reader1)
            {
                using (reader2)
                {
                    using (writer)
                    {
                        string line;
                        while ((line = reader1.ReadLine()) != null)
                        {
                            writer.WriteLine(line);
                        }

                        string line1;
                        while ((line1 = reader2.ReadLine()) != null)
                        {
                            writer.WriteLine(line1);
                        }

                    }
                }
            }
            StreamReader readerConc = new StreamReader(fileConc, Encoding.GetEncoding("Windows-1251"));
            using (readerConc)
            {
                Console.WriteLine("New file {0} successfully created and opened.\n", fileConc);
                Console.WriteLine(readerConc.ReadToEnd());
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
