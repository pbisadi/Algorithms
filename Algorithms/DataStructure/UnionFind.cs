using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructure
{
    /// <summary>
    /// Components are maximal set of objects that are mutually connected 
    /// Used algorithm: Quick-Union
    /// </summary>
    public class UnionFind_QU
    {
        private int[] id;
        private int[] sz;   //Number of items in the tree rooted at i
        public UnionFind_QU(int N)
        {
            id = new int[N];
            sz = new int[N];
            for (int i = 0; i < N; i++) { 
                id[i] = i;
                sz[i] = 1;
            }
        }

        private int Root(int i)
        {
            while (i != id[i]) {
                id[i] = id[id[i]];
                i = id[i]; 
            }
            return i;
        }

        /// <summary>
        /// Add connection between p and q
        /// </summary>
        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
        }

        /// <summary>
        /// Are p and q in the same component?
        /// </summary>
        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        /// <summary>
        /// Component identified for p
        /// </summary>
        /// <returns>returns the id of the component that p is in it</returns>
        public int Find(int p)
        {
            return Root(p);
        }

        public int ComponentsCount()
        {
            throw new NotImplementedException();
        }
    }
}
