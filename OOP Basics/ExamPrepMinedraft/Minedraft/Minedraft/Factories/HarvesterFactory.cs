using System;
using System.Collections.Generic;
using System.Text;


public class HarvesterFactory
{
    public Harvester InstantiateHarvester(List<string> harvesterData)
    {
        switch (harvesterData[0])
        {
            case "Sonic":
                return new SonicHarvester(harvesterData[1], double.Parse(harvesterData[2])
                    ,double.Parse(harvesterData[3]), int.Parse(harvesterData[4]));
            case "Hammer":
                return new HammerHarvester(harvesterData[1], double.Parse(harvesterData[2])
                    , double.Parse(harvesterData[3]));
        }

        throw new ArgumentException("Invalid harvester parameters!");
    }
}

