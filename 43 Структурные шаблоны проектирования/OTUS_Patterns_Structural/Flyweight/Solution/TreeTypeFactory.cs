using System.Collections.Generic;
using System.Linq;

namespace Flyweight.Solution
{
    public class TreeTypeFactory
    {
        public static List<TreeType> Types { get; set; }

        static TreeTypeFactory()
        {
            Types = new List<TreeType>();
        }
        
        public static TreeType GetTreeType(int color, int texture)
        {
            var type = Types.SingleOrDefault(t => t.Colour == color && t.Texture == texture);
            if (type == null)
            {
                type = new TreeType(color, texture);
                Types.Add(type);
            }

            return type;
        }
    }
}