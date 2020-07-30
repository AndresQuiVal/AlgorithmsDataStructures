using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Graph_implementations
{
    public class Edge
    {
        public int vertex1, vertex2, length = 1;

        public Edge(int vertex1, int vertex2, int length = 1)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.length = length;
        }
    }
}
