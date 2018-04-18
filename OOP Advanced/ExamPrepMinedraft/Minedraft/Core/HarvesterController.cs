using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;
    private IEnergyRepository energyRepository;
    private string mode;
    private double modeMultiplier;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.mode = "Full";
        this.modeMultiplier = 1;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        if(mode == "Half")
        {
            this.modeMultiplier = 0.5;
        }
        else if (this.mode == "Energy")
        {
            this.modeMultiplier = 0.2;
        }
        else
        {
            this.modeMultiplier = 1;
        }

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        double oreProducedForTheDay = 0;
        double energyRequired = this.harvesters.Sum(h => h.EnergyRequirement)*modeMultiplier;

        if (this.energyRepository.EnergyStored < energyRequired)
        {
            return string.Format(Constants.OreProducedToday, oreProducedForTheDay);
        }

        oreProducedForTheDay = this.harvesters.Sum(h => h.Produce())*modeMultiplier;
        OreProduced += oreProducedForTheDay;
        this.energyRepository.TakeEnergy(energyRequired);

        foreach (var infinityHarvester in this.Entities.Where(h => h.GetType().Name=="InfinityHarvester"))
        {
            ((InfinityHarvester) infinityHarvester).SelfRepair();
        }

        return string.Format(Constants.OreProducedToday, oreProducedForTheDay);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}

