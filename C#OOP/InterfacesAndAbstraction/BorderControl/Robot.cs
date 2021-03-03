using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Id
    {

        public Robot(string model, long id)
        {
            Model = model;
            IdNumber = id;
        }

        public string Model { get; set; }

        public long IdNumber { get; private set; }
    }
}
