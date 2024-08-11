namespace CodeBase.Services.EnergyService
{
    public interface IEnergyService
    {
        public bool TryReduceEnergy(int valueReduction);
    }
}