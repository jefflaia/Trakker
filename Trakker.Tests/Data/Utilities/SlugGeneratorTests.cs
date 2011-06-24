using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trakker.Data;

namespace Trakker.Tests.Data.Utilities
{
    [TestFixture]
    public class SlugGeneratorTests
    {

        [Test]
        public void Removes_Special_Characters()
        {
            string str = "asdf!@#$%^&*()_+=/*.".GenerateSlug();

            Assert.AreEqual("asdf", str);
        }

        [Test]
        public void Sets_All_Characters_To_Lower_Case()
        {
            string str = "ASDF".GenerateSlug();
            Assert.AreEqual("asdf", str);
        }

        [Test]
        public void Replaces_Signle_Or_More_Spaces_With_Hyphen()
        {
            string str = "a  a   a    a".GenerateSlug();
            Assert.AreEqual("a-a-a-a", str);
        }

        [Test]
        public void Replaces_Single_Space_With_Hyphen()
        {
            string str = "a a a".GenerateSlug();
            Assert.AreEqual("a-a-a", str);
        }

        [Test]
        public void Removes_Accents()
        {
            string str = "`a`a`a`".GenerateSlug();
            Assert.AreEqual("aaa", str);
        }

        [Test]
        public void Removes_Trailing_Spaces()
        {
            string str = " aaa ".GenerateSlug();
            Assert.AreEqual("aaa", str);
        }
    }
}
