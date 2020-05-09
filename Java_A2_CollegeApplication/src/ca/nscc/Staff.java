package ca.nscc;

public class Staff extends Person {
    //Declare variable used in the staff class
    private int yearsStaffHasWorked;
    private double staffPay;

    //Create a constructor with parameters
    public Staff(String firstName, String lastName, String address, int yearsStaffHasWorked) {
        super(firstName, lastName, address); //inherit from the super class
        this.yearsStaffHasWorked = yearsStaffHasWorked;
    }

    @Override //the toString method is overriding in both the Student and Staff class, so that both Students and Staff get reported
    public String toString(){
        return "name = " + super.getFullName() + " Staff address = " + super.getAddress() + ", years = " + getYearsStaffHasWorked() + ", pay = $ " + getStaffPay();
    }

    public int getYearsStaffHasWorked(){
        return yearsStaffHasWorked;
    }

    //Create a getter method to get the Staff's yearly pay - set the initial variable as 50,000
    public double getStaffPay(){
        return this.staffPay;
    }


    public void setStaffPay(double staffPay){
        int yearsOfServiceRangeBegins = 1;
        int yearsOfServiceRangeEnds = 50;
        this.staffPay = staffPay;
        for (int i = yearsOfServiceRangeBegins; i < yearsOfServiceRangeEnds; i++) {
            System.out.println(staffPay + 500);
            
        }
        }
    }
