using SE_Assignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

//User user = new User("s12345678", "Dr Oon", 0, "s12345678", "password123", "91234567");
User user = new User();

MonthlyCollection waitingList = MonthlyCollection.getInstance();

Console.WriteLine("----- Welcome to the ICTP Parking Management System -----");
Console.WriteLine("Menu options:");
Console.WriteLine("1. Apply for season pass");
Console.WriteLine("2. Renew season pass");
Console.WriteLine("3. Transfer season pass");
Console.WriteLine("4. Terminate season pass");
int opt;
while (true)
{
    try
    {
        Console.Write("Select your option: ");
        opt = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine($"Wrong format: Please enter a digit");
        continue;
    }
    catch
    {
        Console.WriteLine("Unknown error occured. Please try again.");
        continue;

    }
    if (opt is >=1 and <=4)
    {
        break;
    }
    else
    {
        Console.WriteLine("Option is not in range. Please try again.");
        continue;
    }
}

switch (opt)
{
    case 1: // apply
        // UC-004 Step 1
        user.applySeasonPass();
        break;
    case 2: // renew
        user.renewSeasonPass();
        break;
    case 3:
        user.transferSeasonPass();
        break;
    case 4: // terminate
        break;
}


//User user = new User();
//Vehicle myvehicle2 = new Vehicle("lpn", 2, "car");
//Vehicle myvehicle = new Vehicle("lpn", 1, "car");

////create season parking passes for the vehicles
//Daily d2 = new Daily(myvehicle2, 1);
//Daily dailypass = new Daily(myvehicle, 2);

////add to the list of vehicles with pass
//myvehicle.addVehiclesWithPass(myvehicle);
//myvehicle.addVehiclesWithPass(myvehicle2);

////user save list of passes
//user.addSPPList(d2);
//user.addSPPList(dailypass);

////program
//Console.WriteLine("options:");
//Console.WriteLine("1. Park car");
//Console.WriteLine("2. Exit carpark");
//Console.WriteLine("3. Transfer Season Parking Pass(same vehicle type)");
//int option = Convert.ToInt32(Console.ReadLine());
//if (option == 1)
//{
//    dailypass.setParkingStatus("parked");
//    string parkingStatus = dailypass.getParkingStatus();
//    Console.WriteLine("Parking status is set as " + parkingStatus);

//    string validityStatus = dailypass.getValidityStatus();
//    Console.WriteLine("Validity status is set as " + validityStatus + "\n");

//}
//else if (option == 2)
//{
//    dailypass.setParkingStatus("exited");
//    string parkingStatus = dailypass.getParkingStatus();
//    Console.WriteLine("Parking status is set as " + parkingStatus);

//    string validityStatus = dailypass.getValidityStatus();
//    Console.WriteLine("Validity status is set as " + validityStatus + "\n");

//}
//else if (option == 3)
//{
//    string restarttransfer = "no";
//    if (user.checkPassValidity() == true)//Continue transfer process if user have a parking pass with parking status, exited and validity status, valid.
//    {
//        while (restarttransfer != "yes")//Restart transfer process if user wants to restart later in the transfer process.
//        {
//            Console.WriteLine("You have the following valid vehicles for transfer:");
//            user.displayPassValidity();
//            Console.WriteLine("Which vehicle do you want to transfer parking pass from? Please select the number.");
//            int orderinlist = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Please enter the following vehicle details to transfer pass to that vehicle.");
//            Console.Write("license plate number:");
//            string lpn = Convert.ToString(Console.ReadLine());
//            Console.Write("IU number:");
//            int iunum = Convert.ToInt32(Console.ReadLine());
//            Console.Write("Vehicle type:");
//            string vt = Convert.ToString(Console.ReadLine());
//            Vehicle givenVehicle = new Vehicle(lpn, iunum, vt);
//            Vehicle previousVehicle = user.getVehicle(orderinlist - 1);
//            SeasonParkingPass pass = user.getPass(orderinlist - 1);
//            if (previousVehicle.isMatchVehicleType(givenVehicle) == true)
//            {
//                bool checkvalid = givenVehicle.checkValidVehicle(givenVehicle);
//                if (checkvalid == true)
//                {
//                    Console.WriteLine("\nValid Vehicle Details entered\n");
//                    Console.WriteLine("Previous vehicle details\n");
//                    if (previousVehicle != null)
//                    {
//                        previousVehicle.printVehicleDetails(previousVehicle);

//                    }
//                    Console.WriteLine("\nNew vehicle details\n");
//                    givenVehicle.printVehicleDetails(givenVehicle);
//                    Console.Write("Are you sure you want to transfer pass from the previous vehicle to the new vehicle?");
//                    restarttransfer = Convert.ToString(Console.ReadLine());
//                    if (restarttransfer == "yes")
//                    {
//                        pass.setVehicle(givenVehicle);
//                        givenVehicle.setParkingPass(pass);
//                        Console.WriteLine("\nTransfer Complete!\n");
//                        Console.WriteLine("Parking pass is successfully transferred to this vehicle with following details:\n");
//                        (pass.Vehicle).printVehicleDetails(pass.Vehicle);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Restarting transfer process");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("This vehicle entered has a parking pass already.");
//                    Console.WriteLine("Restarting transfer process");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid vehicle type. Not similar vehicle type.");
//                Console.WriteLine("Restarting transfer process");
//            }
//        }
//    }
//    else
//    {
//        Console.WriteLine("You do not have any valid vehicles to transfer pass from. For example, your vehicle(s) may have parking status, parked or validity status, expired.");
//    }
//}