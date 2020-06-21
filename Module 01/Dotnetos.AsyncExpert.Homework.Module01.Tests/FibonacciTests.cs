using System.Collections;
using System.Collections.Generic;
using Dotnetos.AsyncExpert.Homework.Module01.Benchmark;
using Shouldly;
using Xunit;

namespace Dotnetos.AsyncExpert.Homework.Module01.Tests
{
    public class FibonacciTests
    {
        [Theory]
        [ClassData(typeof(FibonacciTestsData))]
        public void Recursive_WhenNumberIsPresent_ShouldReturnCorrectResult(ulong value, ulong expected)
            => FibbonacciCalc.Recursive(value).ShouldBe(expected);
        
        [Theory]
        [ClassData(typeof(FibonacciTestsData))]
        public void Iterative_WhenNumberIsPresent_ShouldReturnCorrectResult(ulong value, ulong expected)
            => FibbonacciCalc.Iterative(value).ShouldBe(expected);
        
        [Theory]
        [ClassData(typeof(FibonacciTestsData))]
        public void RecursiveWithMemoization_WhenNumberIsPresent_ShouldReturnCorrectResult(ulong value, ulong expected)
            => new FibbonacciCalcWithMemoization(value).RecursiveWithMemoization().ShouldBe(expected);
    }
    
    public class FibonacciTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 1 };
            yield return new object[] { 3, 2 };
            yield return new object[] { 4, 3 };
            yield return new object[] { 5, 5 };
            yield return new object[] { 6, 8 };
            yield return new object[] { 7, 13 };
            yield return new object[] { 8, 21 };
            yield return new object[] { 13, 233 };
            yield return new object[] { 19, 4181 };
            yield return new object[] { 23, 28657 };
            yield return new object[] { 29, 514229 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}