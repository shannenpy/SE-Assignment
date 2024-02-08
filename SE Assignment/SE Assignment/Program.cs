using SE_Assignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

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


interface SeasonParkingPass
{
    Vehicle Vehicle { get; set; }
    int PassID { get; set; }
    void setVehicle(Vehicle v);
    void setParkingStatus(string s);
    string getParkingStatus();
    void setValidityStatus(string s);
    string getValidityStatus();
    string ParkStatus { get; set; }
    string ValidityStatus { get; set; }
    int generatePassID();
}
class Daily : SeasonParkingPass
{
    private string parkStatus;
    public string ParkStatus
    {
        get => parkStatus;
        set => parkStatus = value;

    }
    private string validityStatus;
    public string ValidityStatus
    {

        get => validityStatus;
        set => validityStatus = value;
    }
    private int passID;
    public int PassID
    {
        get => passID;
        set => passID = value;

    }
    private int latestPassID;
    public int LatestPassID
    {
        get => latestPassID;
        set => latestPassID = value;
    }
    private Vehicle vehicle;
    public Vehicle Vehicle
    {
        get => vehicle;
        set => vehicle = value;

    }
    public Daily(Vehicle v, int id)//originally parking pass have parkStatus, exited and validityStatus, valid
    {
        vehicle = v;
        passID = id;
        parkStatus = "exited";
        validityStatus = "valid";
    }
    public int generatePassID()
    {
        latestPassID = latestPassID + 1;
        return latestPassID;
    }
    public void setVehicle(Vehicle v)
    {
        vehicle = v;
    }
    public void setParkingStatus(string s)
    {
        parkStatus = s;

    }
    public string getParkingStatus()
    {
        if (parkStatus != null)
        {
            return parkStatus;
        }
        else
        {
            return string.Empty;
        }

    }
    public void setValidityStatus(string s)
    {
        validityStatus = s;

    }
    public string getValidityStatus()
    {
        if (validityStatus != null)
        {
            return validityStatus;
        }
        else
        {
            return string.Empty;
        }

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

}
class Monthly : SeasonParkingPass
{
    private string parkStatus;
    public string ParkStatus
    {
        get => parkStatus;
        set => parkStatus = value;

    }
    private string validityStatus;
    public string ValidityStatus
    {

        get => validityStatus;
        set => validityStatus = value;
    }
    private int passID;
    public int PassID
    {
        get => passID;
        set => passID = value;

    }
    private int latestPassID;
    public int LatestPassID
    {
        get => latestPassID;
        set => latestPassID = value;
    }
    private Vehicle vehicle;
    public Vehicle Vehicle
    {
        get => vehicle;
        set => vehicle = value;

    }
    public Monthly(Vehicle v, int id)//originally parking pass have parkStatus, exited and validityStatus, valid
    {
        vehicle = v;
        passID = id;
        parkStatus = "exited";
        validityStatus = "valid";
    }
    public void setVehicle(Vehicle v)
    {
        vehicle = v;
    }
    public void setParkingStatus(string s)
    {
        parkStatus = s;
    }
    public string getParkingStatus()
    {
        if (parkStatus != null)
        {
            return parkStatus;
        }
        else
        {
            return string.Empty;
        }

    }
    public void setValidityStatus(string s)
    {
        validityStatus = s;

    }
    public string getValidityStatus()
    {
        if (validityStatus != null)
        {
            return validityStatus;
        }
        else
        {
            return string.Empty;
        }

    }
    public int generatePassID()
    {
        latestPassID = latestPassID + 1;
        return latestPassID;
    }

//    public string getLicensePlateNumber(Vehicle v)
//    {
//        return v.licensePlateNumber;
//    }

//    public int getIUNumber(Vehicle v)
//    {
//        return v.iuNumber;
//    }

}
class User
{
    private List<SeasonParkingPass>? SPPList { get; set; }
    public void addSPPList(SeasonParkingPass spp)
    {
        if (SPPList == null)
        {
            SPPList = new List<SeasonParkingPass>();
        }
        SPPList.Add(spp);

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