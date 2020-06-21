namespace Dotnetos.AsyncExpert.Homework.Module01.Benchmark
{
    public static class FibbonacciCalc
    {
        public static ulong Recursive(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

        public static ulong Iterative(ulong n)
        {
            ulong previousPreviousNumber, previousNumber = 0, currentNumber = 1;

            for (ulong i = 1; i < n ; i++) {

                previousPreviousNumber = previousNumber;

                previousNumber = currentNumber;

                currentNumber = previousPreviousNumber + previousNumber;

            }
            
            return currentNumber;
        }
    }

    public class FibbonacciCalcWithMemoization
    {
        private readonly ulong _n;
        private readonly ulong[] _calculated;
        
        public FibbonacciCalcWithMemoization(ulong n)
        {
            _n = n;
            _calculated = new ulong[n];
        }
        
        public ulong RecursiveWithMemoization()
        {
            if (_n == 1 || _n == 2) return 1;

            _calculated[0] = 1;
            _calculated[1] = 1;
            
            return RecursiveWithMemoization(_n);
        }
        
        private ulong RecursiveWithMemoization(ulong n)
        {
            var alreadyCalculated = _calculated[n - 1];
            return alreadyCalculated == 0 ? _calculated[n - 1] = RecursiveWithMemoization(n -2) + RecursiveWithMemoization(n - 1) : alreadyCalculated;
        }
    }
}