using System;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
            this.Owner = owner;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            }
        }

        public int ProcedureTime
        {
            get => this.procedureTime;
            set
            {
                this.procedureTime = value;
            }
        }

        public string Owner
        {
            get => this.owner;
            set => this.owner = "Service";
        }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine
            ($" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}");
            return sb.ToString().TrimEnd();
        }
    }
}
