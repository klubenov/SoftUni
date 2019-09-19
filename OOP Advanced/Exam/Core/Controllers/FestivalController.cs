namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
        private const string TimeFormatShort = "mm\\:ss";
        private const string TimeFormat = "{0}:{1}:{2}";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

		public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, 
            IPerformerFactory performerFactory, ISetFactory setFactory, ISongFactory songFactory)
		{
			this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.setFactory = setFactory;
            this.songFactory = songFactory;
		}

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(0,this.stage.Sets.Sum(s => s.ActualDuration.Minutes),this.stage.Sets.Sum(s => s.ActualDuration.Seconds));
            var totalHours = totalFestivalLength.Hours;
            var totalMinutes = totalFestivalLength.Minutes;
            var totalSeconds = totalFestivalLength.Seconds;



            result += $"Festival length: {totalFestivalLength.ToString("mm\\:ss")}" + Environment.NewLine;

            foreach (var set in this.stage.Sets)
			{
                result += ($"--{set.Name} ({set.ActualDuration.ToString("mm\\:ss")}):") + Environment.NewLine;

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + Environment.NewLine;
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + Environment.NewLine;
				else
				{
					result += ("--Songs played:") + Environment.NewLine;
					foreach (var song in set.Songs)
					{
						result += ($"----{song}") + Environment.NewLine;
					}
				}
			}

			return result.ToString();
		}

		public string RegisterSet(string[] args)
		{
            var setName = args[0];
            var setType = args[1];
            var setInstance = this.setFactory.CreateSet(setName, setType);
            this.stage.AddSet(setInstance);

            return $"Registered {setType} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instuments = args.Skip(2).ToArray();

			var intstrumentsInstances = instuments
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in intstrumentsInstances)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            var songName = args[0];
            var songDuration = args[1].Split(':');
            var songMinutes = int.Parse(songDuration[0]);
            var songSeconds = int.Parse(songDuration[1]);

            var song = this.songFactory.CreateSong(songName, new TimeSpan(0, songMinutes, songSeconds));
            this.stage.AddSong(song);

			return $"Registered song {song}";
		}

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song.Name} to {set.Name}";
		}

		//public string AddPerformerToSet(string[] args)
		//{
		//	return PerformerRegistration(args);
		//}

		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			//AddPerformerToSet(args);

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear <= 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}