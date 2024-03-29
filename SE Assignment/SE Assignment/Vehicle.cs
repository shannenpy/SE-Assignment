﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Vehicle
    {
        private SeasonParkingPass? parkingPass;
        private string licensePlateNumber;
        private int iuNumber;
        private string vehicleType;
        static List<Vehicle>? vehiclesWithPass { get; set; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            set => licensePlateNumber = value;
        }

        public int IUNumber
        {
            get => iuNumber;
            set => iuNumber = value;
        }

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
            parkingPass = pass;
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
}
