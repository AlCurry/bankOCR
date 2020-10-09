/*
 * Al Curry   
 * October 8, 2020 
 * 
 * BankOCR problem - defined in detail at url below, also .pdf file in repository.
 * https://ccd-school.de/en/coding-dojo/application-katas/bankocr/
 * 
 * MatrixItem class - defines a character matrix and associated methods
 * 
 */


using System.Diagnostics;
using System.Collections.Generic;

namespace OCRchallenge
{
    public class matrixItem
    {
        public string Row1 { get; set; }
        public string Row2 { get; set; }
        public string Row3 { get; set; }
        public int ErrorCode { get; set; }

        public matrixItem(string row1, string row2, string row3, int errorCode)
        {
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
            ErrorCode = errorCode;
        }

        public matrixItem()
        {
        }
        public static matrixItem getItem(List<string> lines, int l, int x)
        {
            //Console.WriteLine("l = " + l);

            string line0, line1, line2;
            int index = x * 3;

            line0 = lines[l].Substring(index, 3);
            line1 = lines[l + 1].Substring(index, 3);
            line2 = lines[l + 2].Substring(index, 3);

            matrixItem ocrDigit = new matrixItem(line0, line1, line2, 0);

            return ocrDigit;

        }
        public static int toDigit(matrixItem ocrDigit)
        {
            int value = -1;

            // all the parentheses seem to be needed - otherwise errors
            if ((ocrDigit.Row1.Equals("   ")) &
                (ocrDigit.Row2.Equals("  |")) &
                (ocrDigit.Row3.Equals("  |")))
            {
                value = 1;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals(" _|")) &
                     (ocrDigit.Row3.Equals("|_ ")))
            {
                value = 2;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals(" _|")) &
                     (ocrDigit.Row3.Equals(" _|")))
            {
                value = 3;
            }
            else if ((ocrDigit.Row1.Equals("   ")) &
                     (ocrDigit.Row2.Equals("|_|")) &
                     (ocrDigit.Row3.Equals("  |")))
            {
                value = 4;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals("|_ ")) &
                     (ocrDigit.Row3.Equals(" _|")))
            {
                value = 5;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals("|_ ")) &
                     (ocrDigit.Row3.Equals("|_|")))
            {
                value = 6;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals("  |")) &
                     (ocrDigit.Row3.Equals("  |")))
            {
                value = 7;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals("|_|")) &
                     (ocrDigit.Row3.Equals("|_|")))
            {
                value = 8;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals("|_|")) &
                     (ocrDigit.Row3.Equals(" _|")))
            {
                value = 9;
            }
            else if ((ocrDigit.Row1.Equals(" _ ")) &
                     (ocrDigit.Row2.Equals("| |")) &
                     (ocrDigit.Row3.Equals("|_|")))
            {
                value = 0;
            }
            else
            {
                ocrDigit.ErrorCode = 1;
                Debug.WriteLine("Error in data: digit not recognized");
            }

            return value;
        }
    }
}
