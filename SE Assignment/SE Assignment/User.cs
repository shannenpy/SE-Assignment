﻿using System;
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
        private List<Vehicle>? vehicleList;
        private List<PaymentMode>? paymentModeList;
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
        private Subject? monthlyCollection { get; set; }
        private List<Application> applications { get; set; } = new List<Application>();

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
                    Console.WriteLine("Start Date: " + p.getEndMonth());
                    Console.WriteLine("End Date: " + p.getStartMonth());
                    Console.WriteLine("Validity Status: " + p.getValidityStatus());
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

        //For paymentModeList
 
        public List<PaymentMode>? PaymentModeList
        {
            get => paymentModeList;
            set => paymentModeList = value;
        }

        public void changepaymentMode(PaymentMode p)
        {
            if (paymentModeList == null)
            {
                paymentModeList = new List<PaymentMode>();
            }
            paymentModeList.Add(p); // Add payment mode to the list
        }

        public void displaydefaultPaymentMode()
        {
            if (paymentModeList != null)
            {
                PaymentMode p = paymentModeList[0];
                Console.WriteLine("\nDefault Payment Mode:\n");
                Console.WriteLine("Mode: " + p.Mode);
                Console.WriteLine("Card No.: " + p.CardNo);
            }
        }

    }
}