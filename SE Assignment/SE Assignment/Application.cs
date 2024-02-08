using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Application
    {
        private Guid id {  get; set; }
        private Guid applicationId { get; set; }
        private int type { get; set; } // 1 for daily, 2 for monthly
        private DateTime startMonth { get; set; }
        private DateTime endMonth { get; set; }
        private bool paid { get; set; } // 0 for false, 1 for true
        private string paymentMode { get; set; }
        private User user { get; set; }
        private Vehicle vehicle { get; set; }

        public Application(int type, DateTime startMonth, DateTime endMonth, string paymentMode, User user = null, Vehicle vehicle = null)
        {
            this.id = Guid.NewGuid();
            this.applicationId = Guid.NewGuid();
            this.type = type;
            this.startMonth = startMonth;
            this.endMonth = endMonth;
            this.paymentMode = paymentMode;
            this.paid = false;
            this.user = user;
            this.vehicle = vehicle;
        }

        public bool makePayment()
        {
            // implementation
            Console.Write("Hit any key to execute Make Payment use case.");
            Console.ReadKey();
            Console.WriteLine();
            // if payment succeeds
            paid = true;
            Console.WriteLine("Make Payment use case executed successfully.");
            return paid;
        }
    }
}
