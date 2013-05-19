using NUnit.Framework;
using System;
using MediaRenamer;

namespace MediaRenamer.Tests
{
    [TestFixture()]
	public class TitleCaseRenameRuleTests
    {
        [Test()]
        [TestCase("of.mice.and.men","Of.Mice.and.Men")]
		public void RenameTest(string input, string expected)
        {
            var rule = new TitleCaseRule();
            Assert.AreEqual(expected, rule.Rename(input));
        }
    }
}

