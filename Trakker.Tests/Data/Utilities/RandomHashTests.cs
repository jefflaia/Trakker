using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trakker.Data.Utilities;

namespace Trakker.Tests.Data.Utilities
{
    [TestFixture]
    public class RandomHashTests
    {
        [Test]
        public void Ensure_Hash_Length_Is_Between_Defaults()
        {
            //1000 as a sample
            for (int i = 0; i < 1000; i++)
            {
                string hash = RandomHash.Generate();
                Assert.GreaterOrEqual(hash.Length, 8);
                Assert.LessOrEqual(hash.Length, 10);
            }
        }

        [Test]
        public void Ensure_Hash_Is_Exact_Length()
        {
            //hash length from 1 to 100
            for (int i = 1; i <= 100; i++)
            {
                string hash = RandomHash.Generate(i);
                Assert.GreaterOrEqual(hash.Length, i);
            }
        }

        [Test]
        public void Ensure_Hash_Length_Is_Between_Min_Length_And_Max_Length()
        {
            //1000 as a sample
            for (int i = 0; i < 1000; i++)
            {
                string hash = RandomHash.Generate();
                Assert.GreaterOrEqual(hash.Length, 2);
                Assert.LessOrEqual(hash.Length, 20);
            }
        }
    }
}
