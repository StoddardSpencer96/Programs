#include <iostream>
#include <fstream>
#include <exception>
using namespace std;

int main() {
    string nameInput; //for file input
    string nameOutput; //for file output
    string outputFile; //make this equal to nameOutput to use in output stream
    string extension; //ex: .html
    char c; //represents each character in the file

    ifstream inputStream;
    ofstream outputStream;

    cout << "Please enter the file name you wish to convert: (enter name of file, and the file type. Ex: hello.cpp)" << endl;
    cin >> nameInput;

    cout << "Please enter the output file name: (only enter the name of the file. Ex: helloTwo)" << endl;
    cin >> nameOutput;

    //try to open the file
    //If it fails, catch the error
    try {
        inputStream.open(nameInput.c_str());
      }
    catch (exception e) {
        cout << "Caught the error." << endl;
      }

    //create the output file
    outputFile = nameOutput + ".html";

    //If the file output doesn't fail, go through the whole file
    //Go through each individual character in the file
    //If the file has a "<", change it to &lt
    //Else, if the file has ">", change it to &gt
    //If it has neither, output the file as is

    try {
        outputStream.open(outputFile.c_str());
        if (!outputStream.fail()) {
            while (!inputStream.eof()) {
                for (char c; inputStream.get(c);) {
                   switch (c) {
                     case '<':
                     outputStream << "&lt;";
                     break;

                     case '>':
                     outputStream << "&gt;";
                     break;

                     default:
                     outputStream << c;
               }
             }
           }
         }
      }
    catch (...) {
        cout << "Error writing to file." << endl;
      }

    try {
        inputStream.close();
        outputStream.close();
      }
    catch (...) {
        cout << "Error closing the file." << endl;
        }
    }