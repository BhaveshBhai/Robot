using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class RobotSimulator
    {
        private Robot _robot;

        private ICommand _command;

        private string _robotRunCommand;

        private CommandParser _commandParser;

        public RobotSimulator(string robotRunCommand) 
        {
            _robotRunCommand = robotRunCommand;
            this._robot = new Robot(new Board(5, 5));
            this._robot.IsOnBoard = false;
            this._commandParser = new CommandParser(robotRunCommand);
        }

        public void RunRobot() 
        {
            foreach (var cmd in _commandParser.RobotCommnads)
            {
                _command = this._commandParser.GetCommand(cmd);
                _command.Execute(this._robot);
            }
        }
    }
}