namespace Storage
{
    public interface IPrimeNumberDatabase
    {
        int GetNextPrimeNumber(int currentPrimeNumber);
    }
}