using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            //declare variable of type delegate
            WriteLogDelegate log = ReturnMessage;
            //initialize de variable to point to the method
            log += ReturnMessage; //or easier: log = ReturnMessage;
            log += IncrementCount;
            //invoke as many times as you want the method
            var result = log("Hello");
            Assert.Equal("hello", result);
            Assert.Equal(3, count);


        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehavesLikeValueTypes()
        {
            string name = "Scott";
            name = MakeUppercase(name);
            Assert.Equal("SCOTT", name);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void Test()
        {
            var x = GetInt();
            SetInt( ref x);
            Assert.Equal(42, x);
        }

        private void SetInt( ref int x)
        {
            x = 42;
        }


        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsCanPassByRef()
        {
            //arrange, act, assert
            var book1 = GetBook("Book 1");
            GetBookSetNameWithRef(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameWithRef(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange, act, assert
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CanSetNewNameFromRef()
        {
            //arrange, act, assert
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange, act, assert
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        [Fact]
        public void TwoVariablesCanReferenceToSameObj()
        {
            //arrange, act, assert
            var book1 = GetBook("Book 1");
            var book2 = book1;
            Assert.Same(book1, book2);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
