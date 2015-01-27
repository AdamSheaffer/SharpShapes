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

        public Trapezoid(decimal base1, decimal base2, decimal height) 
        {
            if (base1 == base2 || base1 <= 0 || base2 <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }

            this.base1 = base1;
            this.base2 = base2;
            this.height = height;
        }

        public override decimal Area()
        {
            return ((base1 + base2) / 2) * height;
        }

        public override decimal Perimeter()
        {
            throw new NotImplementedException();
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

        public object AcuteAngle { get; set; }

        public object ObtuseAngle { get; set; }
    }
}
