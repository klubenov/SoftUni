
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.reader = reader;
            this.writer = writer;
        }

		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var inputData = input.Split(' ');

            var command = inputData[0];
			var args = inputData.Skip(1).ToArray();

            string result = string.Empty;

            switch (command)
            {
                case "RegisterSet":
                    result = this.festivalCоntroller.RegisterSet(args);                   
                    break;
                case "SignUpPerformer":
                    result = this.festivalCоntroller.SignUpPerformer(args);
                    break;
                case "RegisterSong":
                    result = this.festivalCоntroller.RegisterSong(args);
                    break;
                case "AddSongToSet":
                    result = this.festivalCоntroller.AddSongToSet(args);
                    break;
                case "AddPerformerToSet":
                    result = this.festivalCоntroller.AddPerformerToSet(args);
                    break;
                case "RepairInstruments":
                    result = this.festivalCоntroller.RepairInstruments(args);
                    break;
                case "LetsRock":
                    result = this.setCоntroller.PerformSets();
                    break;
            }

            return result;

        }
    }
}