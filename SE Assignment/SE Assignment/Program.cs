// See https://aka.ms/new-console-template for more information
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

//program
Console.WriteLine("options:");
Console.WriteLine("1. Park car");
Console.WriteLine("2. Exit carpark");
Console.WriteLine("3. Transfer Season Pass(same vehicle type)");
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
            Console.WriteLine("Please enter the following vehicle details to transfer pass to that vehicle.");
            Console.Write("license plate number:");
            string lpn = Convert.ToString(Console.ReadLine());
            Console.Write("IU number:");
            int iunum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vehicle type:");
            string vt = Convert.ToString(Console.ReadLine());
            Vehicle givenVehicle = new Vehicle(lpn, iunum, vt);
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
    int LatestPassID { get; set; }
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
        latestPassID = 1;
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

    }




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
        latestPassID = 1;
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



}
class Vehicle
{
    private SeasonParkingPass? parkingpass;
    private string licensePlateNumber;
    public string LicensePlateNumber
    {
        get => licensePlateNumber;
        set => licensePlateNumber = value;
    }
    static List<Vehicle>? vehiclesWithPass { get; set; }
    private int iuNumber;
    public int IUNumber
    {
        get => iuNumber;
        set => iuNumber = value;
    }
    private string vehicleType;
    public string VehicleType
    {
        get => vehicleType;
        set => vehicleType = value;
    }
    public Vehicle(string lpn, int IUnum, string vt)
    {
        licensePlateNumber = lpn;
        iuNumber = IUnum;
        vehicleType = vt;
    }
    public void printVehicleDetails(Vehicle v)
    {
        Console.WriteLine("License Plate Number:" + v.licensePlateNumber);
        Console.WriteLine("IU Number:" + v.iuNumber);
        Console.WriteLine("Vehicle type:" + v.vehicleType);

    }
    public void setParkingPass(SeasonParkingPass pass)
    {
        parkingpass = pass;
    }
    public bool isMatchVehicleType(Vehicle v)
    {
        if (v.vehicleType == this.vehicleType)
        {
            return true;
        }
        return false;

    }
    public string getLicensePlateNumber(Vehicle v)
    {
        return v.licensePlateNumber;
    }
    public int getIUNumber(Vehicle v)
    {
        return v.iuNumber;
    }
    public string getVehicleType(Vehicle v)
    {
        return v.vehicleType;
    }
    public void addVehiclesWithPass(Vehicle v)
    {

        if (vehiclesWithPass == null)
        {
            vehiclesWithPass = new List<Vehicle>();
        }
        vehiclesWithPass.Add(v);
    }
    public bool checkValidVehicle(Vehicle v)//check if the given vehicle is already in the list of vehicles with parking pass.
                                            //If it exists in the list, return false as this vehicle cannot have another parking pass transferred to it.
    {

        bool checkvalid = true;

        if (vehiclesWithPass != null)
        {
            foreach (Vehicle vehicle in vehiclesWithPass)
            {
                if (vehicle.getLicensePlateNumber(vehicle) == v.getLicensePlateNumber(v) && vehicle.getIUNumber(vehicle) == v.getIUNumber(v) && vehicle.getVehicleType(vehicle) == v.getVehicleType(v))
                {
                    checkvalid = false;
                    return checkvalid;
                }
            }

        }

        return checkvalid;
    }
}


