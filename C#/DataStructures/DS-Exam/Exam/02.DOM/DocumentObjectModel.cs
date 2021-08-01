namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {

        private List<IHtmlElement> list;

        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
            list = new List<IHtmlElement>();
            list.Add(Root);
        }

        public DocumentObjectModel()
        {
            var elements = new IHtmlElement[2] {
               new HtmlElement(ElementType.Head, null),
                new HtmlElement(ElementType.Body, null)
            };
            list = new List<IHtmlElement>();

            var html = new HtmlElement(ElementType.Html, elements);
            Root = new HtmlElement(ElementType.Document, html);

            list.Add(Root);
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            return FindElement(type);
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            return FindAll(type);
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return IsPresented(htmlElement);
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            var element = FindElement(parent.Type);

            if (element == null)
            {
                throw new InvalidOperationException();
            }
            child.Parent = parent;
            parent.Children.Insert(0, child);
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            var element = FindElement(parent.Type);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            child.Parent = parent;
            parent.Children.Add(child);
        }

        public void Remove(IHtmlElement htmlElement)
        {
            var element = FindElement(htmlElement.Type);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            var htmlParent = htmlElement.Parent;

            if (htmlElement != null)
            {
                htmlParent.Children.Remove(htmlElement);
            }
            else
            {
                element = null;
            }

        }

        public void RemoveAll(ElementType elementType)
        {
            var elements = FindAll(elementType);

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Parent.Children.Remove(elements[i]);
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            var element = FindElement(htmlElement.Type);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            if (element.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            element.Attributes.Add(attrKey, attrValue);

            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            var element = FindElement(htmlElement.Type);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            if (element.Attributes.ContainsKey(attrKey))
            {
                element.Attributes.Remove(attrKey);

                return true;
            }

            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            return FindId(idValue);
        }

        public override string ToString()
        {
            return DFSToString(0);
        }

        private string DFSToString(int spaces)
        {
            string result = new string(' ', spaces) + Root.Type;

            foreach (var child in Root.Children)
            {
                result += Environment.NewLine;

                result += child.DFSToString(spaces + 2);
            }

            return result;
        }

        private IHtmlElement FindElement(ElementType searchedType)
        {
            var queue = new Queue<IHtmlElement>();
            IHtmlElement htmlElement = null;

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Children != null)
                {
                    foreach (var child in current.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
                if (current.Type == searchedType)
                {
                    htmlElement = current;
                    break;
                }
            }

            return htmlElement;
        }
        private IHtmlElement FindId(string idValue)
        {
            var queue = new Queue<IHtmlElement>();
            IHtmlElement value = null;

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Children != null)
                {
                    foreach (var child in current.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
                if (current.Attributes != null)
                {
                    foreach (var attribute in current.Attributes.Values)
                    {
                        if (attribute == idValue)
                        {
                            value = current;
                            break;
                        }
                    }
                }
            }

            return value;
        }

        private List<IHtmlElement> FindAll(ElementType searchedType)
        {

            List<IHtmlElement> htmlElements = new List<IHtmlElement>();

            Stack<IHtmlElement> stack = new Stack<IHtmlElement>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                foreach (var child in current.Children)
                {
                    stack.Push(child);
                }

                if (current.Type == searchedType)
                {
                    htmlElements.Add(current);
                }
            }

            htmlElements.Reverse();
            return htmlElements;
        }

        private bool IsPresented(IHtmlElement htmlElement)
        {
            var element = FindElement(htmlElement.Type);

            if (element != null)
            {
                return true;
            }

            return false;
        }
    }
}
