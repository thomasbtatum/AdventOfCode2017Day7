using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2017Day7
{
    public class Node
    {
        public string Id { get; set; }
        public int Weight { get; set; }
        public Node[] ChildNodes { get; set; }
        public Node Parent { get; set; }
        //-1 if the child is the end of the lineage
        public int TotalWeight { get; set; }

        public Node() { }

        public Node(string nodeLine)
        {
            //comes in with name(weight) -> child1, child2, child3...childN
            //the -> and beyond are optional.
            var firstSpaceIndex = nodeLine.IndexOf(" ");
            Id = nodeLine.Substring(0, firstSpaceIndex);

            var resultString = Regex.Match(nodeLine, @"(?<=\().+?(?=\))").Value;
            Weight = Convert.ToInt32(resultString);

            if (nodeLine.Contains("->"))
            {
                var childNodesNames = nodeLine.Split('>')[1].Split(',').Select(s => s.Trim()).ToArray();
                var childList = new List<Node>();
                foreach (var childName in childNodesNames)
                {
                    childList.Add(new Node() { Id = childName, Parent = this });
                }
                ChildNodes = childList.ToArray();
            } else
            {
                TotalWeight = -1;
            }
        }
    }
}
