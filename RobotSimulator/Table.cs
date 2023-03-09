using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSimulator
{
    class Table
    {
        readonly int originX = 0;
        readonly int originY = 0;

        public readonly int MinXPosition;
        public readonly int MaxXPosition;
        public readonly int MinYPosition;
        public readonly int MaxYPosition;

        public Table(int Length, int Width)
        {
            MinXPosition = originX;
            MinYPosition = originY;
            MaxXPosition = originX + Length -1;
            MaxYPosition = originY + Width - 1;
        }
    }
}
