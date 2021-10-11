using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            //arrange, act, assert
            //arrange
            var book = new Book("");
            book.AddGrade(90.6);
            book.AddGrade(6.5);
            book.AddGrade(1.8);
            //act
            var results = book.GetStatistics();
            //assert
            Assert.Equal(85.6, results.Average, 1);
            Assert.Equal(90.6, results.Highest, 1);
            Assert.Equal(77.3, results.Lowest, 1);
            Assert.Equal('B', results.Grade);
        }
    }
}
