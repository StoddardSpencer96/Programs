package ca.nscc;

public class Person {
    //This is my super class - variables used here will be inherited into the other classes

    //Declare variables used in the person class (they will also be used in the other classes)
    private String firstName;
    private String lastName;
    private String address;

    //Create a constructor with parameters
    public Person (String firstName, String lastName, String address) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;

    }

    //Create a getter method called fullName to combine their first and last name together
    public String getFullName() {
        return this.firstName + " " +  this.lastName;
    }

    //Create a getter method to retrieve the address of the person
    public String getAddress(){
        return address;
    }
}
