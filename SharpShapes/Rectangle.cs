using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Rectangle : Shape
    {
        public override int SidesCount
        {
            get { return 4; }
        }

        public override decimal Area()
        {
            return this.Width * this.Height;
        }

        public override decimal Perimeter()
        {
            return (this.Width * 2) + (this.Height * 2);
        }

        private decimal width;
        public decimal Width 
        {
            get { return this.width; }   
        }

        private decimal height;
        public decimal Height 
        {
            get { return this.height; } 
        }

        public Rectangle(decimal width, decimal height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width;
            this.height = height;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.width = this.width * percent / 100;
            this.height = this.height * percent / 100;
        }
    }
}
