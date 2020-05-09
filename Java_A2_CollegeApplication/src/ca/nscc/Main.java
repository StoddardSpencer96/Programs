package ca.nscc;

import javax.swing.*;
import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        // write your code here

        //Create an array holding the three options: Student, Staff and Finish
        //This will be displayed at the start of the GUI application
        Object[] theOptions = {"Student", "Staff", "Finish"};

        //Create Array List for the Students and Staff
        ArrayList<Student> theStudents = new ArrayList<>();
        ArrayList<Staff> theStaff = new ArrayList<>();

        //GUI for Start of Application
        //Do all of the lines of code inside this statement
        do {
            //User is prompted to select Student, Staff or Finish if they choose neither Student or Staff
            int result = JOptionPane.showOptionDialog(null,
                    "Select Student or Staff",
                    "College Application App",
                    JOptionPane.DEFAULT_OPTION,
                    JOptionPane.QUESTION_MESSAGE,
                    null,
                    theOptions,
                    theOptions[0]);

            //If the user selects Student:
            if (result == 0) {
                //GUI for student's first + last name input
                String studentFirstNameInput =
                        JOptionPane.showInputDialog(null,
                                "Enter the Student's First Name ");
                //While the input is an empty string, prompt the user to let them know it's not valid.
                while (studentFirstNameInput.equals("")) {
                    JOptionPane.showMessageDialog(null, "Please enter a valid first name. ");
                    //Prompt the user to enter the value again.
                    studentFirstNameInput =
                            JOptionPane.showInputDialog(null,
                                    "Enter the Student's First Name ");
                }
                String studentLastNameInput =
                        JOptionPane.showInputDialog(null,
                                "Enter the Student's Last Name ");
                while (studentLastNameInput.equals("")) {
                    JOptionPane.showMessageDialog(null, "Please enter a valid last name. ");
                    //Prompt the user to enter the value again.
                    studentLastNameInput =
                            JOptionPane.showInputDialog(null,
                                    "Enter the Student's Last Name ");
                }
                //GUI for student address input
                String studentAddressInput =
                        JOptionPane.showInputDialog(null,
                                "Enter Student Address ");
                //While the input is equal to an empty string, prompt the user notifying an error.
                while (studentAddressInput.equals("")) {
                    JOptionPane.showMessageDialog(null, "Please enter a valid address. ");
                    //Prompt the user to enter the value again.
                    studentAddressInput =
                            JOptionPane.showInputDialog(null,
                                    "Enter the Student's Address ");
                }
                //GUI for Student Year Input
                int studentYearInput = 0;
                studentYearInput = Integer.parseInt(String.valueOf(studentYearInput)); //this returns the value of the integer as a String
                JOptionPane.showInputDialog(null,
                        "Enter Student Year (1-4) ");

                //Add all of the values the user inputted into the "theStudents" array
                theStudents.add(new Student(studentFirstNameInput, studentLastNameInput, studentAddressInput, studentYearInput));
            }
            //Else, if the user selects Staff
            else if (result == 1) {
                //GUI for staff name input
                String staffFirstNameInput =
                        JOptionPane.showInputDialog(null,
                                "Enter the Staff's First Name ");

                //While the input is an empty string, prompt the user to let them know it's not valid.
                while (staffFirstNameInput.equals("")){
                    JOptionPane.showMessageDialog(null, "Please enter a valid first name. ");
                    //Prompt the user to enter the value again.
                    staffFirstNameInput =
                            JOptionPane.showInputDialog(null,
                                    "Enter the Staff's First Name ");
                }
                String staffLastNameInput =
                        JOptionPane.showInputDialog(null,
                                "Enter the Staff's Last Name ");
                //While the input is an empty string, prompt the user to let them know it's not valid.
                while (staffLastNameInput.equals("")){
                    JOptionPane.showMessageDialog(null, "Please enter a valid last name. ");
                    //Prompt the user to enter the value again
                    staffLastNameInput =
                            JOptionPane.showInputDialog(null,
                                    "Enter the Staff's First Name ");
                }
                //GUI for staff address input
                String staffAddressInput =
                        JOptionPane.showInputDialog(null,
                                "Enter Staff Address ");
                //While the input is an empty string, prompt the user to let them know it's not valid.
                while (staffAddressInput.equals("")){
                    JOptionPane.showMessageDialog(null, "Please enter a valid address. ");
                    //Prompt the user to enter the value again
                    staffAddressInput =
                            JOptionPane.showInputDialog(null,
                                    "Enter the Staff's Address ");
                }

                //GUI for staff number of years input
                int yearsStaffHasWorkedInput = 0;
                yearsStaffHasWorkedInput = Integer.parseInt(String.valueOf(yearsStaffHasWorkedInput)); //this returns the value of the integer as a String
                        JOptionPane.showInputDialog(null,
                                "Enter Staff Years of Service ");

                ////Add all of the values the user inputted into the "theStaff" array
                theStaff.add(new Staff(staffFirstNameInput, staffLastNameInput, staffAddressInput, yearsStaffHasWorkedInput));
            }
            //Else, if the user selects Finish
            else if (result == 2) {
                //Print an empty output line
                System.out.println();
            }
        }
            //User is asked if they want to continue
            //If they select "YES" (0) then the application will loop through and run again
            while (JOptionPane.showConfirmDialog(null,
                    "Do you want to continue?",
                    "College Application",
                    JOptionPane.YES_NO_OPTION) == 0) ;

        //Build a final report that contains all of the necessary information
        String finalStudentReport = "\nStudents: ";

        //For each student that's in the array, send the information to the "toString" method and display the final output
        for (Student currStudent: theStudents) {
            finalStudentReport += "\n" + currStudent.toString(); //add a line break
            JOptionPane.showMessageDialog(null,
                            finalStudentReport,
                    "Message",
                    JOptionPane.INFORMATION_MESSAGE);
        }
        {
            String finalStaffReport = "\nStaff: ";
            //For each staff member that's in the array, send the information to the "toString" method and display the final output
            for (Staff currStaff: theStaff) {
                finalStaffReport += "\n" + currStaff.toString(); //add a line break
                JOptionPane.showMessageDialog(null,
                                finalStaffReport,
                        "Message",
                        JOptionPane.INFORMATION_MESSAGE);
            }
        }
    }
}


