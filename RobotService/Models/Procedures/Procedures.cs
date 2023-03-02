using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedures : IProcedure
    {
        private readonly List<IRobot> robots;

        public Procedures()
        {
            this.robots = new List<IRobot>();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            this.robots.Add(robot);
        }

        public virtual string History()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString().TrimEnd();
        }
    }
}

