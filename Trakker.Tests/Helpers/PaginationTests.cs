using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Gallio.Framework;
using Trakker.Helpers;

namespace Trakker.Tests.ViewModels
{
    /// <summary>
    /// Summary description for PaginationViewModelTest
    /// </summary>
    [TestFixture]
    public class PaginationTests
    {
        [Test]
        public void ExpectedValueForHasNextPage()
        {
            Pagination p = new Pagination(2, 1, 1);
            Assert.IsTrue(p.HasNextPage);

            p = new Pagination(2, 2, 1);
            Assert.IsTrue(!p.HasNextPage);
        }

        [Test]
        public void IndexCannotBeLessThanOne()
        {
            Pagination p = new Pagination(10, 0, 5);
            Assert.AreEqual(1, p.Index);
        }

        [Test]
        public void IndexCannotBeGreaterThanTotalPages()
        {
            Pagination p = new Pagination(10, 3, 5);
            Assert.AreEqual(2, p.Index);
        }

        [Test]
        public void ExpectedValueForHasPreviousPage()
        {
            Pagination p = new Pagination(2, 2, 1);
            Assert.IsTrue(p.HasPreviousPage);

            p = new Pagination(2, 1, 1);
            Assert.IsTrue(!p.HasPreviousPage);
        }

        [Test]
        public void ExpectedValueForLowerboundWithEvenVariance()
        {
            Pagination p = new Pagination(100, 5, 10, 10);

            //5 - 4
            Assert.AreEqual(1, p.Lowerbound); 
        }

        [Test]
        public void ExpectedValueForLowerboundWithOddVariance()
        {
            Pagination p = new Pagination(100, 5, 10, 7);
            
            //5 - 3
            Assert.AreEqual(2, p.Lowerbound);
        }

        [Test]
        public void ExpectedValueForUpperboundWithEvenVariance()
        {
            Pagination p = new Pagination(100, 5, 10, 10);

            //5 + 6
            Assert.AreEqual(10, p.Upperbound);
        }

        [Test]
        public void ExpectedValueForUpperboundWithOddVariance()
        {
            Pagination p = new Pagination(100, 5, 10, 7);

            //5 + 3
            Assert.AreEqual(8, p.Upperbound);
        }

        [Test]
        public void ExpectedValueForTotalPages()
        {
            Pagination p = new Pagination(100, 1, 10);
            Assert.AreEqual(10, p.TotalPages);
        }

        [Test]
        public void ExpectedValueForItemCount()
        {
            Pagination p = new Pagination(100, 1, 10);
            Assert.AreEqual(100, p.ItemCount);
        }

        [Test]
        public void ExpectedValueForPageSize()
        {
            Pagination p = new Pagination(100, 1, 10);
            Assert.AreEqual(10, p.PageSize);
        }

        [Test]
        public void ExpectedValueForIndex()
        {
            Pagination p = new Pagination(100, 1, 10);
            Assert.AreEqual(1, p.Index);
        }

        [Test]
        public void LowerboundCannotBeLessThanOne()
        {
            Pagination p = new Pagination(10, 1, 1, 10);
            Assert.AreEqual(1, p.Lowerbound);
        }

        [Test]
        public void LowerboundCannotBeGreaterThanIndex()
        {
            Pagination p = new Pagination(10, 1, 1, -10);
            Assert.LessThanOrEqualTo(p.Lowerbound, p.Index);
        }

        [Test]
        public void UpperboundCannotBeLessThanIndex()
        {
            Pagination p = new Pagination(10, 1, 1, -10);
            Assert.GreaterThanOrEqualTo(p.Upperbound, p.Index);
        }

        [Test]
        public void UpperboundCannotBeGreaterThanTotalPages()
        {
            Pagination p = new Pagination(20, 9, 2, 10);
            Assert.GreaterThanOrEqualTo(p.Upperbound, p.Index);
        }

        [Test]
        public void PreviousPageCannotBeLessThanOne()
        {
            Pagination p = new Pagination(10, 1, 2);
            Assert.AreEqual(1, p.PreviousPage);
        }

        [Test]
        public void NextPageCannotBeGreaterThanTotalPages()
        {
            Pagination p = new Pagination(10, 5, 2);
            Assert.AreEqual(5, p.NextPage);
        }

        
    }
}
