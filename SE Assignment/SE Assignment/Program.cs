using SE_Assignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

User user = new User();
Vehicle myvehicle2 = new Vehicle("lpn", 2, "car");
Vehicle myvehicle = new Vehicle("lpn", 1, "car");

//create season parking passes for the vehicles
Daily d2 = new Daily(myvehicle2, 1);
Daily dailypass = new Daily(myvehicle, 2);

//add to the list of vehicles with pass
myvehicle.addVehiclesWithPass(myvehicle);
myvehicle.addVehiclesWithPass(myvehicle2);

//user save list of passes
user.addSPPList(d2);
user.addSPPList(dailypass);

Vehicle g = new Vehicle("lpn", 5, "truck");
user.addvehicleList(g);


//program
Console.WriteLine("options:");
Console.WriteLine("1. Park car");
Console.WriteLine("2. Exit carpark");
Console.WriteLine("3. Transfer Season Pass(same vehicle type)");
Console.WriteLine("4. Add a vehicle's details to personal list of vehicles");
Console.WriteLine("5. Renew Season Pass");
int option = Convert.ToInt32(Console.ReadLine());
if (option == 1)
{
    dailypass.setParkingStatus("parked");
    string parkingStatus = dailypass.getParkingStatus();
    Console.WriteLine("Parking status is set as " + parkingStatus);

    string validityStatus = dailypass.getValidityStatus();
    Console.WriteLine("Validity status is " + validityStatus + "\n");

}
else if (option == 2)
{
    dailypass.setParkingStatus("exited");
    string parkingStatus = dailypass.getParkingStatus();
    Console.WriteLine("Parking status is set as " + parkingStatus);

    string validityStatus = dailypass.getValidityStatus();
    Console.WriteLine("Validity status is " + validityStatus + "\n");

}
else if (option == 3)
{
    string restarttransfer = "no";
    if ((user).VehicleList != null)
    {
        if (user.checkPassValidity() == true)//Continue transfer process if user have a parking pass with parking status, exited and validity status, valid.
        {
            while (restarttransfer != "yes")//Restart transfer process if user wants to restart later in the transfer process.
            {
                Console.WriteLine("You have the following valid vehicles for transfer:");
                user.displayPassValidity();
                Console.WriteLine("Which vehicle do you want to transfer parking pass from? Please select the number.");
                int orderinlist = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Your list of vehicles that currently have no parking pass:");
                user.displayvehicleList();
                Console.WriteLine("Which vehicle do you want to transfer parking pass to? Please select the number.");
                int orderinlist2 = Convert.ToInt32(Console.ReadLine());
                if ((user).VehicleList != null)
                {
                    Vehicle givenVehicle = (user).VehicleList[orderinlist2 - 1];
                    Vehicle previousVehicle = user.getVehicle(orderinlist - 1);
                    SeasonParkingPass pass = user.getPass(orderinlist - 1);
                    if (previousVehicle.isMatchVehicleType(givenVehicle) == true)
                    {
                        bool checkvalid = givenVehicle.checkValidVehicle(givenVehicle);
                        if (checkvalid == true)
                        {
                            Console.WriteLine("\nValid Vehicle Details entered\n");
                            Console.WriteLine("Previous vehicle details\n");
                            if (previousVehicle != null)
                            {
                                previousVehicle.printVehicleDetails(previousVehicle);

                            }
                            Console.WriteLine("\nNew vehicle details\n");
                            givenVehicle.printVehicleDetails(givenVehicle);
                            Console.Write("Are you sure you want to transfer pass from the previous vehicle to the new vehicle?");
                            restarttransfer = Convert.ToString(Console.ReadLine());
                            if (restarttransfer == "yes")
                            {
                                pass.setVehicle(givenVehicle);
                                givenVehicle.setParkingPass(pass);
                                Console.WriteLine("\nTransfer Complete!\n");
                                Console.WriteLine("Parking pass is successfully transferred to this vehicle with following details:\n");
                                (pass.Vehicle).printVehicleDetails(pass.Vehicle);
                            }
                            else
                            {
                                Console.WriteLine("Restarting transfer process");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This vehicle entered has a parking pass already.");
                            Console.WriteLine("Restarting transfer process");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid vehicle type. Not similar vehicle type.");
                        Console.WriteLine("Restarting transfer process");
                    }
                }
                else
                {
                    Console.WriteLine("You do not have any vehicles in your personal list of vehicles. Please add one to transfer parking pass to this vehicle.");
                }
            }

        }

        else
        {
            Console.WriteLine("You do not have any valid vehicles to transfer pass from. For example, your vehicle(s) may have parking status, parked or validity status, expired.");
        }
    }
    else
    {
        Console.WriteLine("You do not have any vehicles in your personal list of vehicles. Please add one to transfer parking pass to this vehicle.");
    }
}
else if (option == 4)
{
    Console.WriteLine("Please enter the following vehicle details to add vehicle to personal list of vehicles");
    Console.Write("license plate number:");
    string lpn = Convert.ToString(Console.ReadLine());
    Console.Write("IU number:");
    int iunum = Convert.ToInt32(Console.ReadLine());
    Console.Write("Vehicle type:");
    string vt = Convert.ToString(Console.ReadLine());
    Vehicle givenVehicle = new Vehicle(lpn, iunum, vt);
    user.addvehicleList(givenVehicle);
    user.displayvehicleList();
}
else if (option == 5)
{
    bool renewing = true;

    while (renewing = true)
    {
        //Use case basic flow 1,2,3
        Console.WriteLine("Current Season Passes:");
        user.displaySPPList();
        Console.Write("Choose Season Pass: ");
        int spchoice = Convert.ToInt32(Console.ReadLine());
        
        //Use case basic flow 4,5
        Console.Write("Renew Season pass " + spchoice + "? [Y/N]:");
        string renewchoice = Console.ReadLine();
        if (renewchoice == "Y")
        {
            //Use case basic flow 6,7,8,9
            user.displaydefaultPaymentMode();
            Console.WriteLine("1. Confirm payment");
            Console.WriteLine("2. Change Payment Mode");
            Console.Write("Choice: ");
            int confirmpayment = Convert.ToInt32(Console.ReadLine());
            if (confirmpayment == 1)
            {
                //Use case basic flow 10,11,12,13,14
                //execute make mayment use case
                SeasonParkingPass userpass = user.getPass(spchoice - 1);
                Console.WriteLine("Updated Pass Details:");
                Console.WriteLine("ID: " + userpass.PassID);
                Console.WriteLine("Start Date: " + userpass.getEndMonth());
                Console.WriteLine("End Date: " + userpass.getStartMonth());
                Console.WriteLine("Validity Status: " + userpass.getValidityStatus());

                renewing = false;
            }
            else if (confirmpayment == 2)
            {
                Console.Write("New Payment mode: ");
                String newMode = Console.ReadLine();
                Console.Write("New Card No: ");
                int newCardNo = Convert.ToInt32(Console.ReadLine());
                PaymentMode newPaymentMode = new PaymentMode(newMode,newCardNo);
                user.changepaymentMode(newPaymentMode);
            }
        }
        else { renewing = false; }
    }
    
}



