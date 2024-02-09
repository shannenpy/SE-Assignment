﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class User : Observer
    {
        private string id { get; set; }
        private string name { get; set; }
        private int userType { get; set; } // 0 for staff, 1 for student
        private string username { get; set; }
        private string password { get; set; }
        private string mobileNo { get; set; }
        private List<SeasonParkingPass>? SPPList { get; set; }
        private Subject? monthlyCollection { get; set; }
        private List<Application> applications { get; set; } = new List<Application>();
        private List<PaymentMode> paymentModeList;

        public User()
        {
            this.SPPList = new List<SeasonParkingPass>();
        }

        public User(string id, string name, int userType, string username, string password, string mobileNo)
        {
            this.id = id;
            this.name = name;
            this.userType = userType;
            this.username = username;
            this.password = password;
            this.mobileNo = mobileNo;
            this.SPPList = new List<SeasonParkingPass>();
        }

        public void addSPPList(SeasonParkingPass spp)
        {
            if (SPPList == null)
            {
                SPPList = new List<SeasonParkingPass>();
            }
            SPPList.Add(spp);
        }
        private List<Vehicle>? vehicleList;
        public List<Vehicle>? VehicleList
        {
            get => vehicleList;
            set => vehicleList = value;
        }
        public void addvehicleList(Vehicle v)
        {
            if (vehicleList == null)
            {
                vehicleList = new List<Vehicle>();
            }
            vehicleList.Add(v);

        }
        public void displayvehicleList()
        {
            if (vehicleList != null)
            {
                int count = 0;

                foreach (Vehicle v in this.vehicleList)
                {
                    count = count + 1;
                    Console.Write("\nVehicle {0} details\n", count);
                    Console.WriteLine("License Plate Number:" + v.LicensePlateNumber);
                    Console.WriteLine("IU Number:" + v.IUNumber);
                    Console.WriteLine("Vehicle type:" + v.VehicleType);
                }
            }
        }
        public bool checkPassValidity()
        {
            if (SPPList != null)
            {
                foreach (SeasonParkingPass p in SPPList)
                {
                    if (p.getParkingStatus() == "exited" && p.getValidityStatus() == "valid")
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public void displayPassValidity()
        {
            int count = 0;
            if (SPPList != null)
            {
                foreach (SeasonParkingPass p in SPPList)
                {
                    count = count + 1;
                    if (p.getParkingStatus() == "exited" && p.getValidityStatus() == "valid")
                    {
                        Console.Write("\nVehicle {0} details\n", count);
                        (p.Vehicle).printVehicleDetails(p.Vehicle);
                    }
                }
            }
        }

        public Vehicle? getVehicle(int orderinlist)
        {
            if (SPPList != null)
            {

                return SPPList[orderinlist].Vehicle;

            }
            else
            {
                return null;
            }
        }

        public SeasonParkingPass? getPass(int orderinlist)
        {
            if (SPPList != null)
            {

                return SPPList[orderinlist];

            }
            return null;
        }

        public void update(int passesLeft)
        {
            //implementation
        }

        public void setMonthlyCollection(Subject mc)
        {
            monthlyCollection = mc;
            mc.registerObserver(this);
        }

        public bool applySeasonPass()
        {
            int type;
            Console.WriteLine("Types:");
            Console.WriteLine("1. Daily");
            Console.WriteLine("2. Monthly");

            // UC-004 Step 2
            Console.Write("Select season pass type: ");
            type = Convert.ToInt32(Console.ReadLine());

            // UC-004 Step 3
            if (type == 2) // if type is monthly
            {
                // UC-004 Step 4
                // check for MonthlyCollection passesLeft
                MonthlyCollection waitingList = MonthlyCollection.getInstance();

                // UC-004 Step 4.1
                if (waitingList.getPassesLeft() == 0)
                {
                    // UC-004 Step 4.2
                    // prompt to be placed on waiting list
                    Console.Write("No monthly passes available. Would you like to be placed on the waiting list? (y/n) ");
                    string opt = Console.ReadLine().ToLower();

                    // UC-004 Step 4.3
                    if (opt == "y")
                    {
                        waitingList.registerObserver(this);
                        // UC-004 Step 4.4
                        Console.WriteLine("Successfully placed on waiting list.");
                    }
                    // UC-004 Step 4.2.1
                    else if (opt == "n")
                    {
                        Console.WriteLine("Not placed on the waiting list.");
                    }

                    // UC-004 Step 4.5 / Step 4.2.2
                    return false;
                }
            }
            // UC-004 Step 5, Step 6, & Step 7
            // prompt for name, student/staff id, username, password, mobileNo, startMonth, endMonth, paymentMode, lpn, IUnum, vehicleType
            if (this.username == null && this.password == null) {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                this.name = name;

                string regex = @"^[sS]\d{8}$";
                bool isValid = false;
                string id = null;
                while (!isValid)
                {
                    Console.Write("Enter student/staff id (e.g. s12345678): ");
                    id = Console.ReadLine();
                    isValid = Regex.IsMatch(id, regex);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid id. Please try again.");
                    }
                }
                this.id = id;

                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                this.username = username;

                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                this.password = password;

                Console.Write("Enter mobile number: ");
                string mobileNo = Console.ReadLine();
                this.mobileNo = mobileNo;
            }
            else
            {
                Console.WriteLine("User details detected and will be used for this application.");
            }

            Console.Write("Enter start month (e.g. 09/2024): ");
            DateTime startMonth = Convert.ToDateTime("01/" + Console.ReadLine());

            Console.Write("Enter end month (e.g. 09/2024): ");
            DateTime endMonth = Convert.ToDateTime("01/" + Console.ReadLine());

            Console.Write("Enter payment mode (0 - cash card, 1 - credit card, 2 - debit card): ");
            string paymentMode = Console.ReadLine();

            Console.Write("Enter vehicle license plate number: ");
            string lpn = Console.ReadLine();

            Console.Write("Enter vehicle IU number: ");
            int IUnum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter vehicle type (0 - car, 1 - motorcycle): ");
            int vehicleType = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle = new Vehicle(lpn, IUnum, vehicleType);

            // UC-004 Step 8 & 9
            Application application = new Application(type, startMonth, endMonth, paymentMode, this, vehicle);
            this.applications.Add(application);

            bool paymentMade = false;
            while (!paymentMade)
            {
                paymentMade = application.makePayment();
            }

            // UC-004 Step 10
            Console.WriteLine("Application created successfully.");
            return true;
        }

        //UC001 - Renew Season Pass
        public void displaySPPList()
        {
            if (SPPList != null)
            {
                int count = 0;
                foreach (SeasonParkingPass p in SPPList)
                {
                    count++;
                    Console.WriteLine($"\nSeason Parking Pass {count} details:");
                    Console.WriteLine("ID: " + p.PassID);
                    Console.WriteLine("Start Date: " + p.startMonth);
                    Console.WriteLine("End Date: " + p.endMonth);
                    Console.WriteLine("Validity Status: " + p.getValidityStatus() + "\n");
                }
            }
            else 
            { 
                Console.WriteLine("No Season Parking Passes!"); 
            }
        }

        public void displayDefaultPaymentMode()
        {
            if (paymentModeList != null)
            {
                PaymentMode p = paymentModeList[0];
                Console.WriteLine("\nDefault Payment Mode:\n");
                Console.WriteLine("Mode: " + p.mode);
                Console.WriteLine("Card No.: " + p.cardNo);
            }
        }

        public void changePaymentMode(PaymentMode p)
        {
            if (paymentModeList == null)
            {
                paymentModeList = new List<PaymentMode>();
                paymentModeList.Add(p);
            }
            else
            { paymentModeList[0] = (p);} // Replace default payment mode with new payment mode
        }

        public bool renewSeasonPass()
        {
            bool renewing = true;

            while (renewing = true)
            {
                //UC001 basic flow 1,2,3
                Console.WriteLine("Current Season Passes:");
                displaySPPList();
                Console.Write("Choose Season Pass: ");
                int spchoice = Convert.ToInt32(Console.ReadLine());

                //UC001 basic flow 4,5
                Console.Write("Renew Season pass " + spchoice + "? [Y/N]:");
                string renewchoice = Console.ReadLine();
                if (renewchoice == "Y")
                {
                    //UC001 basic flow 6,7,8,9
                    displayDefaultPaymentMode();
                    Console.WriteLine("1. Confirm payment");
                    Console.WriteLine("2. Change Payment Mode");
                    Console.Write("Choice: ");
                    int confirmpayment = Convert.ToInt32(Console.ReadLine());
                    if (confirmpayment == 1)
                    {
                        //UC001 basic flow 10,11,12,13,14
                        SeasonParkingPass userpass = getPass(spchoice - 1);
                        if (userpass.passType == "m")
                        {
                            userpass.endMonth = DateTime.Now.AddMonths(1);
                        }
                        else if (userpass.passType == "d")
                        { }
                        //execute make mayment use case
                        Console.WriteLine("\nUpdated Pass Details:");
                        Console.WriteLine("ID: " + userpass.PassID);
                        Console.WriteLine("Start Date: " + userpass.startMonth);
                        Console.WriteLine("End Date: " + userpass.endMonth);
                        Console.WriteLine("Validity Status: " + userpass.getValidityStatus());
                    }
                    else if (confirmpayment == 2)
                    {
                        Console.Write("\nNew Payment mode: ");
                        String newMode = Console.ReadLine();
                        Console.Write("New Card No: ");
                        int newCardNo = Convert.ToInt32(Console.ReadLine());
                        PaymentMode newPaymentMode = new PaymentMode(newMode, newCardNo);
                        changePaymentMode(newPaymentMode);

                        displayDefaultPaymentMode();
                        Console.Write("Confirm payment [Y/N]");
                        string confirm = Console.ReadLine();
                        if (confirm == "Y")
                        {
                            //UC001 basic flow 10,11,12,13,14
                            SeasonParkingPass userpass = getPass(spchoice - 1);
                            if (userpass.passType == "m")
                            {
                                userpass.endMonth = DateTime.Now.AddMonths(1);
                            }
                            else if (userpass.passType == "d")
                            { }
                            //execute make mayment use case
                            Console.WriteLine("\nUpdated Pass Details:");
                            Console.WriteLine("ID: " + userpass.PassID);
                            Console.WriteLine("Start Date: " + userpass.startMonth);
                            Console.WriteLine("End Date: " + userpass.endMonth);
                            Console.WriteLine("Validity Status: " + userpass.getValidityStatus() + "\n");
                        }
                    }
                    renewing = false;
                }
                else 
                { renewing = false; }
            }

            return true;
        }
        public bool transferSeasonPass()
        {
            
            //Given that the user has a valid daily season pass
            Vehicle myvehicle = new Vehicle("lpn", 2, 0);

            Daily dailypass = new Daily(myvehicle, 2, "valid", "d", null);
            //adding this vehicle to list of vehicles with pass
            myvehicle.addVehiclesWithPass(myvehicle);
            //adding the pass to user's list of season passes
            this.addSPPList(dailypass);


            //Given that the user has another vehicle added to the user's personal list of vehicles.
            Vehicle anotherVehicle = new Vehicle("lpn", 1, 0);
            this.addvehicleList(anotherVehicle);

            //the above lines of code are added to test this feature. This feature can only be used if the user has a vehicle with a valid season pass.
            string restarttransfer = "no";
            if ((this).VehicleList != null)
            {
                if (this.checkPassValidity() == true)//Continue transfer process if user have a season pass with parking status, exited and validity status, valid.
                {
                    while (restarttransfer != "yes")//Restart transfer process if user wants to restart later in the transfer process.
                    {
                        Console.WriteLine("You have the following valid vehicles for transfer:");
                        this.displayPassValidity();
                        Console.WriteLine("In this list, which vehicle do you want to transfer season pass from? For example, for vehicle 1, enter 1.");
                        int orderinlist = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Your list of vehicles that currently have no season pass:");
                        this.displayvehicleList();
                        Console.WriteLine("In this list of vehicles, which vehicle do you want to transfer season pass to? For example, for vehicle 1, enter 1.");
                        int orderinlist2 = Convert.ToInt32(Console.ReadLine());
                        
                            Vehicle givenVehicle = (this).VehicleList[orderinlist2 - 1];
                            Vehicle previousVehicle = this.getVehicle(orderinlist - 1);
                            SeasonParkingPass pass = this.getPass(orderinlist - 1);
                            if (previousVehicle.isMatchVehicleType(givenVehicle) == true)
                            {
                                bool checkvalid = givenVehicle.checkValidVehicle(givenVehicle);
                                if (checkvalid == true)
                                {
                                    Console.WriteLine("\nValid Vehicle Selected\n");
                                    Console.WriteLine("Previous vehicle details\n");
                                    if (previousVehicle != null)
                                    {
                                        previousVehicle.printVehicleDetails(previousVehicle);

                                    }
                                    Console.WriteLine("\nNew vehicle details\n");
                                    givenVehicle.printVehicleDetails(givenVehicle);
                                    Console.WriteLine("Are you sure you want to transfer season pass from the previous vehicle to the new vehicle? Enter yes or no.");
                                    restarttransfer = Convert.ToString(Console.ReadLine());
                                    if (restarttransfer == "yes")
                                    {
                                        pass.setVehicle(givenVehicle);
                                        givenVehicle.setParkingPass(pass);
                                        Console.WriteLine("\nSuccessful transfer of season pass to the current vehicle with following details:\n");
                                        (pass.Vehicle).printVehicleDetails(pass.Vehicle);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Restarting transfer process");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This vehicle entered has a season pass already.");
                                    Console.WriteLine("Restarting transfer process");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid vehicle type. Not similar vehicle type.");
                                Console.WriteLine("Restarting transfer process");
                            }
                        }
                      
                    

                }

                else
                {
                    Console.WriteLine("You do not have any valid vehicles to transfer season pass from. For example, your vehicle(s) may have parking status, parked or validity status, expired.");
                }
            }
            else
            {
                Console.WriteLine("You do not have any vehicles in your personal list of vehicles. Please add one to transfer season pass to this vehicle.");
            }
            return true;
        }

        public bool terminateSeasonPass()
        {
            // Create user SPPList
            Vehicle myvehicle = new Vehicle("lpn", 2, 0);
            List<SeasonParkingPass> SPPList = new List<SeasonParkingPass>();
            Daily spp1 = new Daily(myvehicle, 1, "valid", "d", null);
            SPPList.Add(spp1);
            Monthly spp2 = new Monthly(myvehicle, 2, "expired", "m", null);
            SPPList.Add(spp2);
            Monthly spp3 = new Monthly(myvehicle, 3, "valid", "m", null);
            SPPList.Add(spp3);
            Daily spp4 = new Daily(myvehicle, 4, "expired", "d", null);
            SPPList.Add(spp4);

            int count = 0;
            if (SPPList != null)
            {
                // UC-003 Step 2
                foreach (SeasonParkingPass spp in SPPList)
                {
                    count += 1;
                    Console.Write($"{count}. PassID: {spp.PassID}     ");
                    Console.WriteLine("Type: " + spp.passType);
                }
                count += 1;
                Console.WriteLine($"{count}. Cancel termination.");

                int option;

                // UC-003 Step 3
                while (true)
                {
                    Console.Write("Enter which season pass you wish to terminate: ");
                    option = Convert.ToInt32(Console.ReadLine()); 

                    // UC-003 Step 4
                    if (option > 0 && option < count)
                    {
                        break; // Exit the loop if option is valid
                    }
                    // UC-003 Step 4.a.1
                    else if (option == count)
                    {
                        Console.WriteLine("Termination cancelled.");
                        return false;
                    }
                    // UC-003 Step 4.b.1
                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }
                }

                SeasonParkingPass passChosen = SPPList[option - 1];
                string valid = passChosen.ValidityStatus;

                // UC-003 Step 5
                if (valid == "valid")
                {
                    // UC-003 Step 6
                    Console.Write("Enter reason for termination: ");
                    string reason = Console.ReadLine();
                    passChosen.SetTerminationReason(reason);

                    // UC-003 Step 9
                    if (passChosen.passType == "d")
                    {
                        Console.WriteLine("Daily pass terminated");
                        //SPPList.Remove(passChosen);
                        return true;
                    }
                    // UC-003 Step 9.1
                    else
                    {

                    }
                    passChosen.ValidityStatus = "terminated";
                    Console.WriteLine(passChosen.ValidityStatus + passChosen.terminationReason);
                }
                // UC-003 Step 5.1
                else
                {
                    Console.WriteLine("Pass is expired and will automatically be terminated after 6 months.");
                    return false;
                }
            }
            return false; 
        }


        //    bool conditionMet = false;
        //    do
        //    {
        //        Console.Write("Enter which season pass you wish to terminate: ");
        //        int option = Convert.ToInt32(Console.ReadLine());
        //        //UC-003 Step 4
        //        if (option > 0 && option < count)
        //        {
        //            SeasonParkingPass passChosen = SPPList[option - 1];
        //            string valid = passChosen.ValidityStatus;
        //            //UC-003 Step 5
        //            if (valid == "valid")
        //            {
        //                //UC-003 Step 6
        //                Console.WriteLine("Enter reason for termination: ");
        //                string reason = Console.ReadLine();
        //                passChosen.SetTerminationReason(reason);

        //                //UC-003 Step 9
        //                if (passChosen.passType == "d")
        //                {
        //                    Console.WriteLine("Daily pass terminated");
        //                    //SPPList.Remove(passChosen);
        //                    return true;
        //                }
        //                //UC-003 Step 9.1
        //                else
        //                {

        //                }
        //            }
        //            //UC-003 Step 5.1
        //            else
        //            {
        //                Console.WriteLine("Pass is expired and will automatically be terminated after 6 months.");
        //                return false;
        //            }
        //            conditionMet = true;
        //        }
        //        //UC-003 Step 4.b.1
        //        else if (option == count)
        //        {
        //            Console.WriteLine("Termination cancelled.");
        //            conditionMet = true;
        //            return false;
        //        }
        //        //UC-003 Step 4.a.1
        //        else
        //        {
        //            Console.WriteLine("Please enter a valid option.");
        //        }
        //    } while (!conditionMet);



        //}
        ////UC-003 Step 2.1
        //else
        //{
        //    Console.WriteLine("You have no passes.");
        //    return false;
        //}
    }
}


 