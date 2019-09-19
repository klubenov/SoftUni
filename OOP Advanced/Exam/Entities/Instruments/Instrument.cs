using System;

namespace FestivalManager.Entities.Instruments
{
	using Contracts;

	public abstract class Instrument : IInstrument
	{
		private double wear;
		private const int MaxWear = 100;
        private int repairAmount;

        protected Instrument(int repairAmount)
		{
			this.Wear = MaxWear;
            this.repairAmount = repairAmount;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
				this.wear = Math.Min(Math.Max(value, 0), 100);
			}
		}

		public void Repair() => this.Wear += this.repairAmount;

		public void WearDown() => this.Wear -= this.repairAmount;

		public bool IsBroken => this.Wear <= 0;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
