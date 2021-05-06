using Shapes.Contracts;

namespace Shapes
{
    public abstract class Shape : IDrawer
    {
        public Shape(params int[] side)
        {
        }

        public virtual void Draw() { }
    }
}
