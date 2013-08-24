//Write a program that extracts from given XML file all the text without the tags.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        XmlDocument document = new XmlDocument();
        document.Load("../../index.xml");
        List<string> extractedText = new List<string>();
        foreach (XmlNode node in document.DocumentElement.ChildNodes)
        {
            extractedText.AddRange(ExtractText(node));
        }
        foreach (string text in extractedText)
        {
            Console.WriteLine(text);
        }
    }

    private static List<string> ExtractText(XmlNode currentNode)
    {
        if (currentNode.ChildNodes.Count > 1)
        {
            List<string> currentChildNodes = new List<string>();
            foreach (XmlNode node in currentNode.ChildNodes)
            {
                currentChildNodes.AddRange(ExtractText(node));
            }
            return currentChildNodes;
        }

        return new List<string> { currentNode.InnerText };
    }
}
