public class SonicHarvester : Harvester
{
    private const int energyRequirementDivider = 2;
    private const int durabilityLoss = 300;

    public SonicHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement/energyRequirementDivider)
    {
        base.Durability -= durabilityLoss;
    }
}