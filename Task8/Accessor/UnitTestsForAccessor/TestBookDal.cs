using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino.Mocks;
using Rhino;
using NUnit.Framework;
using DataAccess;
using Containers;
using Entities;
using Services;

namespace UnitTestsForAccessor
{
    [TestFixture]
    public class TestBookDal
    {
        MockRepository _mock;
        Book[] _fakeBookArray = new Book[]
        {
            new Book(1,1,"Call of Chtulhu"),
            new Book(2,2, "CLR via C#")
        };

        [SetUp]
        public void SetUpContainerAndMock() 
        {
            _mock = new MockRepository();
        }

        [Test]
        public void TestMemoryDal() 
        {
            IAccessor<Book> _bookDalStub = _mock.Stub<BookMemoryAccessor>();
            
            using (_mock.Record())
            {
                SetupResult.For(_bookDalStub.GetAll()).Return(_fakeBookArray);
            }

            IServices<Book> _myService = new Service<Book>(_bookDalStub);
            var result = _myService.GetAll();
            Assert.AreEqual(result.Length, 2);
        }

        [Test]
        public void TestFileDal()
        {
            IAccessor<Book> _bookDalStub = _mock.Stub<BookFileAccessor>();
            using (_mock.Record())
            {
                SetupResult.For(_bookDalStub.GetAll()).Return(_fakeBookArray);
            }

            IServices<Book> _myService = new Service<Book>(_bookDalStub);
            var result = _myService.GetAll();
            Assert.AreEqual(result.Length, 2);
        }

    }
}
