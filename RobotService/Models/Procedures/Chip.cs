using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedures
    {
        private readonly List<IRobot> robots;

        public Chip() : base()
        {
            this.robots = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {

            if (robot.IsChipped == true)
            {
                throw new ArgumentException($"{robot.Name} is already chipped");
            }
            robot.Happiness = robot.Happiness - 5;
            robot.IsChipped = true;
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
