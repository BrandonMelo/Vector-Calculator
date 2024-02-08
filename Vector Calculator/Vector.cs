using System;

namespace Vector_Calculator
{
    public class Vector
    {
        public static readonly Vector Zero = new Vector(1, 1, 1);
        public static readonly Vector One = new Vector(0, 0, 0);

        public double x;
        public double y;
        public double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"<{x}, {y}, {z}>";
        }

        public double GetMagnitude()
        {
            //<1 * -1> + <2 * 2> + <3 * -3> = <-1, 4, -9> 
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public double GetDirection()
        {
            //<2/1> * 180/PI = 45 deg
            return Math.Atan(this.y / this.x ) * (180/Math.PI);
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            // <2, 3, 4> + <6, 2, 6> = <8, 5, 10>
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector Negate(Vector v)
        {
            // <1, 2, 3> * -1 = <-1, -2, -3>
            return new Vector(-v.x, -v.y, -v.z);
        }

        public static Vector Subtract(Vector v1, Vector v2)
        {
            // <2, 3, 4> - <6, 2, 6> = <-4, 1, -2>
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector Scale(Vector v, double scalar)
        {
            // <1, 2, 3> * 3 = <3, 6, 9>
            return new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
        }

        public static Vector Normalize(Vector v)
        {
            // <(1 / -1), (2 / 4), (3 / -9)>
            return new Vector(v.x / v.GetMagnitude(), v.y / v.GetMagnitude(), v.z / v.GetMagnitude());
        }

        public static double DotProduct(Vector v1, Vector v2)
        {
            // (1 *-1) + (2 * 2) + (3 * -3) = -6
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            // (2 * 3) - (3 * 2), (3 * -1) - (1 * 2), (1 * 2) - (2 * -1) = <-12, 0, 4>
            return new Vector((v1.y * v2.z) - (v1.z * v2.y), (v1.z * v2.x) - (v1.x * v2.z), (v1.x * v2.y) - (v1.y * v2.x));
        }

        public static double AngleBetween(Vector v1, Vector v2)
        {
            return Math.Acos(Vector.DotProduct(v1, v2) / (v1.GetMagnitude() * v2.GetMagnitude()));
        }

        public static Vector ProjectOnto(Vector v1, Vector v2)
        {
            //vector.scale
            //vector.dotproduct
            //vector.magnitude
            double dotproduct = Vector.DotProduct(v1, v2);
            double getmagnitude = v2.GetMagnitude() * v2.GetMagnitude();
            double divide = dotproduct / getmagnitude;
            Vector result = Vector.Scale(v2, divide);
            return result;
        }
    }
}
