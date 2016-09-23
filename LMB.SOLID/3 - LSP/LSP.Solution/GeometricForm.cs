namespace LMB.SOLID.LSP.Solution
{
    public class GeometricForm
    {
        public GeometricForm(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; }
        public double Width { get; }
        public double Area => Height * Width;
    }
}