using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class ParkingRecord
    {
        private int parkingNo { get; set; }
        private DateTime entryDateTime { get; set; }
        private DateTime exitDateTime { get; set; }
        private float amountCharged { get; set; }

        public ParkingRecord(int parkingNo, DateTime entryDateTime, DateTime exitDateTime, float amountCharged)
        {
            this.parkingNo = parkingNo;
            this.entryDateTime = entryDateTime;
            this.exitDateTime = exitDateTime;
            this.amountCharged = amountCharged;
        }
    }
}
