using System;
using System.Collections;
using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class CommandParser
    {
        private string _runRobotCommand;

        private string _placeCommnd;

        private string _xCoordinate;

        private string _yCoordinate;

        private string _direction;

        private List<string> robotCommnads = new List<string>();

        public List<string> RobotCommnads { get => robotCommnads; }

        public CommandParser(string runRobotCommand)
        {
            this._runRobotCommand = runRobotCommand;
            this.ParseCommand();
        }

        public ICommand GetCommand(string command)
        {
            int.TryParse(_xCoordinate, out int x);
            int.TryParse(_yCoordinate, out int y);
            ICommand _command = null;
            switch (command)
            {
                case "PLACE":
                    _command = new PlaceCommand(x, y, HelperClass.GetEnumFromString(_direction));
                    break;
                case "MOVE":
                    _command = new MoveForwordCommand();
                    break;
                case "LEFT":
                    _command = new TurnLeftCommand();
                    break;
                case "RIGHT":
                    _command = new TurnRightCommand();
                    break;
                case "REPORT":
                    _command = new ReportCommnd();
                    break;
                default:
                    Console.WriteLine("The Commnd is invalid!");
                    break;
            }
            return _command;
        }

        private void ParseCommand()
        {
            var tempCommands = _runRobotCommand.Replace(",", " ");
            string[] cmds = tempCommands.Split(" ");

            if (cmds.Length > 0)
            {
                try
                {
                    this._placeCommnd = cmds[0];
                    this._xCoordinate = cmds[1];
                    this._yCoordinate = cmds[2];
                    this._direction = cmds[3];
                    /** Add Place Command in the robotCommand Collection */
                    this.RobotCommnads.Add(_placeCommnd);
                    for (int i = 4; i < cmds.Length; i++)
                    {
                        this.RobotCommnads.Add(cmds[i]);
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("The Command is Invalid Do not able to Parse it.");
                }

            }
        }
    }
}