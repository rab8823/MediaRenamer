using System;
using NUnit.Framework;

namespace MediaRenamer.Tests
{
    [TestFixture]
    public class BaseRenameRuleTests
    {

        [Test]
        [TestCase("AndrewBarefoot", StringSplitOptions.RemoveEmptyEntries, true, new string[]{"Andrew","Barefoot"})]
        [TestCase("Andrew   \tBarefoot", StringSplitOptions.RemoveEmptyEntries, true, new string[]{"Andrew","Barefoot"})]
        [TestCase("andrewBarefoot", StringSplitOptions.RemoveEmptyEntries, true, new string[]{"andrew","Barefoot"})]
        [TestCase("andrew.barefoot", StringSplitOptions.RemoveEmptyEntries, true, new string[]{"andrew","barefoot"})]
        [TestCase("andrew..barefoot", StringSplitOptions.RemoveEmptyEntries, true, new string[]{"andrew","barefoot"})]
        public void TestSplit(string words, StringSplitOptions splitOptions, bool splitOnCaseDifference, string[] expected){
            var result = BaseRenameRule.Split(words, splitOptions, splitOnCaseDifference);
            Assert.AreEqual(expected.Length, result.Length);
            Console.WriteLine(result.Length);
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i],result[i]);
            }
        }
    }
}

