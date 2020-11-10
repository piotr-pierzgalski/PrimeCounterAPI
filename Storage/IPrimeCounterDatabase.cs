namespace Storage
{
    public interface IPrimeCounterDatabase
    {
        bool AddPrimeCounter(string name, int value);
        (bool, int) GetPrimeCounterValue(string name);
        bool IncrementPrimeCounter(string name, int newValue);
        bool RemovePrimeCounter(string name);
    }
}