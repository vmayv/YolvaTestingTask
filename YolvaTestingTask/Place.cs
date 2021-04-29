using System;
using System.Collections.Generic;
using System.Text;

namespace YolvaTestingTask
{
    public class Place
    {
        public string Name { get; set; }
        public List<Point> points;

        Place(string name)
        {
            Name = name;
            points = new List<Point>();
        }
    }
}
