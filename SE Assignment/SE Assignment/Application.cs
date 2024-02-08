using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Application
    {
        private User user { get; set; }
        private Guid applicationId { get; set; }
        private DateTime startMonth { get; set; } // store month only? or whole date?
        private DateTime endMonth { get; set; }
        private bool paid { get; set; } // 0 for false, 1 for true

        public Application(DateTime startMonth, DateTime endMonth, bool paid = false, User user = null)
        {
            this.user = user;
            this.applicationId = Guid.NewGuid();
            this.startMonth = startMonth;
            this.endMonth = endMonth;
            this.paid = paid;
        }

        public void setPaid(bool paid)
        {
            this.paid = paid;
        }
    }
}
