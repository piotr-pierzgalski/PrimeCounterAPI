using System.Collections.Generic;

namespace Storage
{
    public class PrimeNumberDatabase : IPrimeNumberDatabase
    {
        const int Limit = 20000;
        private Dictionary<int, int> NextPrimeNumberDictionary;


        public PrimeNumberDatabase()
        {
            var primeNumbersList = SieveOfErasthotenes(Limit);
            NextPrimeNumberDictionary = BuildFastAccessDictionary(primeNumbersList);
        }

        public int GetNextPrimeNumber(int currentPrimeNumber)
        {
            if (NextPrimeNumberDictionary.TryGetValue(currentPrimeNumber, out int nextPrimeNumber))
            {
                return nextPrimeNumber;
            }
            else
            {
                //If the current prime number is not stored in the dictionary as a key, then it has exceeded 20000 value.
                return 2;
            }
        }

        private List<int> SieveOfErasthotenes(int limit)
        {
            List<int> foundPrimes = new List<int>();
            //Slightly modified Sieve of Erasthotenes algorithm taken from http://csharphelper.com/blog/2014/08/use-the-sieve-of-eratosthenes-to-find-prime-numbers-in-c/

            // Make an array indicating whether numbers are prime.
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++) isPrime[i] = true;

            // Cross out multiples.
            for (int i = 2; i <= limit; i++)
            {
                // See if i is prime.
                if (isPrime[i])
                {
                    // Knock out multiples of i.
                    for (int j = i * 2; j <= limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                    foundPrimes.Add(i);
                }
            }

            return foundPrimes;
        }

        private Dictionary<int, int> BuildFastAccessDictionary(List<int> primeNumbersList)
        {
            Dictionary<int, int> fastAccessDict = new Dictionary<int, int>();

            for (int i = 0; i < primeNumbersList.Count - 1; i++)
            {
                fastAccessDict[primeNumbersList[i]] = primeNumbersList[i + 1];
            }

            return fastAccessDict;
        }
    }
}
