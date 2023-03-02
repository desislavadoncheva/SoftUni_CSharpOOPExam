using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            string robotName = robot.Name;
            if (robots.Count() > Capacity) 
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} already exist");
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = robots.Values.FirstOrDefault(r => r.Name == robotName);
            robot.Owner = ownerName;
            robot.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
