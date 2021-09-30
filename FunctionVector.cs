using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam
{
    public delegate double Function(Vector vect);
    class FunctionVector
    {
        /* Data */
        private Function[] functionVector;

        /* Methods */
        public Function this[int index]
        {
            get
            {
                if (index >= 0 && index < functionVector.Length)
                {
                    return functionVector[index];
                }
                else
                {
                    throw new Exception("Index should be >= 0 and < to functionVector size");
                }
            }
            set
            {
                if (index >= 0 && index < functionVector.Length)
                {
                    functionVector[index] = value;
                }
                else
                {
                    throw new Exception("Index should be >= 0 and < to functionVector size");
                }
            }
        }

        public FunctionVector()
        {
            functionVector = new Function[2];
            for(int i = 0; i < functionVector.Length; i++)
            {
                functionVector[i] = x => 0;
            }
        }

        public FunctionVector(int size)
        {
            if (size > 1)
            {
                functionVector = new Function[size];
            }
            else
            {
                functionVector = new Function[2];
            }

            for (int i = 0; i < functionVector.Length; i++)
            {
                functionVector[i] = x => 0;
            }
        }

        public FunctionVector(Function[] functions)
        {
            functionVector = new Function[functions.Length];
            functionVector = functions;
        }

        public Vector Evaluate(Vector values)
        {
            int n = functionVector.Length;
            Vector evalVect = new Vector(n);

            for (int i = 0; i < n; i++)
            {
                evalVect[i] = functionVector[i](values);
            }

            return evalVect;
        }
    }
}
