using Shapes.Contracts;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawer drawer = new Pyramid(10);

            drawer.Draw();
        }
    }
}
