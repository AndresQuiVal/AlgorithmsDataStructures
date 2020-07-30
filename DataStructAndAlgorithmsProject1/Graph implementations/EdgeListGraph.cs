using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Graph_implementations
{
    public class EdgeListGraph<T>
    {
        public T[] vertices;
        public Edge[] edges;

        public EdgeListGraph()
        {
            vertices = new T[10];
            edges = new Edge[vertices.Length * (vertices.Length - 1)];
        }

        #region Get adyacent nodes of x node
        public void GetAdyacentNodes(T node) // Undirect graph
        {
            foreach(var item in edges)
            {
                if(vertices[item.vertex1].Equals(node))
                    Console.WriteLine(vertices[item.vertex2]);
                else if(vertices[item.vertex2].Equals(node))
                    Console.WriteLine(vertices[item.vertex1]);
            }
        }
        #endregion
    }
}
