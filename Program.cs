using System;

namespace FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Test of Vector and FunctionVector */
            FunctionVector v = new FunctionVector(3);
            v[0] = x => x[0] + x[1] + x[2];
            v[1] = x => x[0] + x[1] * x[2];
            v[2] = x => x[0] * x[1] + x[2];
            Vector tmp = v.Evaluate(new Vector(new double[] { 1, -1, 3 }));
            Console.WriteLine("tmp = {0}", tmp);

            /* Predator prey simulation */
            // (1) single value
            PredPrey p = new PredPrey();
            p.NSettle = 1000;
            Vector v0 = new Vector(new double[] { 0.83, 0.55 });
            p.Delta = 1.38; //this uses the current value of Delta.
            p.Run1Sim(v0, "../../../outfile.csv");

            // (2) produce bifurcation plot data use default values
            p.RunSimDRange(v0, 1.26, 1.4, 1000, "../../../outfile1.csv");
            // (3) produce second bifurcation plot
            p.R = 3;
            p.B = 3.5;
            p.D = 2;
            v0 = new Vector(new double[] { 0.57, 0.37 });
            p.RunSimDRange(v0, 0.5, 0.95, 1000, "../../../outfile2.csv");
        }
    }
}
