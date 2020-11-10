using System.Collections.Concurrent;

namespace Storage
{
    public class PrimeCounterDatabase : IPrimeCounterDatabase
    {
        private ConcurrentDictionary<string, int> PrimeCounters;

        public PrimeCounterDatabase()
        {
            PrimeCounters = new ConcurrentDictionary<string, int>();
        }

        public bool AddPrimeCounter(string name, int value)
        {
            return PrimeCounters.TryAdd(name, value);
        }

        public bool RemovePrimeCounter(string name)
        {
            return PrimeCounters.TryRemove(name, out _);
        }

        public bool IncrementPrimeCounter(string name, int newValue)
        {
            if(PrimeCounters.TryGetValue(name, out int currentValue))
            {
                return PrimeCounters.TryUpdate(name, newValue, currentValue);
            }
            else
            {
                return false;
            }
        }

        public (bool, int) GetPrimeCounterValue(string name)
        {
            var valueExists = PrimeCounters.TryGetValue(name, out int value);
            return (valueExists, value);
        }
    }
}
