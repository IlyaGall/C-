using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class LinkedListViewer
    {
        public static void Show(LinkedList<string> linkedListFirstNode)
        {
            for (LinkedListNode<string> currentNode = linkedListFirstNode.First; currentNode != null; currentNode = currentNode.Next)
                Console.Write(currentNode.Value + "\t");
        }
    }
}
