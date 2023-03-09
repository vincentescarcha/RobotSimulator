using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSimulator
{
    class Robot
    {
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public bool IsPlaced { get; set; } = false;
        public Directions CurrentlyFacing { get; set; }

    }
}
