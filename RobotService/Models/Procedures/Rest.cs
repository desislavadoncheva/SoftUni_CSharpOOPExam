using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedures
    {
        private readonly List<IRobot> robots;

        public Rest() : base()
        {
            this.robots = new List<IRobot>();
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness = robot.Happiness - 3;
            robot.Energy = robot.Energy + 10;
            robot.ProcedureTime = robot.ProcedureTime - procedureTime;
            robots.Add(robot);
        }
        public override string History()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRobot robot in this.robots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
