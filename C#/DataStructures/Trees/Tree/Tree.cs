namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            var res = DFSToString(0);

            return res;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Tree<T> node = children[0];

            while (node.children.Count != 0)
            {
                node = node.children[0];
            }

            return node;
        }

        public List<T> GetLeafKeys()
        {
            List<T> leafKeys = BFSLeafs().Select(t => t.Key).ToList();

            return leafKeys;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> middleLeafKeys = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count > 0 && node.Parent != null)
                {
                    middleLeafKeys.Add(node.Key);

                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return middleLeafKeys;
        }

        public List<T> GetLongestPath()
        {
            List<T> paths = new List<T>();

            var leafs = BFSLeafs();

            foreach (var leaf in leafs)
            {
                var node = leaf;
                List<T> currentLeafs = new List<T>();

                while (node != null)
                {
                    currentLeafs.Add(node.Key);

                    node = node.Parent;
                }

                if (currentLeafs.Count > paths.Count)
                {
                    paths = currentLeafs;
                }
            }

            paths.Reverse();

            return paths;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<List<T>> paths = new List<List<T>>();

            var leafs = BFSLeafs();

            foreach (var leaf in leafs)
            {
                var node = leaf;
                double currentSum = 0;
                List<T> currentLeafs = new List<T>();

                while (node != null)
                {
                    currentLeafs.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key);

                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentLeafs.Reverse();
                    paths.Add(currentLeafs);
                }
            }

            return paths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
        private List<Tree<T>> BFSLeafs()
        {
            List<Tree<T>> leafKeys = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    leafKeys.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafKeys;
        }

        private string DFSToString(int spaces)
        {
            string result = new string(' ', spaces) + Key;

            foreach (var child in children)
            {
                result += Environment.NewLine;

                result += child.DFSToString(spaces + 2);
            }

            return result;
        }
    }
}
