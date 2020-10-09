/*
 * Al Curry   
 * October 8, 2020 
 * 
 * BankOCR problem - defined in detail at url below, also .pdf file in repository.
 * https://ccd-school.de/en/coding-dojo/application-katas/bankocr/
 * 
 * Main program - reads and processes input, limited error checking, outputs results.
 * 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OCRchallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            /* 
               Imperfect to hard-code the input file, but here
               overriding it with user input is possible.
               Using built-in functions to obtain the local project path could be better.
            */

            string path = @"/Users/alcurry/Projects/bankOCR/OCRinput.txt";
            Console.WriteLine("default input file is : " + path);
            Console.WriteLine("to use it, press enter, or enter your full path and filename");
            string newPath = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(newPath))
                path = newPath;

            if (!File.Exists(path))
            {
                Debug.WriteLine("Where you at ?");
            }

            List<string> lines = File.ReadLines(path).Where(line => line != "").ToList();
            Debug.WriteLine(lines.Count + " lines in input file");


            for (int i = 0; i <= lines.Count - 1; i++)
            {
                Debug.Write(lines[i]);
                Debug.WriteLine(lines[i].Length);
            }

            matrixItem digit = new matrixItem();

            for (int l = 0; l < lines.Count; l += 3)
            {
                int x = 0;
                int value = 0;
                string strResult = "";
                /*
                 Assume no blank columns between characters
                 requirements inconsistent (written description vs. sample input file),
                 this approach probably makes more sense for a real application.

                 Calculating "charCount" this way, diving by 3, since the matrix is 3
                 characters wide.  Problem description states errors are limited -
                 "the characters inside the 3 x 3 matrix may not be valid" - this is checked
                 in the toDigit method in the matrixItem class.        
                */

                int charCount = lines[l].Length / 3;
                do
                {
                    digit = matrixItem.getItem(lines, l, x);
                    value = matrixItem.toDigit(digit);
                    x++;

                    // convert each digit returned to a string, final output for each line
                    // is a string, check for errors from each 3x3 matrix
                    strResult = strResult + value.ToString();

                    if (value == -1)
                    {
                        Console.WriteLine("Error in data");
                        break;
                    }
                } while (x < charCount);

                // No errors from "toDigit" above
                if (value > -1)
                    Console.WriteLine(strResult);

                Debug.WriteLine("Debug DO");
            }


        }

    }
}
