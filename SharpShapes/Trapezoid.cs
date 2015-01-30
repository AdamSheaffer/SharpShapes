using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        private decimal base1;
        public decimal Base1
        {
            get { return base1; }
        }

        private decimal base2;
        public decimal Base2
        {
            get { return base2; }
        }

        private decimal height;
        public decimal Height
        {
            get { return height; }
        }

        public decimal AcuteAngle { get; private set; }

        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(decimal base1, decimal base2, decimal height) 
        {
            if (base1 == base2 || base1 <= 0 || base2 <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }

            this.base1 = base1;
            this.base2 = base2;
            this.height = height;

            decimal wingWidth = (Base1 - Base2) / 2;

            this.AcuteAngle = Decimal.Round((decimal)(Math.Atan((double)(Height / wingWidth)) * (180.0 / Math.PI)), 2);
            this.ObtuseAngle = 180 - this.AcuteAngle;
        }

        public override decimal Area()
        {
            return ((base1 + base2) / 2) * height;
        }

        private decimal WingLength()
        {
            return (base1 - base2) / 2;
        }

        public override decimal Perimeter()
        {
            double squares = (double)(WingLength() * WingLength() + Height * Height);
            decimal legLength = Decimal.Round((decimal)Math.Sqrt(squares), 2);
            return base1 + base2 + 2 * legLength;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.base1 = this.Base1 * percent / 100;
            this.base2 = this.Base2 * percent / 100;
            this.height = this.Height * percent / 100;
        }
    }
}
