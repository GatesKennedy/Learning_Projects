using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LMS_Population
{
    public class Parse_Pop_App
    {
        public string Txt_FilePath { get; set; }

        //=======================
        //      Main Method
        //=======================

        private void PopulateInputTxt()
        {
            Read();
            Sort(linesList);
            //Write();
            Display();
        }

        //======================
        //  Method Variables
        //======================

        string[] textLines = new string[0];
        List<string> linesList = new List<string>();
        List<List<string>> pageList = new List<List<string>>();
        List<List<StringBuilder>> compiledPages = new List<List<StringBuilder>>();

        List<string> typeList = new List<string>();
        List<string> fieldsList = new List<string>();

        int messageID = 1;
        int fieldID = 0;
        int pageCount = 1;
        int pageCount2 = 1;

        //================================================
        //  Read and Translate/Reduce .txt Array[string]
        //================================================

        public void Read()
        {
            int pageCount = 0;
            //  Populate 'textLines' Array from .txt document
            string[] textLines = System.IO.File.ReadAllLines(@"C:\Users\gates\Documents\GatesKennedy\CompBasics.txt");
            //  Reduce Elements of 'textLines' to 'linesList'
            for (int i = 0; i < textLines.Length; i++)
            {
                //  Line is not empty
                if (textLines[i] != "")
                {
                    //  Line is the Start of a new Page
                    if (textLines[i].Contains("1.") && textLines[i].Contains("<") && textLines[i].Contains(">"))
                    {
                        pageCount++;
                        textLines[i] = "$$$";
                        linesList.Add("$$$ Page: " + pageCount.ToString() + " Line: " + i.ToString());  // New Page Symbol ($$$ pg#)
                    }
                    //  Submodules or Titleless Pages
                    else if (textLines[i].Contains("SUBMODULE") || textLines[i].Trim() == "1.")
                    {
                        pageCount++;
                        textLines[i] = "$$$";
                        linesList.Add("$$$ Page: " + pageCount.ToString() + " Line: " + i.ToString());  // New Page Symbol ($$$ pg#)
                    }
                    // Valid Text Content
                    else
                    {
                        linesList.Add(textLines[i]); // Text Content
                    }
                }
                //  Line is Empty
                else if (textLines[i] == "" && textLines[i - 1] != "#")
                {
                    textLines[i] = "#";
                    linesList.Add("#");  // New Field Symbol (#)
                }
                //  Redundant Line is Empty
                else if (textLines[i] == "" && textLines[i - 1] == "#")
                {
                    // Do Nothing
                }
            }
            //  WriteLine Elements of 'linesList'
                /*foreach (string line in linesList) {Console.WriteLine(line); System.Diagnostics.Debug.WriteLine(line)}*/
       
            //  Reset 'pageCount'
            pageCount = 0;
        }

        //=========================================
        //  Sort Text Array
        //=========================================

        public void Sort(List<string> lines)
        {
            SeparatePages();
            CompileFields();
            IdentifyProperties();
        }

        //===================================
        //  SubSort: Separate 'linesList' into Pages
        //===================================

        public void SeparatePages()
        {
            List<string> pageFields = new List<string>();
            // Separate Pages
            for (int j = 0; j < linesList.Count; j++)
            {
                //  No Page Flag Detected
                if (!linesList.ElementAt(j).Contains("$$$"))
                {
                    pageFields.Add(linesList.ElementAt(j));
                }
                // Page Flag Detected
                else if (linesList.ElementAt(j).Contains("$$$"))
                {
                    //  Add Collected 'pageFields'
                    pageList.Add(pageFields);
                    //  Reset 'pageFields' Collection
                    pageFields = new List<string>();
                    //  Increment Page Count
                    pageCount2++;
                    pageFields.Add("Page Number: " + pageCount2);
                    pageFields.Add("#");
                }
            }
            // Count Pages
            pageCount = pageList.Count();
        }

        //=========================================
        //  SubSort: Compile Fields of 'pageList' Elements
        //=========================================

        public void CompileFields()
        {
            //  Local Variables
            int fieldNumber = -1;
            StringBuilder newField = new StringBuilder();
            List<StringBuilder> compiledFields = new List<StringBuilder>();

            // Loop Through Pages
            foreach (var page in pageList)
            {
                //  Loop Through Fields of 'page'
                for (int i = 0; i < page.Count(); i++)
                {
                    // New Field Detected
                    if (page.ElementAt(i) == "#")
                    {
                        newField = new StringBuilder();
                        fieldNumber++;
                    }
                    else if (page.ElementAt(i) != "#" && page.ElementAt(i) == page.First())
                    {
                        newField = new StringBuilder();
                        compiledFields.Add(newField.Append(page.ElementAt(i)));
                        fieldNumber++;
                    }
                    // Start Field
                    else if (page.ElementAt(i) != "#" && page.ElementAt(i - 1) == "#")
                    {
                        compiledFields.Add(newField.Append(page.ElementAt(i)));
                    }
                    // Cont. Field Detected
                    else if (page.ElementAt(i) != "#" && page.ElementAt(i - 1) != "#" && !page.ElementAt(i).StartsWith("*"))
                    {
                        compiledFields.LastOrDefault().Append(" " + page.ElementAt(i));
                    }
                    else if (page.ElementAt(i) != "#" && page.ElementAt(i).StartsWith("*"))
                    {
                        newField = new StringBuilder();
                        compiledFields.Add(newField.Append(page.ElementAt(i)));
                        fieldNumber++;
                    }
                }
                //  Create New Page and Reset Local Variables
                compiledPages.Add(compiledFields);
                compiledFields = new List<StringBuilder>();
                newField = new StringBuilder();
                fieldNumber = -1;
            }
        }

        //=========================================
        //  SubSort: Identify Field Properties
        //=========================================

        public void IdentifyProperties()
        {
            Id_Courses_Prop();
            Id_Pages_Prop();
            Id_PageFields_Prop();
            //Id_Tests_Prop();
        }

        public void Id_Courses_Prop()
        {

        }

        public void Id_Pages_Prop()
        {

        }

        public void Id_PageFields_Prop()
        {

        }

        public void Id_Tests_Prop()
        {

        }

        public void Id_TestQuestions_Prop()
        {

        }

        public void Id_TestAnswers_Prop()
        {

        }
        //=========================================
        //  Write Pages to DB
        //=========================================



        public void Write()
        {

        }

        //=========================================
        //  Display Results
        //=========================================

        public void Display()
        {
            System.Diagnostics.Debug.WriteLine("PAGE COUNT: " + pageCount);
            System.Diagnostics.Debug.WriteLine("PAGE COUNT2: " + pageCount2);

            //==============================================================
            //  Print Page A
            System.Diagnostics.Debug.WriteLine("$$$$$$$$ LOOK AT ME $$$$$$%$%$%$$");
            int pageA = 578;
            //  Uncompiled Page A
            foreach (var line in pageList.ElementAt(pageA))
            {
                System.Diagnostics.Debug.WriteLine(line);
            }
            //  Compiled Page A
            foreach (var field in compiledPages.ElementAt(pageA))
            {
                System.Diagnostics.Debug.WriteLine(field);
            }
            // Print Page B
            System.Diagnostics.Debug.WriteLine("$$$$$$$$ LOOK AT ME AGAIN $$$$$$%$%$%$$");
            int pageB = 3;
            // Uncompiled Page B
            foreach (var line in pageList.ElementAt(pageB))
            {
                System.Diagnostics.Debug.WriteLine(line);
            }
            //  Compiled Page B
            foreach (var field in compiledPages.ElementAt(pageB))
            {
                System.Diagnostics.Debug.WriteLine(field);
            }
            //===========================================================================
            foreach (var page in compiledPages)
            {
                System.Diagnostics.Debug.WriteLine("============================= \n =============================");
                foreach (var field in page)
                {
                    System.Diagnostics.Debug.WriteLine(field);
                }
            }
            System.Diagnostics.Debug.WriteLine("$$$$$$$$ END OF DISPLAY() $$$$$$%$%$%$$");
        }

        //=============================================================
        //======================== END ================================
        //============================================  ====  =========
        //======================== OF =================================
        //=============================================================
        //======================= PARSE ============  ========  =======
        //============================================        =========
        //======================= SCRIPT ==============================
        //=============================================================
    }
}