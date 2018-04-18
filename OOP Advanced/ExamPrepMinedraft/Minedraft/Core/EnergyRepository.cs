using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public EnergyRepository()
    {
        this.EnergyStored = 0;
    }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (this.EnergyStored >= energyNeeded)
        {
            this.EnergyStored -= energyNeeded;
            return true;
        }

        return false;
    }
}

