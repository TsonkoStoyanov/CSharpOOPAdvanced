using FestivalManager.Core.IO;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private readonly IStage stage;

        public IFestivalController festivalCоntroller;
        public ISetController setCоntroller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.stage = new Stage();
            this.festivalCоntroller = new FestivalController(stage);
            this.setCоntroller = new SetController(stage);
        }

        public void Run()
        {
            var input = reader.ReadLine();


            while (input == "END")
            {
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex) // in case we run out of memory
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }

                input = reader.ReadLine();

            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split(" ".ToCharArray().First());

            var command = inputArgs.First();
            var args = inputArgs.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string a;

            try
            {
                a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { args });
            }
            catch (TargetInvocationException up)
            {
                throw up; // ha ha
            }

            return a;
        }
    }
}