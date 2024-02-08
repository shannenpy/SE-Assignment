using SE_Assignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Serialization;

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
        break;
    case 3: // transfer
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
//}//}

//class Monthly : SeasonParkingPass
//{
//    private string parkStatus;
//    private string validityStatus;
//    private int passID;
//    private int latestPassID;
//    private Vehicle vehicle;

//    public Monthly(Vehicle v, int id)//originally parking pass have parkStatus, exited and validityStatus, valid
//    {
//        vehicle = v;
//        passID = id;
//        parkStatus = "exited";
//        validityStatus = "valid";
//    }

//    public string ParkStatus
//    {
//        get => parkStatus;
//        set => parkStatus = value;
//    }
    
//    public string ValidityStatus
//    {
//        get => validityStatus;
//        set => validityStatus = value;
//    }
    
//    public int PassID
//    {
//        get => passID;
//        set => passID = value;
//    }

//    public int LatestPassID
//    {
//        get => latestPassID;
//        set => latestPassID = value;
//    }

//    public Vehicle Vehicle
//    {
//        get => vehicle;
//        set => vehicle = value;
//    }

//    public void setVehicle(Vehicle v)
//    {
//        vehicle = v;
//    }

//    public void setParkingStatus(string s)
//    {
//        parkStatus = s;
//    }

//    public string getParkingStatus()
//    {
//        if (parkStatus != null)
//        {
//            return parkStatus;
//        }
//        else
//        {
//            return string.Empty;
//        }
//    }
    
//    public void setValidityStatus(string s)
//    {
//        validityStatus = s;

//    }
    
//    public string getValidityStatus()
//    {
//        if (validityStatus != null)
//        {
//            return validityStatus;
//        }
//        else
//        {
//            return string.Empty;
//        }
//    }
    
//    public int generatePassID()
//    {
//        latestPassID = latestPassID + 1;
//        return latestPassID;
//    }

//    public void setPassID(int id)
//    {
//        passID = id;
//    }
//}

//class User : Observer
//{
//    private int id {  get; set; }
//    private string name { get; set; }
//    private int userType { get; set; } // 0 for staff, 1 for student
//    private string username { get; set; }
//    private string password { get; set; }
//    private string mobileNo { get; set; }
//    private List<SeasonParkingPass>? SPPList { get; set; }
//    private Subject? monthlyCollection { get; set; }

//    public void addSPPList(SeasonParkingPass spp)
//    {
//        if (SPPList == null)
//        {
//            SPPList = new List<SeasonParkingPass>();
//        }
//        SPPList.Add(spp);
//    }
    
//    public bool checkPassValidity()
//    {
//        if (SPPList != null)
//        {
//            foreach (SeasonParkingPass p in SPPList)
//            {
//                if (p.getParkingStatus() == "exited" && p.getValidityStatus() == "valid")
//                {
//                    return true;
//                }
//            }

//        }
//        return false;
//    }
    
//    public void displayPassValidity()
//    {
//        int count = 0;
//        if (SPPList != null)
//        {
//            foreach (SeasonParkingPass p in SPPList)
//            {
//                count = count + 1;
//                if (p.getParkingStatus() == "exited" && p.getValidityStatus() == "valid")
//                {
//                    Console.Write("\nVehicle {0} details\n", count);
//                    (p.Vehicle).printVehicleDetails(p.Vehicle);
//                }
//            }
//        }
//    }
    
//    public Vehicle? getVehicle(int orderinlist)
//    {
//        if (SPPList != null)
//        {

//            return SPPList[orderinlist].Vehicle;

//        }
//        else
//        {
//            return null;
//        }
//    }
    
//    public SeasonParkingPass? getPass(int orderinlist)
//    {
//        if (SPPList != null)
//        {

//            return SPPList[orderinlist];

//        }
//        return null;
//    }

//    public void update(int passesLeft)
//    {
//        //implementation
//    }

//    public void setMonthlyCollection(Subject mc)
//    {
//        monthlyCollection = mc;
//        mc.registerObserver(this);
//    }

//    public Application applySeasonPass(int type)
//    {
//        Application application = new Application();
//        return application;
//    }
//}

//class Vehicle
//{
//    private SeasonParkingPass? parkingPass;
//    private string licensePlateNumber;
//    private int iuNumber;
//    private string vehicleType;
//    static List<Vehicle>? vehiclesWithPass { get; set; }
    
//    public string LicensePlateNumber
//    {
//        get => licensePlateNumber;
//        set => licensePlateNumber = value;
//    }
    
//    public int IUNumber
//    {
//        get => iuNumber;
//        set => iuNumber = value;
//    }
       
//    public string VehicleType
//    {
//        get => vehicleType;
//        set => vehicleType = value;
//    }

//    public Vehicle(string lpn, int IUnum, string vt)
//    {
//        licensePlateNumber = lpn;
//        iuNumber = IUnum;
//        vehicleType = vt;
//    }

//    public void printVehicleDetails(Vehicle v)
//    {
//        Console.WriteLine("License Plate Number:" + v.licensePlateNumber);
//        Console.WriteLine("IU Number:" + v.iuNumber);
//        Console.WriteLine("Vehicle type:" + v.vehicleType);
//    }
    
//    public void setParkingPass(SeasonParkingPass pass)
//    {
//        parkingPass = pass;
//    }
    
//    public bool isMatchVehicleType(Vehicle v)
//    {
//        if (v.vehicleType == this.vehicleType)
//        {
//            return true;
//        }
//        return false;
//    }

//    public string getLicensePlateNumber(Vehicle v)
//    {
//        return v.licensePlateNumber;
//    }

//    public int getIUNumber(Vehicle v)
//    {
//        return v.iuNumber;
//    }

//    public string getVehicleType(Vehicle v)
//    {
//        return v.vehicleType;
//    }

//    public void addVehiclesWithPass(Vehicle v)
//    {
//        if (vehiclesWithPass == null)
//        {
//            vehiclesWithPass = new List<Vehicle>();
//        }
//        vehiclesWithPass.Add(v);
//    }

//    public bool checkValidVehicle(Vehicle v)//check if the given vehicle is already in the list of vehicles with parking pass.
//                                            //If it exists in the list, return false as this vehicle cannot have another parking pass transferred to it.
//    {

//        bool checkvalid = true;

//        if (vehiclesWithPass != null)
//        {
//            foreach (Vehicle vehicle in vehiclesWithPass)
//            {
//                if (vehicle.getLicensePlateNumber(vehicle) == v.getLicensePlateNumber(v) && vehicle.getIUNumber(vehicle) == v.getIUNumber(v) && vehicle.getVehicleType(vehicle) == v.getVehicleType(v))
//                {
//                    checkvalid = false;
//                    return checkvalid;
//                }
//            }

//        }

//        return checkvalid;
//    }
//}

//class Carpark
//{
//    private int carparkNo { get; set; }
//    private string description { get; set; }
//    private string location {  get; set; }
//    private double perMinuteRate { get; set; }

//    public Carpark(int carparkNo, string description, string location, double perMinuteRate)
//    {
//        this.carparkNo = carparkNo;
//        this.description = description;
//        this.location = location;
//        this.perMinuteRate = perMinuteRate;
//    }
//}

//interface Observer
//{
//    void update(int passesLeft);
//}

//interface Subject
//{
//    void registerObserver(Observer o);
//    void removeObserver(Observer o);
//    void notifyObservers();
//}

//class MonthlyCollection : Subject 
//{
//    private int maxPasses { get; set; } = 100;
//    private int passesLeft { get; set; }
//    private List<Observer> observers;

//    private static MonthlyCollection uniqueInstance = null;

//    private MonthlyCollection()
//    {
//        observers = new List<Observer>();
//    }

//    public static MonthlyCollection getInstance()
//    {
//        if (uniqueInstance == null)
//        {
//            uniqueInstance = new MonthlyCollection();
//        }

//        return uniqueInstance;
//    }

//    public void registerObserver(Observer o)
//    {
//        observers.Add(o);
//    }

//    public void removeObserver(Observer o)
//    {
//        observers.Remove(o);
//    }

//    public void notifyObservers()
//    {
//        foreach (Observer o in observers)
//        {
//            o.update(passesLeft);
//        }
//    }

//    public void passesChanged()
//    {
//        passesLeft = maxPasses - observers.Count;
//        notifyObservers();
//    }
//}

//class Application 
//{ 
//    private User user { get; set; }
//    private Guid applicationId { get; set; }
//    private DateTime startMonth { get; set; } // store month only? or whole date?
//    private DateTime endMonth { get; set; }
//    private bool paid { get; set; } // 0 for false, 1 for true

//    public Application(DateTime startMonth, DateTime endMonth, bool paid = false, User user = null)
//    {
//        this.user = user;
//        this.applicationId = Guid.NewGuid();
//        this.startMonth = startMonth;
//        this.endMonth = endMonth;
//        this.paid = paid;
//    }

//    public void setPaid(bool paid)
//    {
//        this.paid = paid;
//    }
//}