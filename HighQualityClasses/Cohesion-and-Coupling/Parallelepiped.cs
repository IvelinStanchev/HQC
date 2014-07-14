using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width should be bigger than 0");
                }
                this.width = value;
            }
        }


        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height should be bigger than 0");
                }
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The depth should be bigger than 0");
                }
                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width + this.Height + this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = DistanceCalculator.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = DistanceCalculator.CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = DistanceCalculator.CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = DistanceCalculator.CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
