using System;

namespace Flyweight.Solution
{
    public class TreeType
    {
        public Guid Id { get; set; }
        public int Colour { get; set; }
        
        public int Texture { get; set; }

        public TreeType(int colour, int texture)
        {
            Colour = colour;
            Texture = texture;
            Id = Guid.NewGuid();
        }
        
        public void Draw(int colour, int texture, double x, double y)
        {
            // используем Colour, Texture, x, y,
        }
    }
}