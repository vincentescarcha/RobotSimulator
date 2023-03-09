using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSimulator
{
    class RobotController
    {
        private Table _table;
        private Robot _robot;
        public RobotController(int tableLenght, int tableWidth)
        {
            _table = new Table(tableLenght, tableWidth);
            _robot = new Robot();
        }
        public Response Place(int positionX, int positionY, Directions directionFacing)
        {
            if (positionX > _table.MaxXPosition || positionX < _table.MinXPosition
                || positionY > _table.MaxYPosition || positionY < _table.MinYPosition)
            {
                return Response.invalid;
            }

            _robot.CurrentPositionX = positionX;
            _robot.CurrentPositionY = positionY;
            _robot.CurrentlyFacing = directionFacing;
            _robot.IsPlaced = true;
            
            return Response.success;
        }
        public Response Move()
        {
            if (!_robot.IsPlaced) return Response.discard;

            switch (_robot.CurrentlyFacing)
            {
                case Directions.NORTH:
                    if (_robot.CurrentPositionY + 1 > _table.MaxYPosition) return Response.invalid;
                    _robot.CurrentPositionY ++;
                    break;
                case Directions.SOUTH:
                    if (_robot.CurrentPositionY - 1 < _table.MinYPosition) return Response.invalid;
                    _robot.CurrentPositionY --;
                    break;
                case Directions.EAST:
                    if (_robot.CurrentPositionX + 1 > _table.MaxXPosition) return Response.invalid;
                    _robot.CurrentPositionX ++;
                    break;
                case Directions.WEST:
                    if (_robot.CurrentPositionY - 1 < _table.MinYPosition) return Response.invalid;
                    _robot.CurrentPositionY --;
                    break;
                default:
                    return Response.invalid;
            }
            return Response.success;
        }
        public Response Left()
        {
            if (!_robot.IsPlaced) return Response.discard;

            if (_robot.CurrentlyFacing == Directions.NORTH) _robot.CurrentlyFacing = Directions.WEST;
            else if (_robot.CurrentlyFacing == Directions.WEST) _robot.CurrentlyFacing = Directions.SOUTH;
            else if (_robot.CurrentlyFacing == Directions.SOUTH) _robot.CurrentlyFacing = Directions.EAST;
            else if (_robot.CurrentlyFacing == Directions.EAST) _robot.CurrentlyFacing = Directions.NORTH;
            return Response.success;
        }
        public Response Right()
        {
            if (!_robot.IsPlaced) return Response.discard;

            if (_robot.CurrentlyFacing == Directions.NORTH) _robot.CurrentlyFacing = Directions.EAST;
            else if (_robot.CurrentlyFacing == Directions.EAST) _robot.CurrentlyFacing = Directions.SOUTH;
            else if (_robot.CurrentlyFacing == Directions.SOUTH) _robot.CurrentlyFacing = Directions.WEST;
            else if (_robot.CurrentlyFacing == Directions.WEST) _robot.CurrentlyFacing = Directions.NORTH;
            return Response.success;
        }
        public string Report()
        {
            if (!_robot.IsPlaced) return "discard";

            return $"{_robot.CurrentPositionX},{_robot.CurrentPositionY},{_robot.CurrentlyFacing}";
        }
    }
}
