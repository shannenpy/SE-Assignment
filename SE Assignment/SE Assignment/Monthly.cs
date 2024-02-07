﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Monthly : SeasonParkingPass
    {
        private string parkStatus;
        private string validityStatus;
        private int passID;
        private int latestPassID;
        private Vehicle vehicle;

        public Monthly(Vehicle v, int id)//originally parking pass have parkStatus, exited and validityStatus, valid
        {
            vehicle = v;
            passID = id;
            parkStatus = "exited";
            validityStatus = "valid";
        }

        public string ParkStatus
        {
            get => parkStatus;
            set => parkStatus = value;
        }

        public string ValidityStatus
        {
            get => validityStatus;
            set => validityStatus = value;
        }

        public int PassID
        {
            get => passID;
            set => passID = value;
        }

        public int LatestPassID
        {
            get => latestPassID;
            set => latestPassID = value;
        }

        public Vehicle Vehicle
        {
            get => vehicle;
            set => vehicle = value;
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

        public void setPassID(int id)
        {
            passID = id;
        }
    }
}
