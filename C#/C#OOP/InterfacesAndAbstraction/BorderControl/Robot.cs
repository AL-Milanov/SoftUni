using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Id
    {

        public Robot(string model, string id)
        {
            Model = model;
            IdNumber = id;
        }

        public string Model { get; set; }
        public string IdNumber { get; set; }
    }
}
