using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class Employee
    {
        private int NewRequestCount = 0;
        private object ChikenOrEgg; //TODO: Rename this variable to meeningfull name.
        private bool chickenPrepared = false;
        private bool eggPrepared = false;
        public Employee()
        {

        }

        public object NewRequest(int quantity, string m = "egg")
        {
            NewRequestCount++;
            if (m == "chiken")
            {
                if (NewRequestCount % 3 == 0)
                {
                    ChikenOrEgg = new EggOrder(quantity);
                }
                else
                {
                    ChikenOrEgg = new ChickenOrder(quantity);
                }
            }
            else
            {
                if (NewRequestCount % 3 == 0)
                {
                    ChikenOrEgg = new ChickenOrder(quantity);
                }
                else
                {
                    ChikenOrEgg = new EggOrder(quantity);
                }
            }
            return ChikenOrEgg;
        }

        public object CopyRequest()
        {
            if (ChikenOrEgg is ChickenOrder)
            {
                ChickenOrder c = (ChickenOrder)ChikenOrEgg;
                return c.Copy();
            }
            else if (ChikenOrEgg is EggOrder)
            {
                EggOrder e = (EggOrder)ChikenOrEgg;
                return e.Copy();
            }
            throw new Exception("Hey Guy You haven't instance!");
        }

        public string Inspect(object o)
        {
            if (o is EggOrder)
            {
                EggOrder e = (EggOrder)o;
                return e.GetQuality().ToString();
            }
            return "specifies no inspection is required";
        }

        public string PrepareFood(object o)
        {
            if (o is ChickenOrder)
            {
                if (chickenPrepared)
                {
                    throw new Exception("already chicken kaput!");
                }
                chickenPrepared = true;

                ChickenOrder c = (ChickenOrder)o;
                for (int i = 0; i < c.GetQuantity(); i++)
                {
                    c.CutUp();
                }
                c.Cook();
                return "indicating preparation has been completed";
            }
            else if (o is EggOrder)
            {
                if (eggPrepared)
                {
                    throw new Exception("already eggs kaput!");
                }
                eggPrepared = true;
                var rotten = 0;
                EggOrder e = (EggOrder)o;
                for (int i = 0; i < e.GetQuantity(); i++)
                {
                    //TODO: You called e.DiscardShell() twice. Please call it only once.
                    try
                    {
                        e.Crack();
                    }
                    catch
                    {
                        rotten++;
                    }
                    e.DiscardShell();
                }
                e.Cook();
                return "indicating preparation has been completed " + rotten.ToString();
            }
            throw new Exception("Hey Guy You haven't instance!");
        }
    }
}
