using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        private readonly Dictionary<string, IRobot> robots;
        private readonly IProcedure chipProcedure;
        private readonly IProcedure techCheckProcedure;
        private readonly IProcedure restProcedure;
        private readonly IProcedure chargeProcedure;
        private readonly IProcedure polishProcedure;
        private readonly IProcedure workProcedure;
        private readonly IGarage garage;
        private readonly List<IProcedure> procedures;

        public Controller()
        {
            this.robots = new Dictionary<string, IRobot>();
            this.chipProcedure = new Chip();
            this.techCheckProcedure = new TechCheck();
            this.restProcedure = new Rest();
            this.chargeProcedure = new Chip();
            this.polishProcedure = new TechCheck();
            this.workProcedure = new Rest();
            this.garage = new Garage();
            this.procedures = new List<IProcedure>();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            chargeProcedure.DoService(robot, procedureTime);
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            chipProcedure.DoService(robot, procedureTime);
            return $"{robotName} had chip procedure";
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            polishProcedure.DoService(robot, procedureTime);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            restProcedure.DoService(robot, procedureTime);
            return $"{robotName} had rest procedure";
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            techCheckProcedure.DoService(robot, procedureTime);
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            workProcedure.DoService(robot, procedureTime);
            return $"{robotName} was working for {procedureTime} hours";
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = this.garage.Robots.GetValueOrDefault(robotName);
            garage.Sell(robot.Name, robot.Owner);
            this.robots.Remove(robotName);
            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            return $"{ownerName} bought robot without chip";
        }

        public string History(string procedureType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{procedureType}");
            switch (procedureType)
            {
                case "Chip":
                    sb.Append(chipProcedure.History().ToString());
                    break;
                case "Charge":
                    sb.Append(chipProcedure.History().ToString());
                    break;
                case "Polish":
                    sb.Append(chipProcedure.History().ToString());
                    break;
                case "Rest":
                    sb.Append(chipProcedure.History().ToString());
                    break;
                case "Work":
                    sb.Append(chipProcedure.History().ToString());
                    break;
                case "TechCheck":
                    sb.Append(chipProcedure.History().ToString());
                    break;
                default:
                    break;
            }
            return sb.ToString().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (robotType != nameof(HouseholdRobot) && robotType != nameof(PetRobot) && robotType != nameof(WalkerRobot))
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }
            IRobot robot = null;
            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                default:
                    break;
            }
            garage.Manufacture(robot);
            this.robots.Add(robot.Name, robot);
            return $"Robot {robot.Name} registered successfully";
        }
    }
}
