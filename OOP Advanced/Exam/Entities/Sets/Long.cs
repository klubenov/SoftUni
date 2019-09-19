namespace FestivalManager.Entities.Sets
{

    using System;
    public class Long : Set
    {
        private TimeSpan maxDuration = new TimeSpan(1,0,0);

        public Long(string name) : base(name, new TimeSpan(1, 0, 0))
        {            
        }
    }
}
