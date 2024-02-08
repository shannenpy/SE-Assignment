using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class MonthlyCollection : Subject
    {
        private int maxPasses { get; set; } = 100;
        private int passesLeft { get; set; } = 2; // todo: change/remove
        private List<Observer> observers;

        private static MonthlyCollection uniqueInstance = null;

        private MonthlyCollection()
        {
            observers = new List<Observer>();
        }

        public static MonthlyCollection getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new MonthlyCollection();
            }

            return uniqueInstance;
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
            Console.WriteLine("Observer registered.");
        }

        public void removeObserver(Observer o)
        {
            observers.Remove(o);
            Console.WriteLine("Observer removed.");
        }

        public void notifyObservers()
        {
            foreach (Observer o in observers)
            {
                o.update(passesLeft);
                Console.WriteLine("Observer notified.");
            }
        }

        public void passesChanged()
        {
            passesLeft = maxPasses - observers.Count;
            notifyObservers();
        }

        public int getPassesLeft()
        {
            return passesLeft;
        }
    }
}
