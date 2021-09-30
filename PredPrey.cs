using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FinalExam
{
    class PredPrey
    {
        /* Data */
        private FunctionVector fv;
        private double delta = 0.5, r = 2, b = 0.6, d = 0.5;
        private int nSettle = 200;
        private int nReps = 200;

        /* Parameters */
        public double Delta
        {
            get { return delta; }
            set { delta = value; }
        }
        public double R
        {
            get { return r; }
            set { r = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public double D
        {
            get { return d; }
            set { d = value; }
        }
        public int NSettle
        {
            get { return nSettle; }
            set
            {
                if(value >= 10)
                {
                    nSettle = value;
                }
                else
                {
                    nSettle = 200;
                }
            }
        }
        public int NReps
        {
            get { return nReps; }
            set
            {
                if (value >= 10)
                {
                    nReps = value;
                }
                else
                {
                    nReps = 200;
                }
            }
        }

        /* Methods */
        public PredPrey()
        {
            fv = new FunctionVector(2);
            // v[0] = x_n and v[1] = y_n
            fv[0] = v => r * v[0] * (1 - v[0]) - b * v[0] * v[1];
            fv[1] = v => v[1] * (-d + b * v[0]);
        }

        public void Run1Sim(Vector v0, string filename)
        {
            Vector v_np1 = new Vector(2);
            List<Vector> v_np1_list = new List<Vector>(); // List of v_np1 vectors
            v_np1 = v0;

            for(int i = 0; i < nSettle; i++)
            {
                v_np1 = v_np1 + delta * fv.Evaluate(v_np1);
            }
            for(int i = 0; i < nReps; i++)
            {
                v_np1 = v_np1 + delta * fv.Evaluate(v_np1);
                v_np1_list.Add(v_np1);
            }
            // Write in a file
            var w = new StreamWriter(filename, true); // true to append data to file if it exists
            StringBuilder sbr = new StringBuilder();

            for (int k = 0; k < v_np1_list.Count; k++)
            {
                List<string> lList = new List<string>();
                lList.Insert(0, delta.ToString());
                for (int i = 0; i < 2; i++)
                {
                    string l = v_np1_list[k][i].ToString(); // Adds vector element as string to lList
                    lList.Insert(i+1, l);
                }
                var ln = sbr.Append(string.Join(",", lList));
                w.WriteLine(ln);
                sbr.Clear(); // Clears StringBuilder to allow next values to be written on next line
            }
            w.Flush(); // Clears buffers
            w.Close(); // Closes StreamWriter
        }

        public void RunSimDRange(Vector v0, double deltaFrom, double deltaTo, int numSteps, string filename)
        {
            // Handling delta interval
            List<double> deltaList = new List<double>();
            double div = deltaTo - deltaFrom;
            double divSize = div / (numSteps - 1);
            deltaList.Add(deltaFrom);
            for (double i = deltaFrom + divSize; i <= deltaTo - divSize; i+=divSize)
            {
                deltaList.Add(i);
            }
            deltaList.Add(deltaTo);

            // Simulations
            foreach (double dt in deltaList)
            {
                this.Delta = dt;
                Run1Sim(v0, filename);
            }
        }
    }
}
