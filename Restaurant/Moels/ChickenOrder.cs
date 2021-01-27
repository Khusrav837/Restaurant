using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class ChickenOrder
    {
        private int Quantity;

        public ChickenOrder(int quantity)
        {
            this.Quantity = quantity;
        }

        public int GetQuantity()
        {
            return this.Quantity;
        }

        public void CutUp() { }

        public void Cook() { }

        public ChickenOrder Copy()
        {
            return new ChickenOrder(this.Quantity);
        }
    }
}
