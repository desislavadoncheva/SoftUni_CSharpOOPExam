namespace Computers.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class ComputerTests
    {
        private Part partOne;
        private Part partTwo;
        private Part partThree;
        private Computer computer;
        private List<Part> parts;

        [SetUp]
        public void Setup()
        {
            this.partOne = new Part("Name1", 1);
            this.partTwo = new Part("Name2", 2);
            this.partThree = new Part("Name3", 3);
            this.computer = new Computer("Computer");
            this.parts= new List<Part>();
        }

        [Test]
        public void Test_Constructure_Part()
        {
            Assert.AreEqual("Name1", this.partOne.Name);
            Assert.AreEqual(2, this.partTwo.Price);
        }

        [Test]
        public void Test_Constructure_Computer()
        {
            Assert.AreEqual("Computer", this.computer.Name);
            Assert.AreEqual(0, this.parts.Count);
        }

        [Test]
        public void Test_Create_Null_Computer()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(" "));
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
        }

        [Test]
        public void Test_AddPart_Null()
        {
            Assert.Throws<InvalidOperationException>(() => this.computer.AddPart(null));
        }

        [Test]
        public void Test_Existing_AddPart()
        {
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);
            Assert.AreEqual(2, this.computer.Parts.Count);
        }

        [Test]
        public void Test_Remove_Existing_Part()
        {
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);
            this.computer.RemovePart(partOne);
            Assert.AreEqual(1, this.computer.Parts.Count);
        }

        [Test]
        public void Test_Remove_Part_True()
        {
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);
            Assert.AreEqual(true, this.computer.RemovePart(partOne));
        }

        [Test]
        public void Test_Remove_Name_False()
        {
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);
            Assert.AreEqual(false, this.computer.RemovePart(partThree));
        }

        [Test]
        public void Test_TotalPrice()
        {
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);
            this.computer.AddPart(partThree);
            Assert.AreEqual(6, this.computer.TotalPrice);
        }

        [Test]
        public void Test_GetPart()
        {
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);
            this.computer.AddPart(partThree);
            Assert.AreEqual(partTwo, this.computer.GetPart("Name2"));
        }
    }
}