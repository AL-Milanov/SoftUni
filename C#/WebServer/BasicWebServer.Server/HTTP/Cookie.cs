﻿using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }


        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
