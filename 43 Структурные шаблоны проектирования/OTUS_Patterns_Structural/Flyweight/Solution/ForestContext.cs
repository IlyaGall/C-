using System.Collections.Generic;

namespace Flyweight.Solution
{
    public class ForestContext
    {
        private List<Tree> _trees;

        public ForestContext()
        {
            _trees = new List<Tree>();
        }
        
        public void PlantTree(int colour, int texture, int x, int y)
        {
            var treeType = TreeTypeFactory.GetTreeType(colour, texture);
            var tree = new Tree(x, y, treeType);
            _trees.Add(tree);
        }

        public void Draw()
        {
            foreach (var tree in _trees)
            {
                tree.Draw();
            }
        }
    }
}