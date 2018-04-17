namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var newUnitType = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}");
            var newUnit = Activator.CreateInstance(newUnitType);

            return (IUnit) newUnit;
        }
    }
}
