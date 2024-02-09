using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Monthly : SeasonParkingPass
    {
        public double MonthlyRate { get; set; } = 10; //test case
        public override string passType { get; set; } = "m";
        private int latestPassID;
        public override int LatestPassID
        {
            get => latestPassID;
            set => latestPassID = value;
        }
        private int passID;
        public override int PassID
        {
            get => passID;
            set => passID = value;
        }
        public Monthly(Vehicle v, int id, string validityStatus, string passType, string reason)//originally parking pass have parkStatus, exited and validityStatus, valid
        {
            Vehicle = v;
            PassID = id;
            ParkStatus = "exited";
            ValidityStatus = "valid";
            LatestPassID = 1;
            this.ValidityStatus = validityStatus;
            this.terminationReason = reason;
        }
        
        public override double calculateRefund()
        {
            DateTime endMonth = new DateTime(2024, 09, 07); // test case
            int endNum = endMonth.Month;
            int currentNum = DateTime.Now.Month;

            if (endNum > currentNum)
            {
                double amount = (endNum - currentNum) * MonthlyRate;
                return amount;
            }
            else
            {
                return 0;
            }
        }
    }
}
