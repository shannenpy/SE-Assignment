using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Daily : SeasonParkingPass
    {
        public override string passType()
        {
            return "d";
        }
        private string parkStatus;
        public override string ParkStatus
        {
            get => parkStatus;
            set => parkStatus = value;

        }
        private string validityStatus;
        public override string ValidityStatus
        {

            get => validityStatus;
            set => validityStatus = value;
        }
        private int passID;
        public override int PassID
        {
            get => passID;
            set => passID = value;

        }
        private int latestPassID;
        public override int LatestPassID
        {
            get => latestPassID;
            set => latestPassID = value;
        }
        private Vehicle vehicle;
        public override Vehicle Vehicle
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
        public override int generatePassID()
        {
            latestPassID = latestPassID + 1;
            return latestPassID;
        }
        public override void setVehicle(Vehicle v)
        {
            vehicle = v;
        }
        public override void setParkingStatus(string s)
        {
            parkStatus = s;

        }
        public override string getParkingStatus()
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
        public override void setValidityStatus(string s)
        {
            validityStatus = s;

        }
        public override string getValidityStatus()
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
}
