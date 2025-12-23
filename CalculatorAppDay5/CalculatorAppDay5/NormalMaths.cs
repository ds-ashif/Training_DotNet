using System;
using System.Collections.Generic;
using System.Text;

using MathsLib;

namespace CalculatorAppDay5
{
    public class NormalMaths
    {
        public int Num1 {  get; set; }
        public int Num2 { get; set; }
        public Algebra AlgebraObj { get; }

        public NormalMaths()
        {
            AlgebraObj = new Algebra();
        }

        
        public int Add()
        {
            return AlgebraObj.Add(Num1, Num2);
        }

        public int Subtract()
        {
            return AlgebraObj.Subtract(Num1, Num2);
        }

        public int Multiply()
        {
            return AlgebraObj.Multiply(Num1, Num2);
        }

        public double Divide()
        {
            return AlgebraObj.Divide(Num1, Num2);
        }
    }
}
