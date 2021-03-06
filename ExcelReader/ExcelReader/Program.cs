﻿//CS350 Spring 2014
//CS Connect Group 3
//This program is for opening an Excel Spreadsheet and reading data from it
//It will be used to get student info from the roster spreadsheets and put into 
//the access database 


#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;




namespace ExcelReader
{
    class Program
    {
        static void Main()
        {}
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.AutoFlush = true;

            //Open a the workbook
            public static Workbook openWorkbook()
            {

                //create the Application object we can use in the member functions.
                Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
                _excelApp.Visible = true;

                string fileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\ExcelReader\\CS141roosterTest.xlsx";

                //open the workbook
                Workbook workbook = _excelApp.Workbooks.Open(fileName,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                return workbook;

            }


            //Open the first worksheet and get the information
            //For now I will try to have as parameters the fields I want to get out of the excel document
            //public static object[,] 
            public static void readWorksheet(Workbook workbook, out string[] Course, out string[] IndividualID, out string[] LastName, out string[] FirstName, out string[] Email)
            {
                
            
                //select the first sheet        
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                //find the used range in worksheet
                Range excelRange = worksheet.UsedRange;

                //get an object array of all of the cells in the worksheet (their values)
                object[,] valueArray = (object[,])excelRange.get_Value(
                            XlRangeValueDataType.xlRangeValueDefault);

                //make an array of all the data in each of the columns
                string[] YT = new string[worksheet.UsedRange.Rows.Count];
                string[] MatchCourse = new string[worksheet.UsedRange.Rows.Count];
                string[] Department = new string[worksheet.UsedRange.Rows.Count];
                Course = new string[worksheet.UsedRange.Rows.Count];
                string[] Section = new string[worksheet.UsedRange.Rows.Count];
                string[] FinalGrade = new string[worksheet.UsedRange.Rows.Count];
                IndividualID = new string[worksheet.UsedRange.Rows.Count];
                string[] Classification = new string[worksheet.UsedRange.Rows.Count];
                string[] EnrollmentStatus = new string[worksheet.UsedRange.Rows.Count];
                LastName = new string[worksheet.UsedRange.Rows.Count];
                FirstName = new string[worksheet.UsedRange.Rows.Count];
                string[] Nickname = new string[worksheet.UsedRange.Rows.Count];
                string[] Phone = new string[worksheet.UsedRange.Rows.Count];
                Email = new string[worksheet.UsedRange.Rows.Count];
                string[] Notes = new string[worksheet.UsedRange.Rows.Count];
                
               
                //access the cells
                for (int row =1; row < worksheet.UsedRange.Rows.Count; ++row)
                {
                    
                    
                    int col = 1;
                    YT[row] = valueArray[row,col].ToString();
                    MatchCourse[row] = valueArray[row,++col].ToString();
                    Department[row] = valueArray[row,++col].ToString();
                    Course[row] = valueArray[row,++col].ToString();
                    Section[row] = valueArray[row,++col].ToString();
                    FinalGrade[row] = valueArray[row, ++col].ToString();
                    IndividualID[row] = valueArray[row, ++col].ToString();
                    Classification[row] = valueArray[row, ++col].ToString();
                    EnrollmentStatus[row] = valueArray[row, ++col].ToString();
                    LastName[row] = valueArray[row, ++col].ToString();
                    FirstName[row] = valueArray[row, ++col].ToString();
                    Nickname[row] = valueArray[row, ++col].ToString();
                    Phone[row] = valueArray[row, ++col].ToString();
                    Email[row] = valueArray[row, ++col].ToString();
                    Notes[row] = valueArray[row, ++col].ToString();


                }
                //clean up stuffs
                workbook.Close(false, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(workbook);

                //return valueArray;



                //_excelApp.Quit();
                //Marshal.FinalReleaseComObject(_excelApp);
            }
        
    }
}
