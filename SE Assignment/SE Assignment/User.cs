using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class User : Observer
    {
        private int id { get; set; }
        private string name { get; set; }
        private int userType { get; set; } // 0 for staff, 1 for student
        private string username { get; set; }
        private string password { get; set; }
        private string mobileNo { get; set; }
        private List<SeasonParkingPass>? SPPList { get; set; }
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
        private Subject? monthlyCollection { get; set; }

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

        public void update(int passesLeft)
        {
            //implementation
        }

        public void setMonthlyCollection(Subject mc)
        {
            monthlyCollection = mc;
            mc.registerObserver(this);
        }

        public Application applySeasonPass(int type)
        {
            Application application = new Application();
            return application;
        }
    }
}
