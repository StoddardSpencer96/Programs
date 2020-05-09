//
// Created by w0286670 on 12/5/2019.
//

#ifndef CONVERSION_CONVERTFILE_H
#define CONVERSION_CONVERTFILE_H

#include <iostream>
#include <fstream>
#include <exception>
using namespace std;

//Declare variables
string extension = ".html"; //ex: .html
string nameInput = ""; //for file input
string nameOutput = ""; //for file output
string outputFile; //make this equal to nameOutput to use in output stream
char c; //represents each character in the file
ifstream inputStream;
ofstream outputStream;

//Create my own exception
struct fileException {
    const char* message;
    fileException(): message("Error opening the file.") {
    }

};

void openAndReadFile() {
    //User prompted to enter input file name
    cout << "Please enter the file name you wish to use: (enter name of file, and the file type. Ex: hello.cpp)" << endl;
    cin >> nameInput;

    //try to open the file
    //If it doesn't fail, open the file
    try {
        if (!inputStream.fail()) {
            inputStream.open(nameInput);
        }
    }

    //Catch the exception if the file doesn't exist, or fails
    catch (fileException myException) {
        cout << myException.message << endl;
    }
    //User prompted to enter output file name
    cout << "Please enter the output file name: (only enter the name of the file. Ex: helloTwo)" << endl;
    cin >> nameOutput;
}

//Used this as reference to get each character from the file:
// http://www.cplusplus.com/reference/istream/istream/get/

void writeToFile() {
    //Create the output file
    outputFile = nameOutput + extension;
    try { //try to open the output file
        outputStream.open(outputFile);
        if (!outputStream.fail()) { //if the file doesn't fail, read the whole file
            while (!inputStream.eof()) { //while it's going through the file
                outputStream << "<PRE>" << endl; //add the <PRE> tag at the beginning of the file
                for (c; inputStream.get(c);) { //for each character it goes through, get the character
                    switch (c) {
                        case '<': //change any "<" into &lt;
                            outputStream << "&lt;";
                            break;
                        case '>': //change nay ">" into &gt;
                            outputStream << "&gt;";
                            break;
                        default: //print out the rest of the characters as is
                            outputStream << c;
                    }
                }
                outputStream << "</PRE>"; //add the </PRE> tag at the end of the file
            }
        }
    }
    //catch the error
    catch (exception e) {
        cout << e.what() << endl;
    }
} //end writeToFile

void closeTheFile() {
    //try to close the file
    try {
        inputStream.close();
        outputStream.close();
    }
    //catch the error
    catch (...) {
        cout << "Error closing the file." << endl;
    }
} //end closeTheFile


#endif //CONVERSION_CONVERTFILE_H
