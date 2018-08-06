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
using System;
using System.Data.Entity.Migrations;
using LMS_Population.Models;
using LMS_Population.Models.CourseData;

namespace LMS_Population
{
    
    public class Parse_Pop_App
    {
        public string Txt_FilePath { get; set; }
        List<string> courseData = new List<string>();
        LMS_PopulationDbContext db = new LMS_PopulationDbContext();
        //=======================
        //      Main Method
        //=======================
        
        public void PopulateInputTxt()
        {
            Read();
            Sort(linesList);
            Write(sortedPages, courseData);
            Display();
        }

        //======================
        //  Method Variables
        //======================

        string[] textLines = new string[0];
        List<string> linesList = new List<string>();
        List<List<string>> pageList = new List<List<string>>();
        List<List<StringBuilder>> compiledPages = new List<List<StringBuilder>>();
        List<List<StringBuilder>> sortedPages = new List<List<StringBuilder>>();


        List<string> typeList = new List<string>();
        List<string> fieldsList = new List<string>();

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
            SortSeparatePages();
            SortCompileFields();
            SortCleanUp();
        }

            //===========================================
            //  SubSort: Separate 'linesList' into Pages
            //  Add 'pageFields' to 'pageList'
            //===========================================

            public void SortSeparatePages()
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

            //=================================================
            //  SubSort: Compile Fields of 'pageList' Elements
            //  Add 'compiledFields' to 'compiledPages'
            //=================================================

            public void SortCompileFields()
            {
                //  Local Variables
                int fieldNumber = -1;
                int pageNumber = 0;
                StringBuilder newField = new StringBuilder();
                List<StringBuilder> compiledFields = new List<StringBuilder>();
                //List<StringBuilder> cleanFields = new List<StringBuilder>();

                // Loop Through Pages
                foreach (var page in pageList)
                {
                    //  Loop Through Fields of 'page'
                    for (int i = 0; i < page.Count(); i++)
                    {
                        //  New Field Detected
                        if (page.ElementAt(i) == "#")
                        {
                            newField = new StringBuilder();
                            fieldNumber++;
                        }
                        //  New Field Detected
                        else if (page.ElementAt(i) != "#" && page.ElementAt(i) == page.First())
                        {
                            newField = new StringBuilder();
                            compiledFields.Add(newField.Append(page.ElementAt(i)));
                            fieldNumber++;
                        }
                        //  Start Field
                        else if (page.ElementAt(i) != "#" && page.ElementAt(i - 1) == "#")
                        {
                            compiledFields.Add(newField.Append(page.ElementAt(i)));
                        }
                        //  Cont. Field Detected
                        else if (page.ElementAt(i) != "#" && page.ElementAt(i - 1) != "#" && !page.ElementAt(i).StartsWith("*"))
                        {
                            compiledFields.LastOrDefault().Append(" " + page.ElementAt(i));
                        }
                        //  Cont. Field Detected
                        else if (page.ElementAt(i) != "#" && page.ElementAt(i).StartsWith("*"))
                        {
                            newField = new StringBuilder();
                            compiledFields.Add(newField.Append(page.ElementAt(i)));
                            fieldNumber++;
                        }
                    }
                    //  Clean Empty Fields/Pages
                    if (compiledFields.Count > 1)
                    {
                        pageNumber++;
                        StringBuilder pageNumElement = new StringBuilder();
                        pageNumElement.Append("Page Number: " + pageNumber.ToString());
                        compiledFields[0] = pageNumElement;
                        compiledPages.Add(compiledFields);
                    }

                    //  Reset Local Variables
                    compiledFields = new List<StringBuilder>();
                    newField = new StringBuilder();
                    fieldNumber = -1;
                }
            }

            //=======================================================
            //  SubSort: Clean Up Sort (empty pages, fields, etc..)
            //=======================================================

        public void SortCleanUp()
            {
                foreach (var page in compiledPages)
                {
                    if (page.Count > 0)
                    {
                        sortedPages.Add(page);
                    }
                }
            }

        //=======================================================
        //  Write
        //=======================================================

            // ********************************************
            //**********************************************
            //             DataBase Table Drop
                        bool dropDb_Switch = true;
                        public void DropDb()
                                {
                                    db.Course.RemoveRange(db.Course);
                                    db.Page.RemoveRange(db.Page);
                                    db.PageField.RemoveRange(db.PageField);
                                    db.TestAnswer.RemoveRange(db.TestAnswer);
                                    db.TestQuestion.RemoveRange(db.TestQuestion);
                                    db.SaveChanges();
                                }
            //**********************************************
            // ********************************************
        
        

            // <param name="_sortedPages"></param>
            // <param name="_courseData"></param>
        public void Write(List<List<StringBuilder>> _sortedPages, List<String> _courseData)
        {
            //  Drop Database Switch Fnx
            if (dropDb_Switch) DropDb();
            //  Populate Course
            string courseNameInputVal = "Computer_Basics";
            Id_Courses_Prop(courseData, out string courseIdGenerated, courseNameInputVal);

            foreach (List<StringBuilder> page in sortedPages)
            {
                Id_Pages_Prop(page, out Page _nPage, courseIdGenerated);

                //  Test Page?
                if (page.ToString().Contains("QUIZ:")) Id_Tests_Prop(page, _nPage);

                //  Video Page?
                else if (page.ToString().Contains("Watch the following")) Id_Video_Prop(_nPage);

                //  Norm Page?
                else Id_PageFields_Prop(page, _nPage);

            }
        }

        //  Identify Course Properties
        public void Id_Courses_Prop(List<string> CourseData, out string _courseIdGuid, string _courseName = "no_input_Provided") 
        {
            Course nCourse = new Course
            {

                //  CourseId
                
                //  Automatic from Course Object Constructor
                //  CourseName
                CourseName = _courseName
                //  CourseDescription
                //  CourseToComplete
                //  ImageUrl
                //  Core
                //  UniversityOfConcordia
                //  FreeCourse
                //  SandBox
                //  TechAcademy
                //  CoursePosition
            };

            //  WRITE
            db.Course.Add(nCourse);
            db.SaveChanges();

            _courseIdGuid = nCourse.CourseId;
        }

        //  Identify Page Properties
        public void Id_Pages_Prop(List<StringBuilder> _ListPage, out Page _nPage, string _courseIdInput = "no_input_provided")
        {
            Page nPage = new Page
            {
                //  PageId [key]
                    //  Automatic from Page Object Constructor
                //  CourseId
                CourseId = _courseIdInput,
                //  PageNumber
                PageNumber = Convert.ToInt32(_ListPage.ElementAt(0).ToString().Substring(13).Trim())
            };
            // IsTest
            nPage.IsTest = false;
            foreach (var field in _ListPage)
            {
                if (field.ToString().Contains("QUIZ:")) nPage.IsTest = true;
            }

            //  WRITE
                db.Page.Add(nPage);
                db.SaveChanges();

            //  Output
            _nPage = nPage;
        }

        //  Identify Field Properties
        public void Id_PageFields_Prop(List<StringBuilder> _PageList, Page _Page)
        {
            int fieldCount = 0;

            foreach (StringBuilder field in _PageList)
            {
                //  Convert StringBuilder to String
                string _nField = field.ToString();
                //  ID Field Type
                string fieldType;
                if (_Page.IsTest) fieldType = "Test";
                else if (_nField.EndsWith(":")) fieldType = "Definition";
                else if (_nField.StartsWith("1.") && _PageList.ToString().Contains("?")) fieldType = "Question";
                else fieldType = "Paragraph";

                PageField nField = new PageField
                {

                    //  PageFieldId
                    //  Automatic from Constructor
                    //  PageId
                    PageId = _Page.PageId,
                    //  BooleanQuestionId

                    //  FieldType
                    FieldType = fieldType,
                    //  Content
                    Content = _nField,
                    //  FinalEssay

                    //  FieldNumber
                    FieldNumber = fieldCount
                    //  FieldTitle

                    //  FieldTitle

                    //  FieldReference

                };
                fieldCount++;
            }
   


        }

        //  Identify Test Properties
        public void Id_Tests_Prop(List<StringBuilder> _ListPage, Page _Page)
        {
            Id_TestQuestions_Prop(_ListPage, _Page, out string _PageId);
            Id_QuestionChoices_Prop(_Page);
        }

            //  Identify Test Question Properties
            public void Id_TestQuestions_Prop(List<StringBuilder> _TestQuestion, Page _Page, out string _PageId)
            {
            TestQuestion nPage = new TestQuestion
            {
                //  TestQuestionId
                    //  Automatic From Constructor
                //  PageId
                PageId = _Page.PageId,
                //  Question
                Question = _TestQuestion.ElementAt(1).ToString(),
                //  OptionalText

                //  QuestionNumber

            };
      

            _PageId = nPage.PageId;
            }

            //  Indentify Test Question Choices
            public void Id_QuestionChoices_Prop(Page _page)
            {
                //  QuestionChoiceId
                //  TestQuestionId
                //  BooleanQuestionId
                //  Choice
                //  CorrectChoice
            }
            
        //  Identify Other Page Types for Custom Population
        //  Identify Video Properties
        public void Id_Video_Prop(Page _page)
        {
               
        }

        //=========================================
        //  Write Pages to DB
        //=========================================



        //=========================================
        //  Display Results
        //=========================================

        public void Display()
        {
            System.Diagnostics.Debug.WriteLine("Compiled PAGE COUNT: " + compiledPages.Count());
            System.Diagnostics.Debug.WriteLine("List PAGE COUNT2: " + pageCount2);

            bool printCompare = false;
            bool printSection = false;
            bool printCompiled = true;

            //=========================================================
            //      Compare Single Pages (A and B)
            //=========================================================
            if (printCompare)
            {
                //  Print Page A
                System.Diagnostics.Debug.WriteLine("$$$$$$$$  PAGE A  $$$$$$%$%$%$$");
                int pageA = 786;
                int pageB = 787;

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
                System.Diagnostics.Debug.WriteLine("$$$$$$$$  PAGE B  $$$$$$%$%$%$$");
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
                System.Diagnostics.Debug.WriteLine("$$$$$$$$$$  END SINGLE PAGE PRINT  $$$$$$$$$$");
            }

            //=========================================================
            //      Print Uncompiled Section of Pages (A-B)
            //=========================================================
            if (printSection)
            {
                int pageA = 783;
                int pageB = 788;
                int pageN = pageA;
            
                while (pageN <= pageB)
                {
                    System.Diagnostics.Debug.WriteLine("===============================");
                    foreach (var field in compiledPages.ElementAt(pageN))
                    {
                        System.Diagnostics.Debug.WriteLine(field);
                    }
                    pageN++;
                }
                System.Diagnostics.Debug.WriteLine("$$$$$$$$$$  END SECTION PRINT  $$$$$$$$$$");
            }

            //=========================================================
            //      Print All Compiled Pages
            //=========================================================
            if (printCompiled)
            {
                foreach (var page in sortedPages)
                {
                    System.Diagnostics.Debug.WriteLine("=============================");
                    foreach (var field in page)
                    {
                        System.Diagnostics.Debug.WriteLine(field);
                    }
                }
                System.Diagnostics.Debug.WriteLine("$$$$$$$$ END OF DISPLAY() $$$$$$%$%$%$$");
            }
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