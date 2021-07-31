namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var data in input)
            {
                var args = data.Split(' ').Select(int.Parse).ToArray();

                CreateNodeByKey(args[0]);
                CreateNodeByKey(args[1]);

                AddEdge(args[0], args[1]);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesBykeys.ContainsKey(key))
            {
                nodesBykeys.Add(key, new Tree<int>(key));
            }

            return nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            Tree<int> node = nodesBykeys.FirstOrDefault().Value;

            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
