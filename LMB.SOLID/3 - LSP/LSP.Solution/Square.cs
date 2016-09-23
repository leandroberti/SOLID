using System;

namespace LMB.SOLID.LSP.Solution
{
    public class Square : GeometricForm
    {
        public Square(int height, int width) : base(height, width)
        {
            if (height != width)
            {
                throw new Exception("The two sides of the square must be equal.");
            }
        }
    }
}