#include <iostream>
#include <fstream>
#include <exception>
#include "ConvertFile.h"
using namespace std;

//Greet the user with a welcome message
//Call the functions used in the header file
//Thank the user for using the program

int main() {
    cout << "Welcome to the File Conversion Program." << endl;
    openAndReadFile();
    writeToFile();
    closeTheFile();
    cout << "Thank you for using the program." << endl;
}