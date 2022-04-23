using System;
using System.Collections.Generic;
using NUnit.Framework;
using SumOfCoins;

namespace SolutionTests
{
    public class Tests
    {
        [Test]
        public void TestWithProvidedExample()
        {
            var coins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [50] = 18,
                [20] = 1,
                [2] = 1,
                [1] = 1
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        public void TestWithOneAvailableCoin()
        {
            var coins = new[] { 1 };
            var targetSum = 42;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [1] = 42
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        public void TestWithUnreachableSum()
        {
            var coins = new[] { 3, 7 };
            var targetSum = 11;

            Assert.Throws<InvalidOperationException>(() => Solution.ChooseCoins(coins, targetSum));
        }

        [Test]
        public void TestWithSeveralCoins()
        {
            var coins = new[] { 1, 2, 5 };
            var targetSum = 78;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [5] = 15,
                [2] = 1,
                [1] = 1
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        [Timeout(100)]
        public void TestWithLargeSum()
        {
            var coins = new[] { 1, 2, 5 };
            var targetSum = 2031154123;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [5] = 406230824,
                [2] = 1,
                [1] = 1
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        public void TestWithNonOptimalParameters()
        {
            var coins = new[] { 1, 9, 10 };
            var targetSum = 27;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [10] = 2,
                [1] = 7
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        public void TestWithSmallCoins()
        {
            var coins = new[] { 1, 2, 3, 4 };
            var targetSum = 1234;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [4] = 308,
                [2] = 1
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        public void TestWithOneCoinNeededOfEachValue()
        {
            var coins = new[] { 1000, 200, 30, 4 };
            var targetSum = 1234;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [1000] = 1,
                [200] = 1,
                [30] = 1,
                [4] = 1
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }

        [Test]
        public void TestWithOneCoinNeeded()
        {
            var coins = new[] { 1, 3, 214, 5 };
            var targetSum = 214;

            var selectedCoins = Solution.ChooseCoins(coins, targetSum);

            var expectedResult = new Dictionary<int, int>
            {
                [214] = 1
            };

            CollectionAssert.AreEqual(expectedResult, selectedCoins);
        }
    }
}