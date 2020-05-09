package ca.nscc;

import java.text.DecimalFormat;
import java.text.NumberFormat;

public class Student extends Person {
    //Declare variable used in the student class
    private int studentYear;
    private double studentFee;

    //Create a new variable called number which will format any number into two decimal places
    NumberFormat studentNumber = new DecimalFormat("$0.00");

    //Create a constructor with parameters
    public Student(String firstName, String lastName, String address, int studentYear){
        super (firstName, lastName, address); //inherit from the super class
        this.studentYear = studentYear;
    }


    @Override //the toString method is overriding in both the Student and Staff class, so that both Students and Staff get reported
    public String toString(){
        return "name = " + super.getFullName() + ", address = " + super.getAddress() + ", Student year = " + getStudentYear() + ", fee = $ " + getStudentFee();
    }

    //Create a getter method to get the Student's year
    public int getStudentYear(){
        return this.studentYear;
    }

    //Create a getter method to get the Student fees
    public double getStudentFee(){
        return this.studentFee;
    }

    //Create a setter method for the Student Fee
    private void setStudentFee(double studentFee){
        this.studentFee = studentFee;
        //if the student is in their first year, they pay a fee of 3000
         if (studentYear == 1){
            studentNumber.format(this.studentFee = 3000);
        }
         //else, if the student is in their second year, they pay a fee of 3000
        else if (studentYear == 2){
            studentNumber.format(this.studentFee = 3100);
        }
         //else, if the student is in their third year, they pay a fee of 3000
        else if (studentYear == 3){
            studentNumber.format(this.studentFee = 3200);
        }
         //else, if the student is in their fourth year, they pay a fee of 3000
        else if (studentYear == 4){
            studentNumber.format(this.studentFee = 3300);
        }
    }
}
