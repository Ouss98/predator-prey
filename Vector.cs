using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam
{
    public class Vector
    {
        /* Data */
        private double[] values;

        /* Methods */
        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < values.Length)
                {
                    return values[index];
                }
                else
                {
                    throw new Exception("Index should be >= 0 and < to vector size");
                }
            }
            set
            {
                if (index >= 0 && index < values.Length)
                {
                    values[index] = value;
                }
                else
                {
                    throw new Exception("Index should be >= 0 and < to vector size");
                }
            }
        }

        public Vector()
        {
            values = new double[2];
        }

        public Vector(double[] values)
        {
            this.values = values;
        }

        public Vector(int size)
        {
            if (size > 1)
            {
                values = new double[size];
            }
            else
            {
                values = new double[2];
            }
        }

        public void SetSize(int size)
        {
            // Make a copy of the values array
            double[] valuesCopy = values;

            // Resize values array
            values = new double[size];

            // Copy the elements of old array into newly resized one
            for(int i = 0; i < valuesCopy.Length; i++)
            {
                values[i] = valuesCopy[i];
            }
        }

        public static Vector operator +(Vector lhs, Vector rhs)
        {
            double[] v0 = lhs.values;
            double[] v1 = rhs.values;
            Vector newVector = new Vector(v0.Length);
            if (v0.Length == v1.Length)
            {
                for (int i = 0; i < v0.Length; i++)
                {
                    newVector[i] = v0[i] + v1[i];
                }
            }
            else
            {
                throw new Exception("'+' Operation failed: Vectors should be the same size");
            }
            return newVector;
        }

        public static Vector operator -(Vector lhs, Vector rhs)
        {
            double[] v0 = lhs.values;
            double[] v1 = rhs.values;
            Vector newVector = new Vector(v0.Length);
            if (v0.Length == v1.Length)
            {
                for (int i = 0; i < v0.Length; i++)
                {
                    newVector[i] = v0[i] - v1[i];
                }
            }
            else
            {
                throw new Exception("'-' Operation failed: Vectors should be the same size");
            }
            return newVector;
        }

        public static Vector operator *(double lhs, Vector rhs)
        {
            double[] v1 = rhs.values;
            Vector newVector = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                newVector[i] = lhs * v1[i];
            }
            return newVector;
        }

        public static Vector operator *(Vector lhs, double rhs)
        {
            double[] v1 = lhs.values;
            Vector newVector = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                newVector[i] = rhs * v1[i];
            }
            return newVector;
        }

        public override string ToString()
        {
            string vectStr;
            StringBuilder sb = new StringBuilder();
            List<string> resList = new List<string>(); // List used to store the string values
            for (int i = 0; i < values.Length; i++)
            {
                string l = string.Format("{0:F3}", values[i]); // Format values to 0.000 and to strings
                resList.Insert(i, l); // Adds vector value as string to resList
            }
            vectStr = "{ " + sb.Append(string.Join(", ", resList)).ToString() + " }"; // { v[1], ... , v[n] }
            return vectStr;
        }
    }
}
