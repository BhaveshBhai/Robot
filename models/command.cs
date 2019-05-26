using System;

namespace ToyRobotSimulator
{
    public interface ICommand
    {
        void Execute(Robot robot);
    }

    public class MoveForwordCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.MoveForword();
        }
    }

    public class TurnLeftCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.TurnLeft();
        }
    }

    public class TurnRightCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.TurnRight();
        }
    }

    public class PlaceCommand: ICommand 
    {
        private int _x = 0;

        private int _y = 0;

        private Direction _direction;

        public PlaceCommand(int x, int y, Direction direction) 
        {
            _x = x; 
            _y = y;
            _direction = direction;
        }

        public void Execute(Robot robot)
        {
            if (robot.Board.IsValidPosition(_x, _y)) 
            {
                robot.CoorinateX = _x;
                robot.CoorinateY = _y;
                robot.Direction = _direction;
                robot.IsOnBoard = true;
            }
        }
    }

    public class ReportCommnd : ICommand
    {
        public void Execute(Robot robot)
        {
            Console.WriteLine(robot.GetReportData());
        }
    }
}