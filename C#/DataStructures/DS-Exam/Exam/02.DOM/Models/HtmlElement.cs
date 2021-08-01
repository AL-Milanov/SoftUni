namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            Type = type;
            Children = new List<IHtmlElement>();

            for (int i = 0; i < children.Length; i++)
            {
                if (children[i] != null) 
                {
                    children[i].Parent = this;
                    Children.Add(children[i]);
                    Attributes = new Dictionary<string, string>();
                }
            }
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }

        public string DFSToString(int v)
        {

            string result = new string(' ', v) + Type;

            foreach (var child in Children)
            {
                result += Environment.NewLine;

                result += child.DFSToString(v + 2);
            }

            return result;
        }
    }
}
