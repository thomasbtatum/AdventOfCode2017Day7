using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2017Day7
{
    static class InputStringUtil
    {
        public static Node BuildNode(string nodeLine)
        {
            Node node = new Node();
            
            var firstSpaceIndex = nodeLine.IndexOf(" ");
            node.Id = nodeLine.Substring(0, firstSpaceIndex);

            var resultString = Regex.Match(nodeLine, @"(?<=\().+?(?=\))").Value;
            node.Weight = Convert.ToInt32(resultString);

            if (nodeLine.Contains("->"))
            {
                node.ChildNode = false;

                var childNodesNames = nodeLine.Split('>')[1].Split(',').Select(s => s.Trim()).ToArray();
                var childList = new List<Node>();
                foreach (var childName in childNodesNames)
                {
                    childList.Add(new Node() { Id = childName, Placeholder = true });
                }
                node.ChildNodes = childList.ToArray();
            } else
            {
                node.ChildNode = true;
            }

            return node;
        }

    }
}
