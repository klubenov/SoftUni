using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PressureProvider : Provider
{
    private const double durabilityBonus = 300;
    private const double energyOutputMultiplier = 2;
    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput*energyOutputMultiplier)
    {
        base.Durability += durabilityBonus;
    }
}
