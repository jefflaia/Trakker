using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trakker.Core;
using Trakker.Infastructure.Validation;


namespace Trakker.Tests.Infastructure.Validation
{
    [TestFixture]
    public class UriTest
    {
        UriAttribute _attrib;

        public UriTest()
        {
            _attrib = new UriAttribute();
        }

        [Test]
        public void Absolute_Uri_Is_Valid()
        {
            string uri = "http://www.google.com";
            Assert.AreEqual(true, _attrib.IsValid(uri));
        }

        [Test]
        public void Uri_Must_Have_Protocol()
        {
            string uri = "google.com";
            Assert.AreEqual(false, _attrib.IsValid(uri));

            uri = "www.google.com";
            Assert.AreEqual(false, _attrib.IsValid(uri));
        }

        [Test]
        public void Uri_Does_Not_Need_WWW()
        {
            string uri = "http://google.com";
            Assert.AreEqual(true, _attrib.IsValid(uri));
        }

        [Test]
        public void Uri_Can_Contain_Query_String()
        {
            string uri = "http://www.google.com?id=12345";
            Assert.AreEqual(true, _attrib.IsValid(uri));
        }

        [Test]
        public void Uri_Can_Contain_Directory_Paths()
        {
            string uri = "http://www.google.com/some/dir/path/";
            Assert.AreEqual(true, _attrib.IsValid(uri));
        }

        [Test]
        public void Uri_Can_Contain_Directory_And_File_Paths()
        {
            string uri = "http://www.google.com/some/dir/path/file.ext";
            Assert.AreEqual(true, _attrib.IsValid(uri));
        }

        [Test]
        public void Uri_Can_Contain_Directory_And_File_Paths_With_Query_String()
        {
            string uri = "http://www.google.com/some/dir/path/file.ext?id=12345";
            Assert.AreEqual(true, _attrib.IsValid(uri));
        }
    }
}
