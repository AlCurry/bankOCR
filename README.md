### BankOCR program - simplified Optical Character Recognition

#### Al Curry  

#### October 8, 2020 
---
<ins>Write a C# program to read digits represented as 3 x 3 matrix of characters</ins>
1. Detailed problem described in pdf in this repository.
1. Input file is OCRinput.txt in this repo, or similar, as described in pdf.
1. Main program reads non-blank lines of this file, and stores it as a linked list of strings.
1. The class MatrixItem defines the 3 x 3 matrix, and methods getItem and toDigit.
1. For each 3 lines of input, get the next 3 x 3 matrix item, and convert it to a digit.



#### Design / Code Descriptrion
---
1.  2 code files, Program.cs and MatrixItem.cs, in directory bankOCR.
1.  Main program 
    - reads input file, storing as a linked list of strings
    - for every 3 lines, extract the next 3 characters, to get the 3 x 3 matrix 
    - convert the item of characters to the correct digit, flagging errors
1.  Class MatrixItem 
    - define string rows 1-3 of the matrix and integer error code value
    - define constructors
    - static method getItem, parses a 3 x 3 matrix from the List structure 
    - static method toDigit, converts 3 x 3 matrix characters to a digit
      (sort of messy but could be worse)
1.  Screenshot of output - output.png.

<ins>Disclaimers</ins>

The description in the pdf file and page with test data are not consistent with regard to blanks between characters.  Since it was a sample input file, I coded for no blanks between characters, to work with the sample input file.

Debug messages are written with Debug.WriteLine, which prints the text to Application Output terminal in Visual Studio IDE.

Ideally file input would be simpler for the user.  There is some flexibility, which allows user to enter their own full path and file name, the default is for my development environment.  At least a standard default path determined by system variables could be better, but unclear if parsing out part of it would be consistent on both mac and windows.    

It’s been some time since I studied C# or worked with Microsoft Visual Studio.  Uncertain about commenting standards at your organization, most places i’ve worked this was encouraged.  I’ve read about clean code and see that commenting is sometimes discouraged.  Glad to adapt to a company’s coding standard.  Aware of xml commenting in C#, and can see its merits, but here used classic format comments.
