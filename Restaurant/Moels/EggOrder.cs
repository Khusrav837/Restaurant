using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class EggOrder
    {
        private int Quantity;
        private int Quality;
        private int QualityGet = 0;

        public EggOrder(int quantity)
        {
            Random rand = new Random();
            this.Quality = rand.Next(101);
            this.Quantity = quantity;
        }

        public EggOrder(int quantity, int quality)
        {
            //TODO: This quality can be null.
            this.Quality = quality;
            this.Quantity = quantity;
        }

        public int GetQuantity()
        {
            return this.Quantity;
        }

        public int? GetQuality()
        {
            //TODO: Why we need QualityGet variable? Make sure if the method returns null then this.Quality value also should be null.
            QualityGet++;
            if (QualityGet % 2 == 0)
            {
                return null;
            }
            else
            {
                return this.Quality;
            }
        }

        public void Crack()
        {
            if (this.Quality < 25)
            {
                throw new Exception("Quality is less!");
            }
        }

        public void DiscardShell() { }

        public void Cook() { }

        public EggOrder Copy()
        {
            return new EggOrder(this.Quantity, this.Quality);
        }
    }
}
