using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Recovery_Console
{
    class StringGroup
    {
        public int Count { get; set; }
        public int Type { get; set; }
        public int Text { get; set; }
    }

    class ParseMethods
    {
        string[] textLines = new string[0];
        List<string> linesList = new List<string>();


        public void Read()
        {
            string[] textLines = System.IO.File.ReadAllLines(@"C:\Users\gates\Documents\GatesKennedy\LMS_Recovery_Console\LMS_Recovery_Console\CompBasics.txt");
            for (int i = 0; i < textLines.Length; i++)
            {
                if (textLines[i] != null)
                {
                    linesList.Add(textLines[i]);
                }
            }

        }

        public void Sort()
        {
            foreach (string line in linesList)
            {

            }
        }

        public void Display()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(linesList.ElementAt(i));
            }


        }
    }
}
