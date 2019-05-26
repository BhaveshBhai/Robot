using System;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
           RobotSimulator firstTestCase = new RobotSimulator("PLACE 0,0,NORTH MOVE REPORT");
           firstTestCase.RunRobot();

           RobotSimulator secondTestCase = new RobotSimulator("PLACE 0,0,NORTH LEFT REPORT");
           secondTestCase.RunRobot();

           RobotSimulator thirdTestCase = new RobotSimulator("PLACE 1,2,EAST MOVE MOVE LEFT MOVE REPORT");
           thirdTestCase.RunRobot();

           RobotSimulator invalidTestCase = new RobotSimulator("MOVE REPORT");
           invalidTestCase.RunRobot();

           Console.ReadLine();
        }
    }
}
