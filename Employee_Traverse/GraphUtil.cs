using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Traverse
{
    //Utility class to traverse the graph path
    public class GraphUtil
    {
        //Utility to parse the Tuples to stack and retrieve as per Neighbor path 
        public HashSet<T> DFS<T>(GraphTask<T> graph, T start, Action<T> preVisit = null)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                if (preVisit != null)
                    preVisit(vertex);

                visited.Add(vertex);
                //Pick from the path provided remove "Reverse" incase of no sequence required
                foreach (var neighbor in graph.AdjacencyList[vertex].Where(node => !visited.Contains(node)).Reverse())
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }
}
