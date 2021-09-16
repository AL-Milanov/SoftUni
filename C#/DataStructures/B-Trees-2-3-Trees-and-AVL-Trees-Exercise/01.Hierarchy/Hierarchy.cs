namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        public class Node
        {
            public Node(T value)
            {
                Value = value;
                Children = new List<Node>();
            }
            public Node(T value, Node parent)
            {
                Value = value;
                Children = new List<Node>();
                Parent = parent;
            }

            public T Value { get; set; }

            public List<Node> Children { get; set; }

            public Node Parent { get; set; }
        }

        private Node root;
        private Dictionary<T, Node> hierarchy;

        public Hierarchy(T value)
        {
            this.root = new Node(value);
            hierarchy = new Dictionary<T, Node>();
            hierarchy.Add(value, this.root);
        }

        public int Count => hierarchy.Count;

        public void Add(T parent, T child)
        {
            if (!hierarchy.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            if (hierarchy.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var childNode = new Node(child, hierarchy[parent]);
            hierarchy[childNode.Value] = childNode;
            hierarchy[parent].Children.Add(childNode);
            childNode.Parent = hierarchy[parent];
        }

        public void Remove(T parent)
        {
            if (parent.Equals(root.Value))
            {
                throw new InvalidOperationException();
            }

            if (!hierarchy.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            var nodeToRemove = hierarchy[parent];
            nodeToRemove.Parent.Children.AddRange(nodeToRemove.Children);

            foreach (var node in nodeToRemove.Children)
            {
                node.Parent = nodeToRemove.Parent;
            }

            hierarchy.Remove(parent);
            hierarchy[nodeToRemove.Parent.Value].Children.Remove(nodeToRemove);
        }

        public IEnumerable<T> GetChildren(T parent)
        {
            if (!hierarchy.ContainsKey(parent))
            {
                throw new InvalidOperationException();
            }

            return hierarchy[parent].Children.Select(c => c.Value);
        }

        public T GetParent(T child)
        {
            if (!hierarchy.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            T parent = default;

            if (hierarchy[child].Parent != null)
            {
                parent = hierarchy[child].Parent.Value;
            }

            return parent;
        }

        public bool Contains(T element)
        {
            return hierarchy.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var commonElements = hierarchy.Keys.Intersect(other.hierarchy.Keys).ToList();

            return commonElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> nodes = new Queue<Node>();

            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {

                var currentNode = nodes.Dequeue();

                yield return currentNode.Value;

                foreach (var node in currentNode.Children)
                {
                    nodes.Enqueue(node);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}