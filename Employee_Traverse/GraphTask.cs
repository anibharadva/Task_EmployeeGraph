using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Traverse
{

    //Creates Graph as per the data
    public class GraphTask<T>
    {
        public GraphTask() { }
        //Requires vertices and edges as per data types and Adds them as per data sets
        public GraphTask(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }
        //Dictionary holding the Adjacency List as HashSet
        public Dictionary<T, HashSet<T>> AdjacencyList { get; set; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        //Adds edges requires Tuple <T,T> as per the object
        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
            }
        }

        //Clear AdjacencyList 
        public virtual void Clear()
        {
            AdjacencyList.Clear();
        }

    }
}
